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
        bool RelateSheet(Sheet newSheet);
        List<User> GetUsers(int idMedicalRecord);
    }
}
