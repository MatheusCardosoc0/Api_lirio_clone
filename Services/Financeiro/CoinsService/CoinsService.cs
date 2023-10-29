using Api.Models.Financeiro;
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
        public void Delete(string id)
        {
            _coins.DeleteOne(coins => coins.Id == id);
        }

        public List<Coins> Get()
        {
            return _coins.Find(coins => true).ToList();
        }

        public Coins Get(string id)
        {
            return _coins.Find(coins =>  coins.Id == id).FirstOrDefault();
        }

        public Coins Post(Coins coins)
        {
            _coins.InsertOne(coins);
            return coins;
        }

        public void Put(string id, Coins coins)
        {
            _coins.ReplaceOne(coins => coins.Id == id, coins);
        }
    }
}
