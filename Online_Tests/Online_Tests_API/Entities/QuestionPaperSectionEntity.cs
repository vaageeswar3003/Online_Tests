using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Tests_API.Entities
{
    [Table("question_paper_sections")]
    public class QuestionPaperSectionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string QuestionPaperSectionName { get; set; } = string.Empty;
        public int QuestionPaperId { get; set; }
        [ForeignKey("QuestionPaperId")]
        public QuestionPaperEntity QuestionPaperEntity { get; set; }
    }
}
