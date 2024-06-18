namespace CP.Abstractions.Contracts.Staff
{
    public class ProgramDetailDTO
    {
        public StaffProgramDTO Program { get; set; } = null!;
        public List<StaffQuestionDTO>? AdditionalInformation { get; set; }
    }
}
