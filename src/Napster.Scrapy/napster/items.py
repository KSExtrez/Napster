# Define here the models for your scraped items
#
# See documentation in:
# https://docs.scrapy.org/en/latest/topics/items.html
import scrapy


class Genre(scrapy.Item):
    Id = scrapy.Field()
    Name = scrapy.Field()
    Description = scrapy.Field()
    ParentGenreId = scrapy.Field()


class Artist(scrapy.Item):
    Id = scrapy.Field()
    Name = scrapy.Field()
    Description = scrapy.Field()
    Img = scrapy.Field()
    GenreIds = scrapy.Field()


class Album(scrapy.Item):
    Id = scrapy.Field()
    Name = scrapy.Field()
    ArtistId = scrapy.Field()
    Img = scrapy.Field()
    ReleaseDate = scrapy.Field()
    Label = scrapy.Field()
    GenreIds = scrapy.Field()
    Tracks = scrapy.Field()
    trackDetails = []


class Track(scrapy.Item):
    Id = scrapy.Field()
    Name = scrapy.Field()
    AlbumId = scrapy.Field()
    Preview = scrapy.Field()
    Duration = scrapy.Field()
    ArtistId = scrapy.Field()
    GenreIds = scrapy.Field()
