using CP.Abstractions.Contracts.Intern;

namespace CP.Abstractions.Models
{
    public class FormDetail
    {
        public Program Program { get; set; } = null!;
        public Profile? Profile { get; set; }
        public List<ProgramQuestion>? AdditionalQuestions { get; set; }
        public List<QuestionAnswerDTO>? Answers { get; set; }
    }
}
