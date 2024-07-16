using ExamPrep.sever.Context;
using ExamPrep.sever.Models;

namespace ExamPrep.sever.SeedData
{
    public class DbContextSeed
    {

        public static async Task AddSeedDataAsync(UniversityDbContext dbContext)
        {
            Course course = new Course()
            {
                CourseName = "Python"
            };

            Course course1 = new Course()
            {
                CourseName = "Java"
            };

           
            Student student = new Student()
            {
                StudentName = "Shiv",
                Course = course,
            };
            Student student2 = new Student()
            {
                StudentName = "Ram",
                Course = course
            };
            Student student3 = new Student()
            {
                StudentName = "Sweta",
                Course = course1
            };
            Student student4 = new Student()
            {
                StudentName = "Anaya",
                Course = course1
            };

            if (!dbContext.Students.Any()) {
                await dbContext.Students.AddRangeAsync(student,student2,student3,student4);
                await dbContext.SaveChangesAsync();
            };

            if (!dbContext.Courses.Any()) {
                await dbContext.Courses.AddRangeAsync(course, course1);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
