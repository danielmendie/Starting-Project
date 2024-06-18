using System.ComponentModel.DataAnnotations;

namespace CP.Abstractions.Contracts.Intern
{
    public class ApplicationSubmitDTO
    {
        public int ProgramId { get; set; }
        [Required(ErrorMessage = "First name required*")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Last name required*")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Email name required*")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Gender name required*")]
        public string Gender { get; set; } = null!;
        [Required(ErrorMessage = "Phone name required*")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Nationality required*")]
        public string Nationality { get; set; } = null!;
        [Required(ErrorMessage = "Address required*")]
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public List<QuestionAnswerDTO>? AdditionalInformation { get; set; }

    }
}
