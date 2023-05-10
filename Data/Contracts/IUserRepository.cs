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

        //Conecta con la tabla de medical record

        ICollection<MedicalRecord> GetMedicalRecords(int idUser); //Obtiene los Medical Records APARTIR DE USER
        
        bool RelateMedicalRecords(int idUser, int idMedicalRecord);

        //Conecta con la tabla de roles

        ICollection<Role> GetRole(int idUser); // Obtiene los Roles APARTIR DE USER

        bool RelateRole(int idUser, int idRole);


    }
}
