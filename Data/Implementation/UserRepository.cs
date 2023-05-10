using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        public int Add(User entity)
        {
            if (entity == null) return 0;
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = null;
            using (var ctx = new HealthCenterDBContext())
            {
                ctx.Users.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }

        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                User currentUser = ctx.Users.SingleOrDefault(x => x.Id == id);
                if (currentUser == null) return false;
                ctx.Users.Remove(currentUser);
                ctx.SaveChanges();
                return true;
            }
        }

        public User Get(int id)
        {
            if (id <= 0) return null;
            using (var ctx = new HealthCenterDBContext())
            {
                User currentUser = ctx.Users.SingleOrDefault(x => x.Id == id);
                return currentUser;
            }
        }


        public ICollection<Role> GetRole (int idUser)
        {
            if (idUser <= 0) return null;
            using (var ctx = new HealthCenterDBContext())
            {
                var userRoles= ctx.UserRoles.Where(urol => urol.theUser.Id == idUser)
                                    .Include(ur => ur.theRole).Select(ur => ur.theRole).ToList();
                return userRoles;
            }
        }

        public bool RelateRole(int idUser, int idRole)
        {
            if (idUser <= 0) return false;
            if (idRole <= 0) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                //Obtenemos elusuario y el proyecto a relacionar
                var user = ctx.Users.SingleOrDefault(x => x.Id == idUser);
                var role = ctx.Roles.SingleOrDefault(x => x.Id == idRole);
                //validamos si existe
                if (user == null || role == null) return false;

                var existingRelation = ctx.UserRoles.SingleOrDefault(ur=> ur.theUser.Id == idUser && ur.theRole.Id == idRole);
                if (existingRelation != null) return true; // checamos si ya existe la relacion y la validamos

                //Creamos el nuevo objeto
                var userRole = new UserRole { theUser = user, theRole = role };
                ctx.UserRoles.Add(userRole);
                ctx.SaveChanges();
            }
            return true;
        }
        public ICollection<MedicalRecord> GetMedicalRecords(int idUser)
        {
            if (idUser <= 0) return null;
            using (var ctx = new HealthCenterDBContext())
            {
                var userProjects = ctx.UserRecords.Where(ur => ur.User.Id == idUser)
                                    .Include(ur => ur.medicalRecord).Select(ur => ur.medicalRecord).ToList();

                return userProjects;
            }
        }

        public bool RelateMedicalRecords(int idUser, int idMedicalRecord)
        {
            if (idUser <= 0) return false;
            if (idMedicalRecord <= 0) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                //Obtenemos elusuario y el proyecto a relacionar
                var user = ctx.Users.SingleOrDefault(x => x.Id == idUser);
                var medicalRecord = ctx.MedicalRecords.SingleOrDefault(x => x.Id == idMedicalRecord);
                //validamos si existe
                if (user == null || medicalRecord == null) return false;

                var existingRelation = ctx.UserRecords.SingleOrDefault(ur => ur.User.Id == idUser && ur.medicalRecord.Id == idMedicalRecord);
                if (existingRelation != null) return true; // checamos si ya existe la relacion y la validamos

                //Creamos el nuevo objeto
                var userMedicalRecord = new UserRecord { User = user, medicalRecord = medicalRecord };
                ctx.UserRecords.Add(userMedicalRecord);
                ctx.SaveChanges();
            }
            return true;
        }

        public bool Update(User entity)
        {
            if (entity == null) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                User currentUser = ctx.Users.SingleOrDefault(x => x.Id == entity.Id);
                if (currentUser == null) return false;
                currentUser.ModifiedDate = DateTime.Now;
                currentUser.UserName = entity.UserName;
                currentUser.Password = entity.Password;
                currentUser.Email = entity.Email;
                currentUser.Name = entity.Name;
                currentUser.Phone = entity.Phone;
                ctx.SaveChanges();
                return true;
            }
        }

        public User Login(string username, string password)
        {
            if (username == null || password == null) return null;
            using (var ctx = new HealthCenterDBContext())
            {
                User currentUser = ctx.Users.Where(u => u.Email == username && u.Password == password).FirstOrDefault();
                return currentUser;
            }

        }

    }
}
