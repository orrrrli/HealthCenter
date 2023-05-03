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

        public ICollection<MedicalRecord> GetMedicalRecords(int idUser)
        {
            if (idUser <= 0) return null;
            using (var ctx = new HealthCenterDBContext())
            {
                var userProjects = ctx.UserRecords.Where(up => up.User.Id == idUser)
                                    .Include(up => up.medicalRecord).Select(up => up.medicalRecord).ToList();

                return userProjects;
            }
        }

        public bool RelateProject(int idUser, int idProject)
        {
            if (idUser <= 0) return false;
            if (idProject <= 0) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                //Obtenemos elusuario y el proyecto a relacionar
                var user = ctx.Users.SingleOrDefault(x => x.Id == idUser);
                var project = ctx.MedicalRecords.SingleOrDefault(x => x.Id == idProject);
                //validamos si existe
                if (user == null || project == null) return false;

                var existingRelation = ctx.UserRecords.SingleOrDefault(up => up.User.Id == idUser && up.medicalRecord.Id == idProject);
                if (existingRelation != null) return true; // checamos si ya existe la relacion y la validamos

                //Creamos el nuevo objeto
                var userProject = new UserRecord { User = user, medicalRecord = project };
                ctx.UserRecords.Add(userProject);
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
