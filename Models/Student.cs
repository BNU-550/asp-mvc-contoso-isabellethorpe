using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASP_MVC_Contoso.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        // Added Regex 
        [DisplayName("Last Name"), RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required, StringLength(20)]
        public string LastName { get; set; }

        // Added Regex
        // Did not need to add Column "FirstName" as we
        // have only FirstName and LastName/ no overlap
        [DisplayName("First Name"), RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required, StringLength(20)]
        public string FirstName { get; set; }


        [DisplayName("Enrollment Date"), DataType(DataType.Date)]

        public DateTime EnrollmentDate { get; set; }


        // Relationships or navigation properties 
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        // Calculated Property
        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
