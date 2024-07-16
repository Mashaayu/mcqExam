﻿namespace MCQExam.Server.Models
{
    public class Exam:BaseEntity
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int TotalMarks { get; set; }
        public int NoOfStudentsAppeared { get; set; }
        public ICollection<Question> Questions { get; set; } 
        public int NumberOfquestions {  get; set; }
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