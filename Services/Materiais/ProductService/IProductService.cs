using Api.Models.Materiais;

namespace Api.Services.Materiais.ProductService
{
    public interface IProductService
    {
        List<Product> Get();
        Product Get(int id);
        Product Create(Product product);
        void Update(int id, Product product);
        void Delete(int id);
    }
}
