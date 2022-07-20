using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp7._20._22.Models
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        public string PermanentAddress { get; set; }
        public string HomeAddress { get; set; }
        public string EmergencyContactPerson { get; set; }
        public string EmergencyContactNumber { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
