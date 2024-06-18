using CP.Abstractions.Contracts.Staff;
using CP.Abstractions.Enum;
using CP.Abstractions.Services.Business;
using CP.Business.Unit.Tests.Builders;
using Staff = CP.Abstractions.Contracts.Staff;

namespace CP.Business.Unit.Tests
{
    public class ProgramServiceTests : BaseTest
    {

        [Test]
        public async Task Programs_GetAll_IsSuccessful()
        {
            var expectedCount = 2;

            var service = Build();

            //act
            var actual = await service.GetAllPrograms<Staff.StaffProgramDTO>();


            //assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual.Count, Is.EqualTo(expectedCount));
            });
        }

        [Test]
        public async Task Program_GetById_IsSuccessful()
        {
            //arrange
            var ProgramId = 2;
            var service = Build();

            //act
            var actual = await service.GetProgramById<Staff.ProgramDetailDTO>(ProgramId);


            //assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual?.Program?.Id, Is.EqualTo(ProgramId));
            });
        }

        [Test]
        public async Task Program_GetById_NoSameRecord_IsSuccessful()
        {
            //arrange
            var ProgramId = 2;
            var AnotherProgramId = 1;
            var service = Build();

            //act
            var actual = await service.GetProgramById<Staff.ProgramDetailDTO>(AnotherProgramId);


            //assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual?.Program?.Id, Is.Not.EqualTo(ProgramId));
            });
        }

        [Test]
        public async Task Program_CreateProgram_IsSuccessful()
        {
            //arrange
            var model = new ProgramCreateDTO
            {
                Title = "Adams Engine",
                Description = "Too far to tell",
                AdditionalInformation = new List<QuestionCreateDTO>
                   {
                       new QuestionCreateDTO()
                       {
                            Type = "Paragraph",
                             Question = "What is your name?",
                              Data = "{\"inputType\":\"Paragraph\",\"inputOptions\":[]}"
                       }
                   }
            };
            var service = Build();

            //act
            var actual = await service.CreateProgram(model);


            //assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual?.Status, Is.EqualTo(OperationStatusType.Success));
                Assert.That(actual?.TotalErrors, Is.EqualTo(0));
            });
        }

        [Test]
        public async Task Program_CreateProgram_WrongQuestionType_Fail_IsSuccessful()
        {
            var expectedCount = 2;

            //arrange
            var model = new ProgramCreateDTO
            {
                Title = "Adams Engine",
                Description = "Too far to tell",
                AdditionalInformation = new List<QuestionCreateDTO>
                   {
                       new QuestionCreateDTO()
                       {
                            Type = "Smile",
                             Question = "What is your name?",
                              Data = "{\"inputType\":\"Paragraph\",\"inputOptions\":[]}"
                       },
                       new QuestionCreateDTO()
                       {
                            Type = "Hello",
                             Question = "What is your name?",
                              Data = "{\"inputType\":\"Paragraph\",\"inputOptions\":[]}"
                       },
                       new QuestionCreateDTO()
                       {
                            Type = "YesNo",
                             Question = "What is your name?",
                              Data = "{\"inputType\":\"Paragraph\",\"inputOptions\":[]}"
                       },
                   }
            };
            var service = Build();

            //act
            var actual = await service.CreateProgram(model);


            //assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual?.Status, Is.EqualTo(OperationStatusType.Failure));
                Assert.That(actual?.TotalErrors, Is.EqualTo(expectedCount));
            });
        }

        public IProgramService Build()
        {
            return DefaultServiceBuilder.Build<IProgramService>();
        }

    }
}
