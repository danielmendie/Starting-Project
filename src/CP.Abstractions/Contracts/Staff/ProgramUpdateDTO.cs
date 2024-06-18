using CP.Abstractions.Enum;
using System.ComponentModel.DataAnnotations;

namespace CP.Abstractions.Contracts.Staff
{
    public class ProgramUpdateDTO
    {
        [Required(ErrorMessage = "Program title required*")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Program description required*")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Additional information required*")]
        public List<QuestionUpdateDTO> AdditionalInformation { get; set; } = new List<QuestionUpdateDTO>();
        public DefaultStatusType Status { get; set; }
    }
}
