namespace CP.Abstractions.Contracts.Intern
{
    public class ProfileDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
