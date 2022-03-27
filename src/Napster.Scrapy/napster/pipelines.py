# Define your item pipelines here
#
# Don't forget to add your pipeline to the ITEM_PIPELINES setting
# See: https://docs.scrapy.org/en/latest/topics/item-pipeline.html


# useful for handling different item types with a single interface
import json
import pymongo
from itemadapter import ItemAdapter
from scrapy.exceptions import DropItem

from napster.items import Album, Artist, Genre


class NapsterPipeline:
    def process_item(self, item, spider):
        return item


class JsonWriterPipeline:

    def open_spider(self, spider):
        self.file = open('napster.jl', 'w')

    def close_spider(self, spider):
        self.file.close()

    def process_item(self, item, spider):
        line = json.dumps(ItemAdapter(item).asdict()) + "\n"
        self.file.write(line)
        return item


class DuplicateItemsPipeline:

    def __init__(self):
        self.ids_seen = set()

    def process_item(self, item, spider):
        if item['id'] in self.ids_seen:
            raise DropItem(f"Duplicate item found: {item['id']!r}")
        else:
            self.ids_seen.add(item['id'])
            return item


class MongoPipeline:

    genre_collection = 'genres'
    artist_collection = 'artists'
    album_collection = 'albums'
    track_collection = 'tracks'

    def __init__(self, mongo_uri, mongo_db):
        self.mongo_uri = mongo_uri
        self.mongo_db = mongo_db

    @classmethod
    def from_crawler(cls, crawler):
        return cls(
            mongo_uri=crawler.settings.get('MONGO_URI'),
            mongo_db=crawler.settings.get('MONGO_DATABASE', 'napster')
        )

    def open_spider(self, spider):
        self.client = pymongo.MongoClient(self.mongo_uri)
        self.db = self.client[self.mongo_db]

    def close_spider(self, spider):
        self.client.close()

    def process_item(self, item, spider):
        collection = self.genre_collection
        if isinstance(item, Genre):
            collection = self.genre_collection
        elif isinstance(item, Artist):
            collection = self.artist_collection
        elif isinstance(item, Album):
            collection = self.album_collection
            for i in item['tracks']:
                self.db[self.track_collection].insert_one(
                    ItemAdapter(i).asdict())

        self.db[collection].insert_one(ItemAdapter(item).asdict())
        return item
