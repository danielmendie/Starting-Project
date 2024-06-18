using CP.Abstractions.Contracts.Intern;

namespace CP.Abstractions.Services.Business
{
    public interface IQuestionService
    {
        Task<T> GetApplicationForm<T>(int? InternId, int ProgramId);
        Task<IEnumerable<T>> GetQuestionTypes<T>();
        Task SubmitForm(ApplicationSubmitDTO applicant);
    }
}
