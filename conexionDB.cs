using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace tst
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();

            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            var document = new BsonDocument
            {
            {"firstname", BsonValue.Create("Peter")},
            {"lastname", new BsonString("Mbanugo")},
            { "subjects", new BsonArray(new[] {"English", "Mathematics", "Physics"}) },
            { "class", "JSS 3" },
            { "age", 45}
            };

            var client = new MongoClient("mongodb+srv://ikkot:ikkot1234@cluster0-cw0gi.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("test");
            var tes = database.GetCollection<BsonDocument>("students");
            await tes.InsertOneAsync(document);
        }

    }
}
