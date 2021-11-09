using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterData.Service.Api.DAL
{
    public class CTGeneralHospitalDatabaseSettings: ICTGeneralHospitalDatabaseSettings
    {
        public string AllergyCollection { get; set; }
        public string MedicationCollection { get; set; }
        public string DiagnosisCollection { get; set; }
        public string ProcedureCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        }

        public interface ICTGeneralHospitalDatabaseSettings
    {
        string AllergyCollection { get; set; }
        string MedicationCollection { get; set; }
        string DiagnosisCollection { get; set; }
        string ProcedureCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        
    }
    
}
