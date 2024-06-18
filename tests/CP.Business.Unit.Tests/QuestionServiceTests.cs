using CP.Abstractions.Services.Business;
using CP.Business.Unit.Tests.Builders;
using Staff = CP.Abstractions.Contracts.Staff;

namespace CP.Business.Unit.Tests
{
    public class QuestionServiceTests : BaseTest
    {
        [Test]
        public async Task Question_GetType_ByType_Successful()
        {
            //arrange
            int expectedCount = 3;
            var service = Build();

            //act
            var actual = await service.GetQuestionTypes<Staff.StaffQuestionTypeDTO>();

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual?.Count(), Is.EqualTo(expectedCount));

            });
        }

        [Test]
        public async Task ApplicationForm_GetForm_Successful()
        {

            int ProgramId = 1;
            int expectedAdditionalCount = 2;
            //arrange
            var service = Build();

            var actual = await service.GetApplicationForm<CP.Abstractions.Contracts.Intern.ApplicationForm>(null, ProgramId);

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual?.AdditionalQuestions.Count(), Is.EqualTo(expectedAdditionalCount));
            });
        }

        [Test]
        public void ApplicationForm_Submit_NoT_Successful()
        {

            var model = new CP.Abstractions.Contracts.Intern.ApplicationSubmitDTO();
            //arrange
            var service = Build();


            var exception = Assert.CatchAsync<Exception>(async () =>
            {
                await service.SubmitForm(model);
            });

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(exception.Message, Is.EqualTo("Valid program type is required*"));
            });
        }

        [Test]
        public void ApplicationForm_Submit_Successful()
        {

            var model = new CP.Abstractions.Contracts.Intern.ApplicationSubmitDTO()
            {
                Address = "Cool dev street",
                Gender = "male",
                Email = "johndeo@mail.com",
                FirstName = "John",
                LastName = "Doe",
                Nationality = "The world",
                Phone = "2348967856",
                DateOfBirth = DateTime.Now.AddYears(-47),
                ProgramId = 1,
                AdditionalInformation = new List<Abstractions.Contracts.Intern.QuestionAnswerDTO>
                  {
                     new Abstractions.Contracts.Intern.QuestionAnswerDTO
                     {
                          QuestionId = 1,
                           Answer = "ok",
                            Question = "Are you alright"
                     }
                  }
            };
            //arrange
            var service = Build();

            //assert
            Assert.DoesNotThrow(() => service.SubmitForm(model));

        }

        public IQuestionService Build()
        {
            return DefaultServiceBuilder.Build<IQuestionService>();
        }
    }
}
