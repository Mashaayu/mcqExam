namespace MCQExam.Server.Models.DTOs
{
    public class InstructorDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public string BaseLevel { get; set; }

        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedDate { get; set; }


    }
}
