using Api.Models.Pessoal;

namespace Api.Services.Pessoal.PersonService
{
    public interface IPersonService
    {
        List<Person> Get();
        Person Get(int id);
        Person Create(Person user);
        void Update(int id, Person user);
        void Remove(int id);
    }
}
