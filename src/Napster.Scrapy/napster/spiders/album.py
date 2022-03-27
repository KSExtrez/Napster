import scrapy

from napster.items import Album


class AlbumSpider(scrapy.Spider):
    name = 'album'
    allowed_domains = ['us.napster.com']
    start_urls = [
        'https://us.napster.com/artist/billie-eilish/album/when-we-all-fall-asleep-where-do-we-go']

    def parse(self, response):
        album = Album()
        metadata = response.css('div.page-metadata')

        album['id'] = metadata.attrib['meta_album_id']
        album['name'] = metadata.attrib['meta_album_name']
        album['artist'] = metadata.attrib['meta_artist_id']
        album['genres'] = metadata.attrib['meta_genre_id']
        album['img'] = response.css('.hero-img>img').attrib['src']
        album['release_date'] = response.css('#release-date>time::text').get()
        album['label'] = response.css('#music-label::text').get()
        album['songs'] = response.css(
            '.track-list>li::attr(track_id)').getall()
        return album
