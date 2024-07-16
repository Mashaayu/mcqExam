using MCQExam.Server.Context;
using MCQExam.Server.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MCQExam.Server.Models.SeedData
{
    public class MCQExamDbContextSeed
    {
        private readonly MCQExamDbContext dbContext;
        public static async Task AddSeedData(MCQExamDbContext dbContext, UserManager<AppUser> userManager)
        {

            int admin1Id = 2;

            Subject subject = await dbContext.FindAsync<Subject>(17);
            Course course = await dbContext.FindAsync<Course>(1);
            Question question1 = new Question()
            {
                QuestionName = "Which of the following is True?",
                Option1 = "Entity Framework is an MVC framework.",
                Option2 = "Entity Framework is an open source ORM framework.",
                Option3 = "Entity Framework is a framework for database management tool.",
                Option4 = "Entity Framework is object mapping tool.",
                Answer = "Entity Framework is an open source ORM framework.",
                CourseId = course.Id,
                Course = course,
                SubjectId = subject.Id,
                Subject = subject,
                CreatedDate = DateTime.Now,
                ModifiedById = admin1Id,
                CreatedById = admin1Id,
                ModifiedDate = DateTime.Now,

            };
            Question question2 = new Question()
            {
                QuestionName = "What is an Entity Data Model (EDM)?",
                Option1 = "EDM is a model for the underlying database.",
                Option2 = "EDM is an in-memory representation of the entire metadata: conceptual model, storage model, and mapping between them.\r\n",
                Option3 = "EDM is responsible for caching data in EF.",
                Option4 = "EDM is responsible for executing database commands.",
                Answer = "EDM is an in-memory representation of the entire metadata: conceptual model, storage model, and mapping between them.\r\n",
                CourseId = course.Id,
                Course = course,
                SubjectId = subject.Id,
                Subject = subject,
                CreatedDate = DateTime.Now,
                ModifiedById = admin1Id,
                CreatedById = admin1Id,
                ModifiedDate = DateTime.Now,


            };
            Question question3 = new Question()
            {
                QuestionName = "Which of the following development approaches are supported in Entity Framework?",
                Option1 = "Code-First",
                Option2 = "Database-First",
                Option3 = "model-First",
                Option4 = "ALL ",
                Answer = "ALL ",
                CourseId = course.Id,
                Course = course,
                SubjectId = subject.Id,
                Subject = subject,
                CreatedDate = DateTime.Now,
                ModifiedById = admin1Id,
                CreatedById = admin1Id,
                ModifiedDate = DateTime.Now,


            };
            Question question4 = new Question()
            {
                QuestionName = " ___________ in Visual Studio displays conceptual model, storage model and mapping information of EDM.",
                Option1 = "Model window",
                Option2 = "Model Browser",
                Option3 = "EDM Designer\r\n",
                Option4 = "Solution Explorer",
                Answer = "Model Browser ",
                CourseId = course.Id,
                Course = course,
                SubjectId = subject.Id,
                Subject = subject,
                CreatedDate = DateTime.Now,
                ModifiedById = admin1Id,
                CreatedById = admin1Id,
                ModifiedDate = DateTime.Now,


            };
            Question question5 = new Question()
            {
                QuestionName = "An instance of __________ class represents a session with the underlying database.",
                Option1 = "DbContext",
                Option2 = "Dbset",
                Option3 = "DbEntity",
                Option4 = "None",
                Answer = "DbContext",
                CourseId = course.Id,
                Course = course,
                SubjectId = subject.Id,
                Subject = subject,
                CreatedDate = DateTime.Now,
                ModifiedById = admin1Id,
                CreatedById = admin1Id,
                ModifiedDate = DateTime.Now,


            };
            Question question6 = new Question()
            {
                QuestionName = "Eager loading in EF 6 is achieved using _______ method.",
                Option1 = "Load()",
                Option2 = "Include()",
                Option3 = "IncludeThen()",
                Option4 = "EagerLoad()",
                Answer = "Include()",
                CourseId = course.Id,
                Course = course,
                SubjectId = subject.Id,
                Subject = subject,
                CreatedDate = DateTime.Now,
                ModifiedById = admin1Id,
                CreatedById = admin1Id,
                ModifiedDate = DateTime.Now,

            };
            Question question7 = new Question()
            {
                QuestionName = "Which of the following query syntax can be use to query in EF 6?",
                Option1 = "LINQ-to-Entity",
                Option2 = "Entity SQL",
                Option3 = "Native SQL",
                Option4 = "All of the above",
                Answer = "LINQ-to-Entity",
                CourseId = course.Id,
                Course = course,
                SubjectId = subject.Id,
                Subject = subject,
                CreatedDate = DateTime.Now,
                ModifiedById = admin1Id,
                CreatedById = admin1Id,
                ModifiedDate = DateTime.Now,


            };
            Question question8 = new Question()
            {
                QuestionName = "Which of the following method of DbContext is used to save entities to the database?",
                Option1 = "Save()",
                Option2 = "Execute()",
                Option3 = "SaveChanges()",
                Option4 = "Add()",
                Answer = "SaveChanges()",
                CourseId = course.Id,
                Course = course,
                SubjectId = subject.Id,
                Subject = subject,
                CreatedDate = DateTime.Now,
                ModifiedById = admin1Id,
                CreatedById = admin1Id,
                ModifiedDate = DateTime.Now,


            };
            Question question9 = new Question()
            {
                QuestionName = "Which of the following is class represents an entity set?",
                Option1 = "DbContext",
                Option2 = "ObjectContext",
                Option3 = "Dbset",
                Option4 = "none",
                Answer = "Dbset",
                CourseId = course.Id,
                Course = course,
                SubjectId = subject.Id,
                Subject = subject,
                CreatedDate = DateTime.Now,
                ModifiedById = admin1Id,
                CreatedById = admin1Id,
                ModifiedDate = DateTime.Now,

            };
            Question question10 = new Question()
            {
                QuestionName = "Which of the followings are valid entity states in EF 6?",
                Option1 = "Added, Modified, Deleted, Saved",
                Option2 = "Added, Modified, Deleted, Unchanged, Changed",
                Option3 = "Added, Modified, Deleted, Unchanged, Detached",
                Option4 = "None of the above",
                Answer = "Added, Modified, Deleted, Unchanged, Detached",
                CourseId = course.Id,
                Course = course,
                SubjectId = subject.Id,
                Subject = subject,
                CreatedDate = DateTime.Now,
                ModifiedById = admin1Id,
                CreatedById = admin1Id,
                ModifiedDate = DateTime.Now,
            };
            await dbContext.AddRangeAsync(question1, question2, question3, question4, question5, question5, question6, question7, question8, question9, question10);
            await dbContext.SaveChangesAsync();

        }
    }
}
