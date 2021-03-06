﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Models.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Titlte must be between 5 and 50 characters")]

        public string Title { get; set; }
        [Range(0, 50)]
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Teaching> Teachings { get; set; }
    }
}
