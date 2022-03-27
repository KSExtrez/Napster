import json
from scrapy.spiders import CrawlSpider, Rule
from scrapy.linkextractors import LinkExtractor

from napster.items import Album, Artist, Genre, Track


class MusicSpider(CrawlSpider):
    name = 'music'
    allowed_domains = ['us.napster.com']
    start_urls = ['https://us.napster.com/music']
    custom_settings = {
        'ITEM_PIPELINES': {
            'napster.pipelines.MongoPipeline': 100
        },
        'CLOSESPIDER_PAGECOUNT': 200
    }

    rules = [
        Rule(
            LinkExtractor(allow=('genre/'), unique=True),
            callback='parse_genre',
            follow=True,
        ),
        Rule(
            LinkExtractor(
                allow='artist/',
                deny=('album/', 'albums'),
                unique=True,
            ),
            callback='parse_artist',
            follow=True,
        ),
        Rule(
            LinkExtractor(allow='album/', unique=True),
            callback='parse_album',
            follow=True,
        ),
    ]

    def parse_genre(self, response):
        genre = Genre()
        ids = response.css(
            'div.page-metadata::attr(meta_genre_id)').get()

        ids = json.loads(ids)

        # gets the last id (current genre id)
        genre['id'] = ids[-1]

        # gets the last name (current name)
        genre['name'] = response.css(
            '#page-name::text').get().replace(' Music', '')
        genre['description'] = response.css(
            'div.genre-banner-text').css('div.genre-blurb::text').get().strip()
        if len(ids) > 1:
            genre['parent_genre'] = ids[-2]
        else:
            genre['parent_genre'] = 'g.0'
        return genre

    def parse_artist(self, response):
        artist = Artist()
        metadata = response.css('div.page-metadata')

        artist['id'] = metadata.attrib['meta_artist_id']
        artist['name'] = metadata.attrib['meta_artist_name']
        artist['img'] = response.css('.artist-image>img').attrib['src']
        artist['genres'] = json.loads(metadata.attrib['meta_genre_id'])
        artist['albums'] = response.css(
            'div.album-list>div::attr(album_id)').getall()
        return artist

    def parse_album(self, response):
        album = Album()
        metadata = response.css('div.page-metadata')

        album['id'] = metadata.attrib['meta_album_id']
        album['name'] = metadata.attrib['meta_album_name']
        album['artist'] = metadata.attrib['meta_artist_id']
        album['genres'] = json.loads(metadata.attrib['meta_genre_id'])
        album['img'] = response.css('.hero-img>img').attrib['src']
        album['release_date'] = response.css(
            '#release-date>time::text').get().strip()
        album['label'] = response.css(
            '#music-label::text').get().replace('Label:', '').strip()
        # album['tracks'] = response.css(
        #    '.track-list>li::attr(track_id)').getall()
        tracks = []
        traks_li = response.css(
            '.track-list>li')
        for item in traks_li:
            track = Track()
            track['id'] = item.attrib['track_id']
            track['name'] = item.attrib['track_name']
            track['album'] = item.attrib['album_id']
            track['preview'] = item.attrib['preview_url']
            track['duration'] = item.attrib['duration']
            track['artist'] = item.attrib['artist_id']
            try:
                track['genres'] = json.loads(item.attrib['genre_id'])
            except ValueError:
                track['genres'] = []
            tracks.append(track)
        album['tracks'] = tracks
        return album

    def parse_track(self, response):
        self.logger.info('Response URL=%s' % response.url)
        pass
