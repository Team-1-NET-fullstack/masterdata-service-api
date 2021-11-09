﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MasterData.Service.Api.Entities
{
    public class AllergyMasters
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }

        public bool IsFatal { get; set; }
    }
    public class AllergyMasterMessage
    {
        public AllergyMasters allergyMasters { get; set; }
        public string Command { get; set; }
    }
}
