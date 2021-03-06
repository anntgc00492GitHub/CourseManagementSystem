﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Models.Abstract
{
    public abstract class Person : IPerson
    {
        public int ID { get; set; }
        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "First name must be between 5 and 50 characters"), Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "Last name must be between 5 and 50 characters"), Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Full name")]
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
