using Hospital.DAL.DataBase;
using Hospital.DAL.Entities;
using Hospital.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hospital.Repository.Implementation
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalDbContext _context;

        private bool disposed;
        public AppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public List<Appointment> GetAllAppointments()
        {
            return _context.Appointments.Include(a => a.Patient).Include(a => a.Doctor).ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments.Include(a => a.Patient).Include(a => a.Doctor)
                                         .FirstOrDefault(a => a.AppointmentID == id);
        }

        public void AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public void DeleteAppointment(int id)
        {
            var appointment = GetAppointmentById(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
        }

        List<Appointment> IAppointmentRepository.GetAllAppointments()
        {
            throw new NotImplementedException();
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
