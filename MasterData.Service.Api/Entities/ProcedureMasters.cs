using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MasterData.Service.Api.Entities
{
    public class ProcedureMasters
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonId]
        public string ProcedureMastersId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string IsDeprecated { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedDate { get; set; }
    }
}

