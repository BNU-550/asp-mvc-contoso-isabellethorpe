using ASP_MVC_Contoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVC_Contoso.Data
{
    public class DbInitialiser
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstName="Izzy",LastName="Thorpe",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Student{FirstName="Kayley",LastName="Sryett",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstName="Atish",LastName="Appadu",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{FirstName="Derek",LastName="Peacock",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstName="Nicholas",LastName="Day",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstName="Justin",LastName="Luker",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{FirstName="Richard",LastName="Jones",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{FirstName="Kompel",LastName="Campion",EnrollmentDate=DateTime.Parse("2019-09-01")}
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseID=4023,Title="Computing",Credits=3},
                new Course{CourseID=4022,Title="Web Development",Credits=3},
                new Course{CourseID=4021,Title="Cyber Security",Credits=3},
                new Course{CourseID=4025,Title="Data Science",Credits=4},
                new Course{CourseID=4024,Title="Games Development",Credits=4},
                new Course{CourseID=4027,Title="Software Engineering",Credits=3},
                new Course{CourseID=4026,Title="Artificial Intelligence",Credits=4}
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=4023,Grade=Grades.A},
                new Enrollment{StudentID=1,CourseID=4021,Grade=Grades.C},
                new Enrollment{StudentID=1,CourseID=4027,Grade=Grades.B},
                new Enrollment{StudentID=2,CourseID=4026,Grade=Grades.B},
                new Enrollment{StudentID=2,CourseID=2023,Grade=Grades.F},
                new Enrollment{StudentID=2,CourseID=4025,Grade=Grades.F},
                new Enrollment{StudentID=3,CourseID=4025},
                new Enrollment{StudentID=4,CourseID=4022},
                new Enrollment{StudentID=4,CourseID=4022,Grade=Grades.F},
                new Enrollment{StudentID=5,CourseID=4026,Grade=Grades.C},
                new Enrollment{StudentID=6,CourseID=4024},
                new Enrollment{StudentID=7,CourseID=4021,Grade=Grades.A},
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}

