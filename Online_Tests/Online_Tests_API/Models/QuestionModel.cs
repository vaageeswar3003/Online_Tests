namespace Online_Tests_API.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int QuestionType { get; set; }
        public string Question { get; set; } = string.Empty;
        public int AnswerType { get; set; }
        public bool NegativeMarking { get; set; }
        public string CorrectAnswer { get; set; } = string.Empty;
        public int marks { get; set; }
        public int NegativeMarks { get; set; }
    }
}
