using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.DAL
{
    public class CTGeneralHospitalDatabaseSettings: ICTGeneralHospitalDatabaseSettings
    {
        public string CTGeneralHospitalCollectionName1 { get; set; }
        public string CTGeneralHospitalCollectionName2 { get; set; }
        public string CTGeneralHospitalCollectionName3 { get; set; }
        public string CTGeneralHospitalCollectionName4 { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        }

        public interface ICTGeneralHospitalDatabaseSettings
    {
        string CTGeneralHospitalCollectionName1 { get; set; }
        string CTGeneralHospitalCollectionName2 { get; set; }
        string CTGeneralHospitalCollectionName3 { get; set; }
        string CTGeneralHospitalCollectionName4 { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        }
    
}
