namespace MCQExam.Server.Models
{
    public class Instructor:BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }

        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<Exam>? Exams { get; set; }
    }
}
