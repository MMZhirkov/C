using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskTrain.Models
{
    public class User
    {
        //ID
        public int ID { get; set; }
        //FIO
        [Required]
        [Display(Name = "Surname Name")]
        [MaxLength(50, ErrorMessage = "Exceeded maximum record length")]
        public string Name { get; set; }
        //LOGIN
        [Required]
        [Display(Name = "Your login")]
        [MaxLength(50, ErrorMessage = "Exceeded maximum record length")]
        public string Login;
        //PASSWORD
        [Required]
        [Display(Name = "Password")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Password { get; set; }
        //POSITION OF THE EMPLOYEE
        [Display(Name = "POSITION OF THE EMPLOYEE")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Position { get; set; }
        //DEPARTMENT
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        //STATUS
        [Required]
        [Display(Name = "Status")]
        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}