namespace MCQExam.Server.Models
{
    public class Course:BaseEntity
    {
        public string Name { get; set; } 
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
