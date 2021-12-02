using ASP_MVC_Contoso.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ASP_MVC_Contoso.Data
{
    public class DbInitialiser
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }


            var students = new Student[]
{
                new Student { FirstName = "Izzy",   LastName = "Thorpe",
                    EnrollmentDate = DateTime.Parse("2019-01-01") },
                new Student { FirstName = "Kayley", LastName = "Syrett",
                    EnrollmentDate = DateTime.Parse("2019-09-01") },
                new Student { FirstName = "Atish",   LastName = "Appadu",
                    EnrollmentDate = DateTime.Parse("2019-01-01") },
                new Student { FirstName = "Sammy",    LastName = "Maitland",
                    EnrollmentDate = DateTime.Parse("2019-09-01") },
                new Student { FirstName = "Steve",      LastName = "Ayes",
                    EnrollmentDate = DateTime.Parse("2020-09-01") },
                new Student { FirstName = "Shane",    LastName = "Field",
                    EnrollmentDate = DateTime.Parse("2020-01-01") },
                new Student { FirstName = "Dean",    LastName = "Stratton",
                    EnrollmentDate = DateTime.Parse("2020-09-01") },
                new Student { FirstName = "Jasmin",     LastName = "Labrooy",
                    EnrollmentDate = DateTime.Parse("2020-09-01") }
                };


            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();


            var instructors = new Instructor[]
{
                new Instructor { FirstName = "Derek",     LastName = "Peacock",
                    HireDate = DateTime.Parse("2014-03-11") },
                new Instructor { FirstName = "Kompel",    LastName = "Campion",
                    HireDate = DateTime.Parse("2017-07-06") },
                new Instructor { FirstName = "Justin",   LastName = "Luker",
                    HireDate = DateTime.Parse("208-07-01") },
                new Instructor { FirstName = "Nick", LastName = "Day",
                    HireDate = DateTime.Parse("2020-01-15") },
                new Instructor { FirstName = "Richard",   LastName = "Jones",
                    HireDate = DateTime.Parse("2018-02-12") }
                };


            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
{
                new Department { Name = "Computing",     Budget = 350000,
                    StartDate = DateTime.Parse("2009-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Peacock").ID },
                new Department { Name = "Computing and Web", Budget = 100000,
                    StartDate = DateTime.Parse("2010-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Day").ID },
                new Department { Name = "Games Development", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Jones").ID },
                new Department { Name = "Data",   Budget = 100000,
                    StartDate = DateTime.Parse("2010-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Campion").ID }
};

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();


            var courses = new Course[]
{
                new Course {CourseID = 4450, Title = "OOSD",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Computing").DepartmentID
                },
                new Course {CourseID = 4022, Title = "JavaScript", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Computing").DepartmentID
                },
                new Course {CourseID = 4041, Title = "Python", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Games Development").DepartmentID
                },
                new Course {CourseID = 4045, Title = "Mobile Apps",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Computing").DepartmentID
                },
                new Course {CourseID = 4141, Title = "Networking Principles",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Networking").DepartmentID
                },
                new Course {CourseID = 4021, Title = "Web Apps",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Computing and Web").DepartmentID
                },
                new Course {CourseID = 4042, Title = "AI",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Data").DepartmentID
                },
};

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();


            var officeAssignments = new OfficeAssignment[]
{
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Peacock").ID,
                    Location = "High Wycombe" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Day").ID,
                    Location = "Uxbridge" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Day").ID,
                    Location = "High Wycombe" },
};

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
{
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "JavaScript" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Peacock").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "OOSD" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Day").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Pyhthon" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Day").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Mobile Apps" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Jones").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Networking Priciples" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Web Apps" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Peacock").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "AI" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Campion").ID,
                    },
};


            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();


            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Thorpe").StudentID,
                    CourseID = courses.Single(c => c.Title == "OOSD" ).CourseID,
                    Grade = Grades.A
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Field").StudentID,
                    CourseID = courses.Single(c => c.Title == "Python" ).CourseID,
                    Grade = Grades.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Syrett").StudentID,
                    CourseID = courses.Single(c => c.Title == "Web Apps" ).CourseID,
                    Grade = Grades.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Addapu").StudentID,
                    CourseID = courses.Single(c => c.Title == "Python" ).CourseID,
                    Grade = Grades.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Maitland").StudentID,
                    CourseID = courses.Single(c => c.Title == "Networking Principles" ).CourseID,
                    Grade = Grades.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Stratton").StudentID,
                    CourseID = courses.Single(c => c.Title == "Mobile Apps" ).CourseID,
                    Grade = Grades.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Thorpe").StudentID,
                    CourseID = courses.Single(c => c.Title == "Data" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Stratton").StudentID,
                    CourseID = courses.Single(c => c.Title == "Data").CourseID,
                    Grade = Grades.B
                    },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Syrett").StudentID,
                    CourseID = courses.Single(c => c.Title == "Mobile Apps").CourseID,
                    Grade = Grades.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Addapu").StudentID,
                    CourseID = courses.Single(c => c.Title == "Games Development").CourseID,
                    Grade = Grades.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Labrooy").StudentID,
                    CourseID = courses.Single(c => c.Title == "JavaScript").CourseID,
                    Grade = Grades.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.StudentID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}