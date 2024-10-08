using Hospital.DAL.Entities;
using System.Collections.Generic;

namespace Hospital.Repository.Abstractions
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients();
        Patient GetPatientById(string id);
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(string id);
    }
}
