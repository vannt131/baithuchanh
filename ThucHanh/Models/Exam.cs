using System.ComponentModel.DataAnnotations;

namespace ThucHanh.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        [Required]
        [Range(0, 100)]
        public int Score { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }


        //navigation property
        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }

    }
}
