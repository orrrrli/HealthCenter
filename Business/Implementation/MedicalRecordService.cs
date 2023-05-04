using Data.Contracts;
using Business.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Business.Implementation
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;

        }

        public int Add(MedicalRecord medicalRecord)
        {
            if (medicalRecord.Id <= 0) return 0;
            if (string.IsNullOrEmpty(medicalRecord.Name)) return 0;
            return _medicalRecordRepository.Add(medicalRecord);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _medicalRecordRepository.Delete(id);
        }

        public MedicalRecord Get(int id)
        {
            MedicalRecord u = _medicalRecordRepository.Get(id);
            return u;
        }

        public List<User> GetUsers(int idMedicalRecord)
        {
            if (idMedicalRecord <= 0) return null;
            return _medicalRecordRepository.GetUsers(idMedicalRecord);

        }

        public bool RelateSheet(int idMedicalRecord, int idSheet)
        {
            if (idMedicalRecord <= 0) return false;
            if (idSheet <= 0) return false;
            return _medicalRecordRepository.RelateSheet(idMedicalRecord, idSheet);
        }

        public bool Update(MedicalRecord medicalRecord)
        {
            if (medicalRecord.Id <= 0) return false;
            return _medicalRecordRepository.Update(medicalRecord);
        }
    }
}