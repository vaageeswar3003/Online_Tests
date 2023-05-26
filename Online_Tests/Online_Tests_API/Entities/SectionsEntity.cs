using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Tests_API.Entities
{
    [Table("sections")]
    public class SectionsEntity
    {
        [Key]
        public int SectionId { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public BranchesEntity BranchesEntity { get; set; }
    }
}
