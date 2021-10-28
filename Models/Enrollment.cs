using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_Contoso.Models
{
    public enum Grades
        
    { 
        A, B, C, D, F
    }
        public class Enrollment
        {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
            [DisplayFormat(NullDisplayText = "No grade")]
        public Nullable<Grades> Grade { get; set; }

        // Navigation properties
        public virtual Course Course { get; set; }         
        public virtual Student Student { get; set; }
        }
}
