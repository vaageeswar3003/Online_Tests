using Online_Tests_API.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Tests_API.Models
{
    public class QuestionPaperSectionModel
    {
        public int Id { get; set; }
        public string QuestionPaperSectionName { get; set; } = string.Empty;
        public int QuestionPaperId { get; set; }
    }
}
