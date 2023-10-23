using Api.Models.Materiais.ProductModel;
using MongoDB.Driver;

namespace Api.Services.Materiais.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _products;
        public ProductService(IProductStoreDatabaseSettings settings, IMongoClient mongoclient)
        {
            var database = mongoclient.GetDatabase(settings.DatabaseName);
            _products = database.GetCollection<Product>(settings.ProductCollectionName);
        }
        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Delete(string id)
        {
            _products.DeleteOne(product => product.Id == id);
        }

        public List<Product> Get()
        {
            return _products.Find(product => true).ToList();
        }
        public Product Get(string id)
        {
            return _products.Find(product => product.Id == id).FirstOrDefault();
        }

        public void Update(string id, Product product)
        {
            _products.ReplaceOne(product => product.Id == id, product);
        }
    }
}
