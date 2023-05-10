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

        public List<MedicalRecord> GetMedicalRecord(int idSheet)
        { 
            if (idSheet <= 0) return null;
            using (var ctx = new HealthCenterDBContext())
            {
                var recordSheet = ctx.medicalrecordSheets.Where(mrs => mrs.sheet.Id == idSheet)
                                    .Include(mrs => mrs.medicalRecord).Select(mrs => mrs.medicalRecord).ToList();

                return recordSheet;
            }
        }

        public bool Update(Sheet entity)
        {
            if (entity == null) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                Sheet currentSheet = ctx.Sheets.SingleOrDefault(x => x.Id == entity.Id);
                if (currentSheet == null) return false;
                currentSheet.Nombre = entity.Nombre;
                currentSheet.Status = entity.Status;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
