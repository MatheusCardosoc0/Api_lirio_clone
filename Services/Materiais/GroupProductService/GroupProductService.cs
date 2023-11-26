using Api.Models.Materiais;
using Api.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public GroupProduct Create(GroupProduct product)
        {
            product.Id = GeneratedIdSequence.GenerateNumericId(_groupProduct.Database, "ProductGroup");
            _groupProduct.InsertOne(product);
            return product;
        }

        public void Delete(int id)
        {
            _groupProduct.DeleteOne(groupProduct => groupProduct.Id == id);
        }

        public List<GroupProduct> Get()
        {
            return _groupProduct.Find(groupProduct => true).ToList();
        }

        public GroupProduct Get(int id)
        {
            return _groupProduct.Find(groupProduct => groupProduct.Id == id).FirstOrDefault();
        }

        public void Update(int id, GroupProduct product)
        {
            _groupProduct.ReplaceOne(groupProduct => groupProduct.Id == id, product);
        }
    }
}
