import json
import scrapy

from napster.items import Artist


class ArtistSpider(scrapy.Spider):
    name = 'artist'
    allowed_domains = ['us.napster.com']
    start_urls = ['https://us.napster.com/artist/adele']

    def parse(self, response):
        artist = Artist()
        metadata = response.css('div.page-metadata')

        artist['Id'] = metadata.attrib['meta_artist_id']
        artist['Name'] = metadata.attrib['meta_artist_name']
        artist['Description'] = response.css(
            '.artist-bio.hero-blurb::text').get()
        artist['Img'] = response.css('.artist-image>img').attrib['src']
        artist['GenreIds'] = json.loads(metadata.attrib['meta_genre_id'])
        return artist
