using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;

namespace ICT13580024FinalA.Models
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string LastName { get; set; }

        public int Age { get; set; }

        [NotNull]
        public string Gender { get; set; }

        [NotNull]
        public string Department { get; set; }

        [NotNull]
        public int TelNumber { get; set; }

        [NotNull]
        [MaxLength(200)]
        public string Email { get; set; }

        [NotNull]
        public string Address { get; set; }

        [NotNull]
        public string Marry { get; set; }

        public int Baby { get; set; }
        public int Salary { get; set; }
    }
}
