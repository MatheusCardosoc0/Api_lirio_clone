using Api.Models.PersonModel;

namespace Api.Services.Pessoal.PersonService
{
    public interface IPersonService
    {
        List<Person> Get();
        Person Get(string id);
        Person Create(Models.PersonModel.Person user);
        void Update(string id, Person user);
        void Remove(string id);
    }
}
