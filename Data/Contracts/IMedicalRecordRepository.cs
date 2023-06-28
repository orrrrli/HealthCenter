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
        bool RelateUser(int idMedicalRecord, int idSheet); //Permite saber donde a que usuario le pertenece esta hoja medica

        List<User> GetUsers(int idMedicalRecord); // Permite linkear con la tabla intermedio
    }
}
