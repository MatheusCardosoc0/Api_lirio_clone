using Api.Utilities;

namespace Api.Models.Materiais
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Price { set; get; }
        public GroupProduct group { get; set; }

    }
}
