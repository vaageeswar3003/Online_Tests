using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Tests_API.Entities
{
    [Table("branches")]
    public class BranchesEntity
    {
        [Key]
        public int BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public InstitutionsEntity InstitutionsEntity { get; set; }
    }
}
