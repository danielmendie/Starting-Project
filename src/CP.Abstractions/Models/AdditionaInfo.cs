using CP.Abstractions.Contracts.Intern;

namespace CP.Abstractions.Models
{
    public class AdditionaInfo
    {
        public int ProgramId { get; set; }
        public List<QuestionAnswerDTO>? AddittionalInformation { get; set; }
    }
}
