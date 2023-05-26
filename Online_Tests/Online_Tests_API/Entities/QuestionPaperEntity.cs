using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Tests_API.Entities
{
    [Table("question_papers")]
    public class QuestionPaperEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionPaperId { get; set; }
        public string QuestionPaperName { get; set; } = string.Empty;
        public bool MultipleSections { get; set; }
        public bool BuiltInKey { get; set; }
        public bool ImmediateResult { get; set; }
        public bool IsTimeBound { get; set; }
        public string TestDuration { get; set; } = "00:00";
        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public InstitutionsEntity InstitutionsEntity { get; set; }

    }
}
