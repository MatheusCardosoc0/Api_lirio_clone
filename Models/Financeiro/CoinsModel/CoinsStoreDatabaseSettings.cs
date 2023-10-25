namespace Api.Models.Financeiro.CoinsModel
{
    public class CoinsStoreDatabaseSettings : ICoinsStoreDatabaseSettings
    {
        public string CoinsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
