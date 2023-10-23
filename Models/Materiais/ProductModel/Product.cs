using Api.Models.Materiais.GroupProductModel;
using Api.Utilities;

namespace Api.Models.Materiais.ProductModel
{
    public class Product
    {
        public string Id { set; get; } = GeneratedId.GenerateUniqueStringId();
        public string Name { set; get; }
        public string Description { set; get; }
        public string Price { set; get; }
        public GroupProduct group { get; set; }

    }
}
