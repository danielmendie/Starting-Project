using System.ComponentModel.DataAnnotations;

namespace CP.Abstractions.Contracts.Staff
{
    public class QuestionCreateDTO
    {
        [Required(ErrorMessage = "Question type is required*")]
        public string Type { get; set; } = null!;
        [Required(ErrorMessage = "Question is required*")]
        public string Question { get; set; } = null!;
        [Required(ErrorMessage = "Question setup is required*")]
        public string Data { get; set; } = null!;
    }
}
