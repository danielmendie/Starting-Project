namespace CP.Abstractions.Services.Business
{
    public interface IProfileService
    {
        Task<T?> GetById<T>(long ProfileId);
    }
}
