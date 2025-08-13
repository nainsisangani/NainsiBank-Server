using MongoDB.Bson;
using MongoDB.Driver;
namespace CommBank_Server.Services
{

    public class MongoDbService
    {
        private readonly IMongoDatabase _database;
        public MongoDbService(IConfiguration config)
        {
            var connectionUri = config.GetSection("CommBankDatabase:ConnectionString").Value;

            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            settings.ServerSelectionTimeout = TimeSpan.FromSeconds(60);

            var client = new MongoClient(settings);

            try
            {
                client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("✅ Connected to MongoDB");
            }
            catch (Exception ex)
            {
                Console.WriteLine("🛑 Connection failed: " + ex.Message);
            }

            _database = client.GetDatabase(config.GetSection("CommBankDatabase:DatabaseName").Value);
        }

        public IMongoCollection<BsonDocument> GetCollection(string name) => _database.GetCollection<BsonDocument>(name);
    }

}
