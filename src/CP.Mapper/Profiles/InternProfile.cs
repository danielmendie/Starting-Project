using CP.Abstractions.Models;

namespace CP.Mappers.Profiles
{
    public class InternProfile : AutoMapper.Profile
    {
        public override string ProfileName => nameof(InternProfile);

        public InternProfile()
        {

            CreateMap<Profile, Abstractions.Contracts.Intern.ProfileDTO>();
            CreateMap<Program, Abstractions.Contracts.Intern.ProgramDTO>();
            CreateMap<ProgramQuestion, Abstractions.Contracts.Intern.QuestionDTO>();
            CreateMap<FormDetail, Abstractions.Contracts.Intern.ApplicationForm>();
        }
    }
}
