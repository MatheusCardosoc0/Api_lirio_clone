using Api.Models.Financeiro;

namespace Api.Services.Financeiro.CoinsService
{
    public interface ICoinsService
    {
        List<Coins> Get();
        Coins Get(int id);
        Coins Post(Coins coins);
        void Put(int id, Coins coins);
        void Delete(int id);
    }
}
