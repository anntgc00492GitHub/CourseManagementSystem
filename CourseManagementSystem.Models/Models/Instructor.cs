using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseManagementSystem.Models.Abstract;

namespace CourseManagementSystem.Models.Models
{
    public class Instructor:Person { 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; }
        public virtual ICollection<Teaching> Teachings { get; set; }
    }
}
