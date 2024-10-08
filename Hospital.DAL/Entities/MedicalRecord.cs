﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.DAL.Entities
{
    public class MedicalRecord
    {
        [Key]
        public int MedicalRecordID { get; set; }

        [MaxLength(500, ErrorMessage = "Diagnosis cannot exceed 500 characters.")]
        public string? Diagnosis { get; set; }

        [MaxLength(500, ErrorMessage = "Treatment cannot exceed 500 characters.")]
        public string? Treatment { get; set; }

        [Required(ErrorMessage = "Record date is required.")]
        public DateTime RecordDate { get; set; }

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
