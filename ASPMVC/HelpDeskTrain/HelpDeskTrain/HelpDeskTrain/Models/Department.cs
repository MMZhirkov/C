using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskTrain.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name department")]
        [MaxLength(50, ErrorMessage = "Exceeded maximum record length")]
        public string Name { get; set; }
    }
    // Model Active
    public class Activ
    {
        public int Id { get; set; }
        // Number cabinet
        [Required]
        [Display(Name = "Number cabinet")]
        [MaxLength(50, ErrorMessage = "Exceeded maximum record length")]
        public string CabNumber { get; set; }

        // Foreign key
        // ID Department - regular property
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        // Depatment - Navigation property
        public Department Department { get; set; }
    }
}