using Api.Models.GroupModel;
using MongoDB.Driver;

namespace Api.Services.Group
{
    public class GroupService : IGroupService
    {
        private readonly IMongoCollection<Models.GroupModel.Group> _group;

        public GroupService(IGroupStoreDatbaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _group = database.GetCollection<Models.GroupModel.Group>(settings.GroupCollectionName);
        }

        public Models.GroupModel.Group Create(Models.GroupModel.Group group)
        {
            _group.InsertOne(group);
            return group;
        }

        public List<Models.GroupModel.Group> Get()
        {
            return _group.Find(group => true).ToList();
        }

        public Models.GroupModel.Group Get(string id)
        {
            return _group.Find(group => group.Id == id ).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _group.DeleteOne(group => group.Id == id);
        }

        public void Update(string id, Models.GroupModel.Group group)
        {
            _group.ReplaceOne(group => group.Id == id, group);
        }
    }
}
