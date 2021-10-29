using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.Entities
{
    public class ProcedureMasters
    {
        public string Id { get; set; }
        public string ProcedureMastersId { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string IsDeprecated { get; set; }

        public string Description { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedDate { get; set; }
    }
}

