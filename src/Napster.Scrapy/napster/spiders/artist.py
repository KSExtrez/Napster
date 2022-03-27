import json
import scrapy

from napster.items import Artist


class ArtistSpider(scrapy.Spider):
    name = 'artist'
    allowed_domains = ['us.napster.com']
    start_urls = ['https://us.napster.com/artist/billie-eilish']

    custom_settings = {
        'ITEM_PIPELINES': {
            'napster.pipelines.NapsterPipeline': 100,
        },
    }

    def parse(self, response):
        artist = Artist()
        metadata = response.css('div.page-metadata')

        artist['id'] = metadata.attrib['meta_artist_id']
        artist['name'] = metadata.attrib['meta_artist_name']
        artist['img'] = response.css('.artist-image>img').attrib['src']
        artist['genres'] = json.loads(metadata.attrib['meta_genre_id'])
        artist['albums'] = response.css(
            'div.album-list>div::attr(album_id)').getall()
        return artist
