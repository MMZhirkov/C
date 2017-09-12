using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskTrain.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name category")]
        [MaxLength(50, ErrorMessage = "Exceeded maximum record length")]
        public string Name { get; set; }
    }
}