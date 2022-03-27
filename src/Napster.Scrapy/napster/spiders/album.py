import json
import scrapy

from napster.items import Album, Track


class AlbumSpider(scrapy.Spider):
    name = 'album'
    allowed_domains = ['us.napster.com']
    start_urls = [
        'https://us.napster.com/artist/mc-lars/album/lars-attacks-horris-records-2018']

    def parse(self, response):
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
            except ValueError as e:
                track['genres'] = []

            tracks.append(track)
        album['tracks'] = tracks
        return album
