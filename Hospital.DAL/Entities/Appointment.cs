﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.DAL.Entities
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required(ErrorMessage = "Appointment date is required.")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [MaxLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
        public string Status { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Patient ID is required.")]
        [ForeignKey("Patient")]
        public string PatientID { get; set; }

        public Patient? Patient { get; set; }

        [Required(ErrorMessage = "Staff ID is required.")]
        [ForeignKey("Staff")]
        public string StaffID { get; set; }

        public Staff? Staff { get; set; }
    }
}
