using Hospital.DAL.DataBase;
using Hospital.DAL.Entities;
using Hospital.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hospital.Repository.Implementation
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly HospitalDbContext _context;

        public MedicalRecordRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public List<MedicalRecord> GetAllMedicalRecords()
        {
            return _context.MedicalRecords.Include(m => m.Patient).Include(m => m.Staff).ToList();
        }

        public MedicalRecord GetMedicalRecordById(int id)
        {
            return _context.MedicalRecords.Include(m => m.Patient).Include(m => m.Staff)
                                           .FirstOrDefault(m => m.MedicalRecordID == id);
        }

        public void AddMedicalRecord(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Add(medicalRecord);
            _context.SaveChanges();
        }

        public void UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Update(medicalRecord);
            _context.SaveChanges();
        }

        public void DeleteMedicalRecord(int id)
        {
            var medicalRecord = GetMedicalRecordById(id);
            if (medicalRecord != null)
            {
                _context.MedicalRecords.Remove(medicalRecord);
                _context.SaveChanges();
            }
        }
    }
}
