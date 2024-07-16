namespace MCQExam.Server.Models.DTOs
{
    public class ExamDTO 
    {
        public string Name { get; set; }
        public string Course { get; set; }
        public int Marks { get; set; }
        public int NoOfStudentsAppeared { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ExamDuration { get; set; }
        public DateTime EndTime { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Instructor? Instructor { get; set; }
    }
}
