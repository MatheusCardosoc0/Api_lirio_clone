using Api.Models.Utilitarios;

namespace Api.Services.Utilitarios
{
    public interface IUserSystemService
    {
        List<UserSystem> Get();
        UserSystem Get(int id);
        UserSystem Post(UserSystem userSystem);
        void Put(int id, UserSystem userSystem);
        void Delete(int id);
        UserSystem Authenticate(string username, string password);
    }
}
