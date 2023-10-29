using Api.Models.Pessoal;

namespace Api.Services.Pessoal.GroupService
{
    public interface IGroupService
    {
        List<Group> Get();
        Group Get(string id);
        Group Create(Group user);
        void Update(string id, Group user);
        void Remove(string id);
    }
}
