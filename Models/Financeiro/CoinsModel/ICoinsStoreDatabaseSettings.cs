namespace Api.Models.Financeiro.CoinsModel
{
    public interface ICoinsStoreDatabaseSettings
    {
        string CoinsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
