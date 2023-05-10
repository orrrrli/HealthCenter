using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IMedicalRecordRepository : IGenericRepository<MedicalRecord>
    {

        ICollection<Sheet> GetSheets(int idMedicalRecord); //Obtiene las sheet APARTIR DEL RECORD

        bool RelateSheet(int idMedicalRecord, int idSheet);


        List<User> GetUsers(int idMedicalRecord); // Permite linkear con la tabla intermedio
    }
}
