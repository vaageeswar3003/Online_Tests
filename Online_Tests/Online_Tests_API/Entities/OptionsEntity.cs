using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Tests_API.Entities
{
    [Table("options")]
    public class OptionsEntity
    {
        [Key]
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public QuestionEntity QuestionEntity { get; set; }
        [ForeignKey("QuestionId")]
        public string option { get; set; } = string.Empty;
    }
}
