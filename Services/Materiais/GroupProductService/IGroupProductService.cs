using Api.Models.Materiais;

namespace Api.Services.Materiais.GrouProductService
{
    public interface IGroupProductService
    {
        List<GroupProduct> Get();
        GroupProduct Get(string id);
        GroupProduct Create( GroupProduct product);
        void Update(string id, GroupProduct product);
        void Delete(string id);
    }
}
