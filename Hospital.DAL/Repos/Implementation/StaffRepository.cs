using Hospital.DAL.DataBase;
using Hospital.DAL.Entities;
using Hospital.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hospital.Repository.Implementation
{
    public class StaffRepository : IStaffRepository
    {
        private readonly HospitalDbContext _context;

        public StaffRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public List<Staff> GetAllStaffs()
        {
            return _context.Staffs.ToList();
        }

        public Staff GetStaffById(string id)
        {
            return _context.Staffs.Find(id);
        }

        public void AddStaff(Staff staff)
        {
            _context.Staffs.Add(staff);
            _context.SaveChanges();
        }

        public void UpdateStaff(Staff staff)
        {
            _context.Staffs.Update(staff);
            _context.SaveChanges();
        }

        public void DeleteStaff(string id)
        {
            var staff = GetStaffById(id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
                _context.SaveChanges();
            }
        }
    }
}
