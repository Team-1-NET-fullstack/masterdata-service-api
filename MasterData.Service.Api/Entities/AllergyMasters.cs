using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MasterData.Service.Api.Entities
{
    public class AllergyMasters
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        public string AllergyMastersId { get; set; }

        public string Description { get; set; }

        public string IsFatal { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedDate { get; set; }
    }
}
