using Api.Models.Materiais;

namespace Api.Services.Materiais.ProductService
{
    public interface IProductService
    {
        List<Product> Get();
        Product Get(string id);
        Product Create(Product product);
        void Update(string id, Product product);
        void Delete(string id);
    }
}
