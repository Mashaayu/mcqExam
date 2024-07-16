namespace MCQExam.Server.Models
{
    public class Question:BaseEntity
    {
        public string QuestionName {  get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }

        public string Answer { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set; }
        public int SubjectId { get; set; }
        public Subject  Subject { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
