namespace Playing_with_MongoDb
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class FileModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("file")]
        public BsonDocument File { get; set; }
    }
}
