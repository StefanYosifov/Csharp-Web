using MongoDB.Driver;
using Playing_with_MongoDb;

const string connectionString = "mongodb://127.0.0.1:27017";
const string database = "testing_db";
const string collectionName = "people";


var client = new MongoClient(connectionString);
var db = client.GetDatabase(collectionName);
var collection = db.GetCollection<PersonModel>(collectionName);


var person = new PersonModel
{
    Name = "Pesho2",
    Description = "This is a quick description for pesho2",
    Age = 22
};

if (await collection.FindAsync(x => x.Name == person.Name) == null)
{
    await collection.InsertOneAsync(person);
}

var results = await collection.FindAsync(x => true);

await results.ForEachAsync(x => Console.WriteLine($"{x.Name} {x.Age} {x.Description}"));