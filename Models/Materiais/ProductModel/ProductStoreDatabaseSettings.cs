namespace Api.Models.Materiais.ProductModel
{
    public class ProductStoreDatabaseSettings : IProductStoreDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
