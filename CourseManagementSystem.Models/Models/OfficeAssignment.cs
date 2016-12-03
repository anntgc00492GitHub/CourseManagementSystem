using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Models.Models
{
    public class OfficeAssignment
    {
        [Key,ForeignKey("Instructor")]
        public int InstructorID { get; set; }

        public string Location { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}
