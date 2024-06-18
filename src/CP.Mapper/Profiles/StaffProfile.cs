using CP.Abstractions.Models;

namespace CP.Mappers.Profiles
{
    public class StaffProfile : AutoMapper.Profile
    {
        public override string ProfileName => nameof(StaffProfile);

        public StaffProfile()
        {
            CreateMap<ProgramQuestion, Abstractions.Contracts.Staff.StaffQuestionDTO>();
            CreateMap<QuestionType, Abstractions.Contracts.Staff.StaffQuestionTypeDTO>();
            CreateMap<Program, Abstractions.Contracts.Staff.StaffProgramDTO>();
            CreateMap<ProgramDetail, Abstractions.Contracts.Staff.ProgramDetailDTO>();
            CreateMap<Profile, Abstractions.Contracts.Staff.InternProfileDTO>();
        }
    }
}
