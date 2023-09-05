using MongoDB.Bson;

namespace Api.Utilities
{
    public class GeneratedId
    {
        public static string GenerateUniqueStringId()
        {
            return ObjectId.GenerateNewId().ToString();
        }
    }
}
