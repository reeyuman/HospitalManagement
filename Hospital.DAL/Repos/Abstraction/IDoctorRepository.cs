using Hospital.DAL.Entities;
using System.Collections.Generic;

namespace Hospital.Repository.Abstractions
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAllDoctors();
        Doctor GetDoctorById(string id);
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(string id);
        void Dispose();
    }
}
