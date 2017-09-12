using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskTrain.Models
{
    public class Request
    {
        // ID 
        public int Id { get; set; }
        // NAME REQUEST
        [Required]
        [Display(Name = "Name request")]
        [MaxLength(50, ErrorMessage = "Exceeded maximum record length")]
        public string Name { get; set; }
        // Description
        [Required]
        [Display(Name = "Description")]
        [MaxLength(200, ErrorMessage = "Exceeded maximum record length")]
        public string Description { get; set; }
        // Comment of the request
        [Display(Name = "Comment")]
        [MaxLength(200, ErrorMessage = "Exceeded maximum record length")]
        public string Comment { get; set; }
        // Status of the request
        [Display(Name = "Status")]
        public int Status { get; set; }
        // Priority
        [Display(Name = "Priority")]
        public int Priority { get; set; }
        // Office
        [Display(Name = "office")]
        public int ActivId { get; set; }
        public string Activ { get; set; }
        // File with error
        [Display(Name = "File with error")]
        public string File { get; set; }

        // Categoty foreign key
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public string Category { get; set; }

        // Foreign key
        // ID User - regular property
        public int UserId { get; set; }
        // Department user - Navigation property
        public User User { get; set; }

        // Foreign key
        // ID User - regular property
        public int ExecutorId { get; set; }
        // Отдел пользователя - НNavigation property
        public User Executor { get; set; }

        // Foreign key
        // ID life cycle of the request - regular property
        public int LifecycleId { get; set; }
        // REF life cycle of the request - Navigation property 
        public string Lifecycle { get; set; }
    }
    //Model life cycle of the request
    public class Lifecycle
    {
        // ID 
        public int Id { get; set; }
        // DATE OPEN
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Opened { get; set; }
        // Date distribution
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Distributed { get; set; }
        // Date processing
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Proccesing { get; set; }
        // Date check
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Checking { get; set; }
        // Date close
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Closed { get; set; }
    }
    // Listing for status request
    public enum RequestStatus
    {
        Open = 1,
        Distributed = 2,
        Proccesing = 3,
        Checking = 4,
        Closed = 5
    }
    // listing for priority request
    public enum RequestPriority
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }
}