using Api.Models.Utilitarios;

namespace Api.Services.Utilitarios
{
    public interface IUserSystemService
    {
        List<UserSystem> Get();
        UserSystem Get(string id);
        UserSystem Post(UserSystem userSystem);
        void Put(string id, UserSystem userSystem);
        void Delete(string id);
        UserSystem Authenticate(string username, string password);
    }
}
