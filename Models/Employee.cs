using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DbFirst_one_to_many_crud.Models
{
    public class Employee
    {
        //public string MyProperty = $"Dhananjay {ErrorLog.Mesage}"; 
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ForeignKey("Department")]
        
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Department")]
        public int DepID { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        //[Required]
        public string Description { get; set; }

        [NotMapped]
        public string Department { get; set; }

    }
}
