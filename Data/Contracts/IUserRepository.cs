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
        User Login(string username, string password);
        ICollection<MedicalRecord> GetMedicalRecords(int idUser);
        
        bool RelateMedicalRecords(int idUser, int idMedicalRecord);

        ICollection<Role> GetRole(int idUser);

        bool RelateRole(int idUser, int idRole);


    }
}
