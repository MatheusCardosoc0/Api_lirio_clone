using Api.Models.Materiais.ProductModel;
using Api.Models.PersonModel;

namespace Api.Models.Vendas.CounterSales
{
    public class CounterSales
    {
        public string Id { get; set; }
        public Product Product { get; set; }
        public Person Person { get; set; }
        public float Discount { get; set; }
        public string TotalValue { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; } = string.Empty;
    }
}
