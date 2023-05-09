using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        ICollection<MedicalRecord> GetMedicalRecords(int idUser);
        User Login(string username, string password);
        bool RelateMedicalRecords(int idUser, int idMedicalRecord);

    }
}
