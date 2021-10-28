using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.DAL
{
    public class CTGeneralHospitalDatabaseSettings: ICTGeneralHospitalDatabaseSettings
    {
        
            public string CTGeneralHospitalCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public interface ICTGeneralHospitalDatabaseSettings
    {
            string CTGeneralHospitalCollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }
    
}
