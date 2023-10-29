using Api.Models.Pessoal;
using Api.Utilities;
using MongoDB.Driver;

namespace Api.Services.Pessoal.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly IMongoCollection<Group> _group;

        public GroupService(ISystemDBConfiguration settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _group = database.GetCollection<Group>(settings.Collections.PESSOAL.Group);
        }

        public Group Create(Group group)
        {
            _group.InsertOne(group);
            return group;
        }

        public List<Group> Get()
        {
            return _group.Find(group => true).ToList();
        }

        public Group Get(string id)
        {
            return _group.Find(group => group.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _group.DeleteOne(group => group.Id == id);
        }

        public void Update(string id, Group group)
        {
            _group.ReplaceOne(group => group.Id == id, group);
        }
    }
}
