using Playing_with_MongoDb;

const string connectionString = "mongodb://127.0.0.1:27017";
const string database = "testing_db";
const string collectionName = "files";

var handler = new FileHandler<FileModel>(connectionString, database, collectionName);

//var result=await handler.UploadFile(@"C:/Users/Stefan/Desktop/Test.txt");
//Console.WriteLine(result);

var data=await handler.ReadFile("64a2c5347263a2e924cb9404");
Console.WriteLine(data);


//var person = new PersonModel
//{
//    Name = "Pesho2",
//    Description = "This is a quick description for pesho2",
//    Age = 22
//};

//if (await collection.FindAsync(x => x.Name == person.Name) == null)
//{
//    await collection.InsertOneAsync(person);
//}

//var results = await collection.FindAsync(x => true);

//await results.ForEachAsync(x => Console.WriteLine($"{x.Name} {x.Age} {x.Description}"));