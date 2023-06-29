using MongoDB.Driver;

namespace Infrastructure
{
    public class Context
    {
        private readonly IMongoDatabase _database;

        public Context(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName) 
        { 
            return _database.GetCollection<T>(collectionName);
        }
    }
}
