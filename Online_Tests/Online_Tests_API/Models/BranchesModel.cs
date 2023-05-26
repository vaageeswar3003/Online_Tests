namespace Online_Tests_API.Models
{
    public class BranchesModel
    {
        public int Id { get; set; }
        public int InstitutionId { get; set; }
        public string BranchName { get; set; } = string.Empty;
    }
}
