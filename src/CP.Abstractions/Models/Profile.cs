using CP.Abstractions.Enum;

namespace CP.Abstractions.Models
{
    public class Profile
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Data { get; set; }

        public ProfileStatusType Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; } = null!;
    }
}
