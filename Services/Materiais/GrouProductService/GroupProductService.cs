using Api.Models.Materiais;
using Api.Utilities;
using MongoDB.Driver;

namespace Api.Services.Materiais.GrouProductService
{
    public class GroupProductService : IGroupProductService
    {
        private readonly IMongoCollection<GroupProduct> _groupProduct;

        public GroupProductService(ISystemDBConfiguration settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _groupProduct = database.GetCollection<GroupProduct>(settings.Collections.MATERIAIS.GroupProduct);
        }
        public GroupProduct Create( GroupProduct product)
        {
            _groupProduct.InsertOne(product);
            return product;
        }

        public void Delete(string id)
        {
            _groupProduct.DeleteOne(groupProduct => groupProduct.Id == id);
        }

        public List<GroupProduct> Get()
        {
            return _groupProduct.Find(groupProduct => true).ToList();
        }

        public GroupProduct Get(string id)
        {
            return _groupProduct.Find(groupProduct => groupProduct.Id == id).FirstOrDefault();
        }

        public void Update(string id, GroupProduct product)
        {
            _groupProduct.ReplaceOne(groupProduct => groupProduct.Id == id, product);
        }
    }
}
