using Online_Tests_API.Entities;

namespace Online_Tests_API.Models
{
    public class OptionsModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string option { get; set; } = string.Empty;
    }
}
