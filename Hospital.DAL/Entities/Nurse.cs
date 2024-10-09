using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL.Entities
{
    public class Nurse : ApplicationUser
    {
        [Required]
        [Range(10000, 15000)]
        public decimal Salary { get; set; }
    }
}
