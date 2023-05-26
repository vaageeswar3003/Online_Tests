using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Tests_API.Entities
{
    [Table("questions")]
    public class QuestionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public int QuestionType { get; set; }
        public string Question { get; set; } = string.Empty;
        public int AnswerType { get; set; }
        public  bool NegativeMarking { get; set; }
        public string CorrectAnswer { get; set; } = string.Empty;
        public int marks { get; set; }
        public int NegativeMarks { get; set; }
        public int QuestionPaperId { get; set; }
        [ForeignKey("QuestionPaperId")]
        public QuestionPaperEntity QuestionPaperEntity { get; set; }

    }
}
