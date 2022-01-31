using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbFirst_one_to_many_crud.Models
{
    public class ErrorLog
    {
        [Key]
        public Guid ErrorId { get; set; }
        [Required]
        public DateTime LoggedOn { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string StackTrace { get; set; }
    }
}
