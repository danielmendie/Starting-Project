using CP.Abstractions.Contracts.Staff;

namespace CP.Abstractions.Services.Business
{
    public interface IProgramService
    {
        Task<OperationStatusDTO> CreateProgram(ProgramCreateDTO program);
        Task<IEnumerable<T?>> GetAllPrograms<T>();
        Task<T?> GetProgramById<T>(int ProgramId);
        Task<OperationStatusDTO> UpdateProgram(long ProgramId, ProgramUpdateDTO program);
    }
}
