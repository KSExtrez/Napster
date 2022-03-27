# Define here the models for your scraped items
#
# See documentation in:
# https://docs.scrapy.org/en/latest/topics/items.html
import scrapy


class Genre(scrapy.Item):
    id = scrapy.Field()
    name = scrapy.Field()
    description = scrapy.Field()
    parent_genre = scrapy.Field()


class Artist(scrapy.Item):
    id = scrapy.Field()
    name = scrapy.Field()
    img = scrapy.Field()
    genres = scrapy.Field()
    albums = scrapy.Field()


class Album(scrapy.Item):
    id = scrapy.Field()
    name = scrapy.Field()
    artist = scrapy.Field()
    img = scrapy.Field()
    release_date = scrapy.Field()
    label = scrapy.Field()
    genres = scrapy.Field()
    tracks = scrapy.Field()


class Track(scrapy.Item):
    id = scrapy.Field()
    name = scrapy.Field()
    album = scrapy.Field()
    preview = scrapy.Field()
    duration = scrapy.Field()
    artist = scrapy.Field()
    genres = scrapy.Field()
