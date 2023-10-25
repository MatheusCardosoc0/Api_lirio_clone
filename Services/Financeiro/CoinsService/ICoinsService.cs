using Api.Models.Financeiro.CoinsModel;

namespace Api.Services.Financeiro.CoinsService
{
    public interface ICoinsService
    {
        List<Coins> Get();
        Coins Get(string id);
        Coins Post(Coins coins);
        void Put(string id, Coins coins);
        void Delete(string id);
    }
}
