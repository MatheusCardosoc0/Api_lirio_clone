using Api.Models.Financeiro;
using Api.Models.Materiais;
using Api.Utilities;
using MongoDB.Driver;

namespace Api.Services.Materiais.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _products;
        public ProductService(ISystemDBConfiguration settings, IMongoClient mongoclient)
        {
            var database = mongoclient.GetDatabase(settings.DatabaseName);
            _products = database.GetCollection<Product>(settings.Collections.MATERIAIS.Product);
        }
        public Product Create(Product product)
        {
            product.Id = GeneratedIdSequence.GenerateNumericId(_products.Database, "Product");
            _products.InsertOne(product);
            return product;
        }

        public void Delete(int id)
        {
            _products.DeleteOne(product => product.Id == id);
        }

        public List<Product> Get()
        {
            return _products.Find(product => true).ToList();
        }
        public Product Get(int id)
        {
            return _products.Find(product => product.Id == id).FirstOrDefault();
        }

        public void Update(int id, Product product)
        {
            _products.ReplaceOne(product => product.Id == id, product);
        }
    }
}
