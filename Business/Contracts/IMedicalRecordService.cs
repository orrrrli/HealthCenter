using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IMedicalRecordService
    {
        int Add(MedicalRecord medicalRecord);
        MedicalRecord Get(int id);
        bool Update(MedicalRecord medicalRecord);

        bool Delete(int id);

        //RelateUser
        bool RelateUser(int idMedicalRecord, int idUser);

        ICollection<User> GetUser(int IdUser);
    }
}
