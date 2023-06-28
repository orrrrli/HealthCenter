using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Contracts;
using Domain;
using Domain.Model;

namespace Data.Implementation
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        public int Add(MedicalRecord entity)
        {
            if (entity == null) return 0;
            entity.CreatedDate = DateTime.Now;
            using (var ctx = new HealthCenterDBContext())
            {
                ctx.MedicalRecords.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                MedicalRecord currentMedicalRecord = ctx.MedicalRecords.SingleOrDefault(m => m.Id == id);
                if (currentMedicalRecord == null) return false;
                ctx.MedicalRecords.Remove(currentMedicalRecord);
                ctx.SaveChanges();
                return true;

            }
        }
        public MedicalRecord Get(int id)
        {
            if (id <=0) return null;
            using ( var ctx = new HealthCenterDBContext())
            {
                MedicalRecord currentMedicalRecord = ctx.MedicalRecords.SingleOrDefault(m => m.Id == id);
                return currentMedicalRecord;            }
        }

        public List <User> GetUsers(int idMedicalRecord)
        {
            if (idMedicalRecord <=0) return null;
            using (var ctx = new HealthCenterDBContext())
            {
                var medicalRecordUsers = ctx.UserRecords.Where(ur=>ur.medicalRecord.Id==idMedicalRecord)
                    .Include(ur=> ur.User).Select(ur=>ur.User).ToList();
                return medicalRecordUsers;
            }
        }


        public bool RelateUser(int idMedicalRecord, int idUser)
        {
            if (idMedicalRecord <= 0) return false;
            if (idUser <= 0) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                //Obtenemos elusuario y el proyecto a relacionar
                var record = ctx.MedicalRecords.SingleOrDefault(x => x.Id == idMedicalRecord);
                var user = ctx.Users.SingleOrDefault(x => x.Id == idUser);
                //validamos si existe
                if (record == null || user == null) return false;

                var existingRelation = ctx.UserRecords.SingleOrDefault(ur => ur.medicalRecord.Id == idMedicalRecord && ur.User.Id == idUser);
                if (existingRelation != null) return true; // checamos si ya existe la relacion y la validamos

                //Creamos el nuevo objeto
                var medicalrecordUser = new UserRecord { medicalRecord = record , User = user };
                ctx.UserRecords.Add(medicalrecordUser);
                ctx.SaveChanges();
            }
            return true;

        }

        public bool Update(MedicalRecord entity)
        {
            if (entity == null) return false;
            using (var ctx = new HealthCenterDBContext())
            {
                MedicalRecord currentMedicalRecord = ctx.MedicalRecords.SingleOrDefault(x => x.Id == entity.Id);
                if (currentMedicalRecord == null) return false;
                currentMedicalRecord.Name = entity.Name;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
