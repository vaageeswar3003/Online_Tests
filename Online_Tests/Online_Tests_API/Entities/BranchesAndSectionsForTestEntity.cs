using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Tests_API.Entities
{
    [Table("branches_and_sections_for_exam")]
    public class BranchesAndSectionsForTestEntity
    {
        [Key]
        public int Id { get; set; }
        public int brandId { get; set; }
        public int sectionId { get; set; }
        public int questionPaperId { get; set; }
        [ForeignKey("QuestionPaperId")]
        public QuestionPaperEntity QuestionPaperEntity { get; set; }
    }
}
