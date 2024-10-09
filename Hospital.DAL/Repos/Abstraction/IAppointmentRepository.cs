using Hospital.DAL.Entities;
using System.Collections.Generic;

namespace Hospital.Repository.Abstractions
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAllAppointments();
        Appointment GetAppointmentById(int id);
        void AddAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int id);
        void Dispose();
    }
}
