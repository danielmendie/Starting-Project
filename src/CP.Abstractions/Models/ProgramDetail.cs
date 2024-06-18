namespace CP.Abstractions.Models
{
    public class ProgramDetail
    {
        public Program Program { get; set; } = null!;
        public List<ProgramQuestion>? AdditionalInformation { get; set; }
    }
}
