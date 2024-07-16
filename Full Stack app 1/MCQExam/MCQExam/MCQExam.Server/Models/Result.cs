using System.Xml.Schema;

namespace MCQExam.Server.Models
{
    public class Result : BaseEntity
    {
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int StudentID {get;set;}
        public Student Student { get; set; }

        public int Score { get; set; }
        

        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
