using Business.Contracts;
using Data.Contracts;
using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public int Add(User user)
        {
            if (user.Id <= 0) return 0;
            if (string.IsNullOrEmpty(user.Email)) return 0;
            if (string.IsNullOrEmpty(user.Password)) return 0;
            return _userRepo.Add(user);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (_userRepo.Delete(id));
        }

        public User Get(int id)
        {
            User u = _userRepo.Get(id);
            return u;
        }

        public bool Update(User user)
        {
            if (user.Id <= 0) return false;
            if (string.IsNullOrEmpty(user.Name)) return false;
            if (user.Phone <= 0) return false;
            if (string.IsNullOrEmpty(user.Email)) return false;
            if (string.IsNullOrEmpty(user.Password)) return false;
            if (string.IsNullOrEmpty(user.UserName)) return false;
            return _userRepo.Update(user);
        }

        //Relate medical records
        public bool RelateMedicalRecords(int idUser, int idMedicalRecord)
        {
            if (idUser <= 0) return false;
            if (idMedicalRecord <= 0) return false;
            return _userRepo.RelateMedicalRecords(idUser, idMedicalRecord);
        }
        public ICollection<MedicalRecord> GetMedicalRecords(int idUser)
        {
            if (idUser <= 0) return null;
            List<MedicalRecord> medicalrecordList = _userRepo.GetMedicalRecords(idUser).ToList();
            return medicalrecordList;
        }

        //Relate role

        public bool RelateRole(int idUser, int idRole)
        {
            if (idUser <= 0) return false;
            if (idRole <= 0) return false;
            return _userRepo.RelateRole(idUser, idRole);
        }
        public ICollection<Role> GetRole(int idUser)
        {
            if (idUser <= 0) return null;
            List<Role> roleList = _userRepo.GetRole(idUser).ToList();
            return roleList;
        }



        public User Login(string username, string password)
        {
            if (username == null || password == null) return null;
            return _userRepo.Login(username, password);
        }

    }
}