import scrapy
import json
from napster.items import Genre


class PruebaSpider(scrapy.Spider):
    name = 'prueba'
    allowed_domains = ['us.napster.com']
    start_urls = ['https://us.napster.com/genre/rock/lite-rock']

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
        if len(ids) > 1:
            genre['parent_genre'] = ids[-2]
        else:
            genre['parent_genre'] = 'g.0'
        return genre
