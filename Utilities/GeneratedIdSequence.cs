using MongoDB.Driver;
using MongoDB.Bson;

namespace Api.Utilities
{
    public class GeneratedIdSequence
    {
        public static int GenerateNumericId(IMongoDatabase database, string countId)
        {
            var collection = database.GetCollection<BsonDocument>("counters");
            var update = Builders<BsonDocument>.Update.Inc("seq", 1);
            var options = new FindOneAndUpdateOptions<BsonDocument, BsonDocument>
            {
                ReturnDocument = ReturnDocument.After,
                IsUpsert = true
            };
            var document = collection.FindOneAndUpdate(
                new BsonDocument("_id", countId),
                update,
                options
            );
            return document["seq"].AsInt32;
        }
    }
}
