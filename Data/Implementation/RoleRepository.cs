using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        public int Add(Domain.Model.Role entity)
        {
            if (entity == null) return 0;
            using (var ctx = new HealthCenterDBContext())
            {
                ctx.Roles.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }

        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                Domain.Model.Role currentRole = ctx.Roles.SingleOrDefault(x => x.Id == id);
                if (currentRole == null) return false;
                ctx.Roles.Remove(currentRole);
                ctx.SaveChanges();
                return true;
            }
        }

        public Domain.Model.Role Get(int id)
        {
            if (id <= 0) return null;
            using (var ctx = new HealthCenterDBContext())
            {
                Domain.Model.Role currentRole = ctx.Roles.SingleOrDefault(x => x.Id == id);
                return currentRole;
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
                var project = ctx.MedicalRecords.SingleOrDefault(x => x.Id == idRole);
                //validamos si existe
                if (user == null || project == null) return false;

                var existingRelation = ctx.UserRecords.SingleOrDefault(up => up.User.Id == idUser && up.medicalRecord.Id == idRole);
                if (existingRelation != null) return true; // checamos si ya existe la relacion y la validamos

                //Creamos el nuevo objeto
                var userProject = new UserRecord { User = user, medicalRecord = project };
                ctx.UserRecords.Add(userProject);
                ctx.SaveChanges();
            }
            return true;
        }

        public bool Update(Role entity)
        {
            if (entity == null) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                Role currentRole = ctx.Roles.SingleOrDefault(x => x.Id == entity.Id);
                if (currentRole == null) return false;
                currentRole.Name = entity.Name;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
