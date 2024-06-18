using System.ComponentModel.DataAnnotations;

namespace CP.Abstractions.Contracts.Intern
{
    public class QuestionAnswerDTO
    {
        public int QuestionId { get; set; }
        [Required(ErrorMessage = "Question required*")]
        public string Question { get; set; } = null!;
        [Required(ErrorMessage = "Answer to question required*")]
        public string Answer { get; set; } = null!;
    }
}
