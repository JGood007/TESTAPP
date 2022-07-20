using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp7._20._22.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="First name is required!")]
        [StringLength(250)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [StringLength(250)]
        public string LastName { get; set; }
        public string Email { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
    }
}
