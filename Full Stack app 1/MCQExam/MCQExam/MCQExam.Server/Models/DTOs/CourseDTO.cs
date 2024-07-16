namespace MCQExam.Server.Models.DTOs
{
    public class CourseDTO
    {
        public string Name { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
