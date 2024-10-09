using Hospital.DAL.DataBase;
using Hospital.DAL.Entities;
using Hospital.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hospital.Repository.Implementation
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalDbContext _context;
        private bool disposed;
        public DoctorRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public List<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetDoctorById(string id)
        {
            return _context.Doctors.Find(id);
        }

        public void AddDoctor(Doctor Doctor)
        {
            _context.Doctors.Add(Doctor);
            _context.SaveChanges();
        }

        public void UpdateDoctor(Doctor Doctor)
        {
            _context.Doctors.Update(Doctor);
            _context.SaveChanges();
        }

        public void DeleteDoctor(string id)
        {
            var Doctor = GetDoctorById(id);
            if (Doctor != null)
            {
                _context.Doctors.Remove(Doctor);
                _context.SaveChanges();
            }
            
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                _context.Dispose();
            }

            disposed = true;
        }
    }
}
