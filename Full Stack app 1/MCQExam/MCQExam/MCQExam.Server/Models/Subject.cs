namespace MCQExam.Server.Models
{
    public class Subject:BaseEntity
    {
        public string SubjectName { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }
    }
}
