namespace Api.Services.Pessoal.GroupService
{
    public interface IGroupService
    {
        List<Models.GroupModel.Group> Get();
        Models.GroupModel.Group Get(string id);
        Models.GroupModel.Group Create(Models.GroupModel.Group user);
        void Update(string id, Models.GroupModel.Group user);
        void Remove(string id);
    }
}
