using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Tests_API.Entities
{
    [Table("institutions")]
    public class InstitutionsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; } = string.Empty;
    }
}
