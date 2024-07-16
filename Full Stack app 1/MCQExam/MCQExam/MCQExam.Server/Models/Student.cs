namespace MCQExam.Server.Models
{
    public class Student:BaseEntity
    {
       public string UserName { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public string BaseLevel { get; set; }

        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<Result> Students { get; set; }
    }
}
