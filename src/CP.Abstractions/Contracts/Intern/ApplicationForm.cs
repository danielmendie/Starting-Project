namespace CP.Abstractions.Contracts.Intern
{
    public class ApplicationForm
    {
        public ProgramDTO Program { get; set; } = null!;
        public ProfileDTO? Profile { get; set; }
        public List<QuestionDTO> AdditionalQuestions { get; set; } = new List<QuestionDTO>();
        public List<QuestionAnswerDTO>? Answers { get; set; } = null;
    }
}
