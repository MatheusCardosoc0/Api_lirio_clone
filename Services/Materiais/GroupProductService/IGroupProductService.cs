using Api.Models.Materiais;

namespace Api.Services.Materiais.GrouProductService
{
    public interface IGroupProductService
    {
        List<GroupProduct> Get();
        GroupProduct Get(int id);
        GroupProduct Create( GroupProduct product);
        void Update(int id, GroupProduct product);
        void Delete(int id);
    }
}
