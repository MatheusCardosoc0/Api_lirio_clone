using Api.Models.Pessoal;

namespace Api.Services.Pessoal.PersonService
{
    public interface IPersonService
    {
        List<Person> Get();
        Person Get(string id);
        Person Create(Person user);
        void Update(string id, Person user);
        void Remove(string id);
    }
}
