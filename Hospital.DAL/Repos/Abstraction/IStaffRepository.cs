using Hospital.DAL.Entities;
using System.Collections.Generic;

namespace Hospital.Repository.Abstractions
{
    public interface IStaffRepository
    {
        List<Staff> GetAllStaffs();
        Staff GetStaffById(string id);
        void AddStaff(Staff staff);
        void UpdateStaff(Staff staff);
        void DeleteStaff(string id);
    }
}
