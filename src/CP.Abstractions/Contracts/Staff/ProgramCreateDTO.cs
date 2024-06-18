using System.ComponentModel.DataAnnotations;

namespace CP.Abstractions.Contracts.Staff
{
    public class ProgramCreateDTO
    {
        [Required(ErrorMessage = "Program title required*")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Program description required*")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Additional information required*")]
        public List<QuestionCreateDTO> AdditionalInformation { get; set; } = new List<QuestionCreateDTO>();
    }
}
