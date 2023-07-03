namespace Playing_with_MongoDb
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    internal class PersonModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }= null!;

        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }= null!;

        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; } = null!;

        [BsonRequired]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Age { get; set; }

        public byte[] FileBytes { get; set; }
    }
}