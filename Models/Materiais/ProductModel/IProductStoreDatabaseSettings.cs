namespace Api.Models.Materiais.ProductModel
{
    public interface IProductStoreDatabaseSettings
    {
        string ProductCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
