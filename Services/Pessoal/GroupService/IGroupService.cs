using Api.Models.Pessoal;

namespace Api.Services.Pessoal.GroupService
{
    public interface IGroupService
    {
        List<Group> Get();
        Group Get(int id);
        Group Create(Group user);
        void Update(int id, Group user);
        void Remove(int id);
    }
}
