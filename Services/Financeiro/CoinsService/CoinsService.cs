using Api.Models.Financeiro;
using Api.Models.Materiais;
using Api.Utilities;
using MongoDB.Driver;

namespace Api.Services.Financeiro.CoinsService
{
    public class CoinsService : ICoinsService
    {
        private readonly IMongoCollection<Coins> _coins;

        public CoinsService(ISystemDBConfiguration coinsStoreDatabaseSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(coinsStoreDatabaseSettings.DatabaseName);
            _coins = database.GetCollection<Coins>(coinsStoreDatabaseSettings.Collections.FINANCEIRO.Coins);
        }
        public void Delete(int id)
        {
            _coins.DeleteOne(coins => coins.Id == id);
        }

        public List<Coins> Get()
        {
            return _coins.Find(coins => true).ToList();
        }

        public Coins Get(int id)
        {
            return _coins.Find(coins =>  coins.Id == id).FirstOrDefault();
        }

        public Coins Post(Coins coins)
        {
            coins.Id = GeneratedIdSequence.GenerateNumericId(_coins.Database, "Coins");
            _coins.InsertOne(coins);
            return coins;
        }

        public void Put(int id, Coins coins)
        {
            _coins.ReplaceOne(coins => coins.Id == id, coins);
        }
    }
}
