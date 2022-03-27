import scrapy
import json
from napster.items import Genre


class PruebaSpider(scrapy.Spider):
    name = 'prueba'
    allowed_domains = ['us.napster.com']
    start_urls = ['https://us.napster.com/genre/rock/lite-rock']

    ITEM_PIPELINES = {
        'napster.pipelines.CleanArtistPipeline': 100,
    }

    def parse(self, response):
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
            'div.genre-banner-text').css('div.genre-blurb::text').get()
        genre['sub_genres'] = response.css(
            'ul.genre-list').css('a.tag-button::text').getall()
        genre['artists'] = response.css(
            'div.artist-list').css('div.name>a.artist-link::text').getall()
        if len(ids) > 1:
            genre['parent_genres'] = ids[-2]
        else:
            genre['parent_genres'] = 'g.0'
        return genre
