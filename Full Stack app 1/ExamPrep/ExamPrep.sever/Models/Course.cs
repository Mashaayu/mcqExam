namespace ExamPrep.sever.Models
{
    public class Course:BaseEntity
    {
        public string CourseName { get; set; }
        public ICollection<Student> Students { get; set; } = null!;
    }
}
