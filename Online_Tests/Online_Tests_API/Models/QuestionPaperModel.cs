namespace Online_Tests_API.Models
{
    public class QuestionPaperModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool MultipleSections { get; set; }
        public bool BuiltInKey { get; set; }
        public bool ImmediateKey { get; set; }
        public bool IsTimeBound { get; set; }
        public string TestDuration { get; set; } = "00:00";
    }
}
