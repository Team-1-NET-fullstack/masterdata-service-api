using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.Entities
{
    public class MedicationMasters
    {
        
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; set; }
        
        //public string MedicationMastersId { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }

        public string Dosage { get; set; }
        public bool IsDeprecated { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }

        //public string CreatedDate { get; set; }

        //public string CreatedBy { get; set; }

        //public string UpdatedBy { get; set; }

        //public string UpdatedDate { get; set; }
    }
}

