namespace Playing_with_MongoDb
{
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class FileHandler<T>
    {
        private readonly IMongoCollection<FileModel> _collection;

        public FileHandler(
            string connectionString,
            string databaseName,
            string collectionName
        )
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<FileModel>(collectionName);
        }


        public async Task<string> UploadFile(string pathName)
        {
            var filePath = Path.GetFullPath(pathName);
            byte[] fileBytes = await File.ReadAllBytesAsync(filePath);

            var fileDocument = CreateFileDocument(pathName, fileBytes);

            try
            {
                FileModel fileModel = new FileModel()
                {
                    File = fileDocument
                };
                await _collection.InsertOneAsync(fileModel);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Upload successful";
        }

        public async Task<string> ReadFile(string id)
        {
            try
            {
                
                var fileModelCursor = await _collection.FindAsync(x => x.Id == id);
                var fileModel = await fileModelCursor.FirstOrDefaultAsync();

                if (fileModel == null)
                {
                    return "File not found";
                }
                var fileBytes = fileModel.File["data"].AsByteArray;
                var fileContent = System.Text.Encoding.Default.GetString(fileBytes);
                return fileContent;
                
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private BsonDocument CreateFileDocument(string fileName, byte[] fileBytes)
        {
            var fileDocument = new BsonDocument
            {
                { "filename", fileName },
                { "data", new BsonBinaryData(fileBytes) },
                { "timestamp", DateTime.UtcNow }
            };
            return fileDocument;
        }
    }
}