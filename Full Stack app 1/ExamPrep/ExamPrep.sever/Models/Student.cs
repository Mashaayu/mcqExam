using System.Globalization;

namespace ExamPrep.sever.Models
{
    public class Student : BaseEntity
    {
        public string StudentName { get; set; }
        public Course Course { get; set; }
    }
}
