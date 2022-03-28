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
            'napster.pipelines.DuplicateItemsPipeline': 100,
            'napster.pipelines.CleanDataPipeline': 200,
            'napster.pipelines.MongoPipeline': 300
        },
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
        genre['Id'] = ids[-1]

        # gets the last name (current name)
        genre['Name'] = response.css(
            '#page-name::text').get().replace(' Music', '')
        genre['Description'] = response.css(
            'div.genre-banner-text').css('div.genre-blurb::text').get()
        if len(ids) > 1:
            genre['ParentGenreId'] = ids[-2]
        else:
            genre['ParentGenreId'] = 'g.0'
        return genre

    def parse_artist(self, response):
        artist = Artist()
        metadata = response.css('div.page-metadata')

        artist['Id'] = metadata.attrib['meta_artist_id']
        artist['Name'] = metadata.attrib['meta_artist_name']
        artist['Description'] = response.css(
            '.artist-bio.hero-blurb::text').get()
        artist['Img'] = response.css('.artist-image>img').attrib['src']
        artist['GenreIds'] = json.loads(metadata.attrib['meta_genre_id'])
        return artist

    def parse_album(self, response):
        album = Album()
        metadata = response.css('div.page-metadata')

        album['Id'] = metadata.attrib['meta_album_id']
        album['Name'] = metadata.attrib['meta_album_name']
        album['ArtistId'] = metadata.attrib['meta_artist_id']
        album['GenreIds'] = json.loads(metadata.attrib['meta_genre_id'])
        album['Img'] = response.css('.hero-img>img').attrib['src']
        album['ReleaseDate'] = response.css(
            '#release-date>time::text').get().strip()
        album['Label'] = response.css(
            '#music-label::text').get().replace('Label:', '').strip()

        tracks = []
        traks_li = response.css(
            '.track-list>li')
        for item in traks_li:
            track = Track()
            track['Id'] = item.attrib['track_id']
            track['Name'] = item.attrib['track_name']
            track['AlbumId'] = item.attrib['album_id']
            track['Preview'] = item.attrib['preview_url']
            track['Duration'] = item.attrib['duration']
            track['ArtistId'] = item.attrib['artist_id']
            try:
                track['GenreIds'] = json.loads(item.attrib['genre_id'])
            except ValueError:
                track['GenreIds'] = []
            tracks.append(track)
        album['Tracks'] = tracks
        return album

    def parse_track(self, response):
        self.logger.info('Response URL=%s' % response.url)
        pass
