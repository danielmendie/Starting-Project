using CP.Abstractions.Services.Business;
using CP.Abstractions.Services.Data;
using CP.Abstractions.Services.Infrastructure;

namespace CP.Business
{
    public class ProfileService : IProfileService
    {
        readonly IProfileDataService ProfileDataService;
        readonly IMappingService MappingService;

        public ProfileService(IMappingService mappingService,
            IProfileDataService profileDataService)
        {
            MappingService = mappingService;
            ProfileDataService = profileDataService;
        }

        public async Task<T?> GetById<T>(long ProfileId)
        {
            var data = await ProfileDataService.GetProfileById(null, ProfileId);

            var retVal = data != null ? MappingService.Map<T>(data) : default(T);

            return retVal;
        }

    }
}
