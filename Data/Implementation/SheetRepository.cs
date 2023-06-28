using Data.Contracts;
using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class SheetRepository : ISheetRepository
    {
        public int Add(Sheet entity)
        {
            if (entity == null) return 0;
            using (var ctx = new HealthCenterDBContext())
            {
                ctx.Sheets.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                Sheet currentSheet = ctx.Sheets.SingleOrDefault(x => x.Id == id);
                if (currentSheet == null) return false;
                ctx.Sheets.Remove(currentSheet);
                ctx.SaveChanges();
                return true;
            }
        }

        public Sheet Get(int id)
        {
            if (id <= 0) return null;
            using (var ctx = new HealthCenterDBContext())
            {
                Sheet currentSheet = ctx.Sheets.SingleOrDefault(x => x.Id == id);
                return currentSheet;
            }
        }

        public List<User> GetUsers(int idSheet)
        {
            if (idSheet <= 0) return null;
            using (var ctx = new HealthCenterDBContext())
            {
                var UserSheet = ctx.UserSheets.Where(ur => ur.sheet.Id == idSheet)
                    .Include(ur => ur.user).Select(ur => ur.user).ToList();
                return UserSheet;
            }
        }

        public bool RelateUser(int idUser, int idSheet)
        {
            if (idSheet <= 0) return false;
            if (idUser <= 0) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                //Obtenemos elusuario y el proyecto a relacionar
                var sheet = ctx.Sheets.SingleOrDefault(x => x.Id == idSheet);
                var user = ctx.Users.SingleOrDefault(x => x.Id == idUser);
                //validamos si existe
                if (sheet == null || user == null) return false;

                var existingRelation = ctx.UserSheets.SingleOrDefault(ur => ur.sheet.Id == idSheet && ur.user.Id == idUser);
                if (existingRelation != null) return true; // checamos si ya existe la relacion y la validamos

                //Creamos el nuevo objeto
                var sheetUser = new UserSheets { sheet = sheet, user = user };
                ctx.UserSheets.Add(sheetUser);
                ctx.SaveChanges();
            }
            return true;
        }

        public bool Update(Sheet entity)
        {
            if (entity == null) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                Sheet currentSheet = ctx.Sheets.SingleOrDefault(x => x.Id == entity.Id);
                if (currentSheet == null) return false;
                currentSheet.heartDisease = entity.heartDisease;
                currentSheet.liverDiseases = entity.liverDiseases;
                currentSheet.mellitusDiabetes = entity.mellitusDiabetes;
                currentSheet.chronicRenalFailure = entity.chronicRenalFailure;
                currentSheet.arterialHypertension = entity.arterialHypertension;
              
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
