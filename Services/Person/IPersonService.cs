namespace Api.Services.Person
{
    public interface IPersonService
    {
        List<Models.PersonModel.Person> Get();
        Models.PersonModel.Person Get(string id);
        Models.PersonModel.Person Create(Models.PersonModel.Person user);
        void Update(string id, Models.PersonModel.Person user);
        void Remove(string id);
    }
}
