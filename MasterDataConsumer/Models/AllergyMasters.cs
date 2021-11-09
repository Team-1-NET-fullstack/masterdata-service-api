using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataConsumer.Models
{
    public class AllergyMasters
    {

        public string Id { get; set; }

        public string Description { get; set; }

        public bool IsFatal { get; set; }
    }
    public class AllergyMasterMessage
    {
        public AllergyMasters allergyMasters { get; set; }
        public string Command { get; set; }
    }
}

