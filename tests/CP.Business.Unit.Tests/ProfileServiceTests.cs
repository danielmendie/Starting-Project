using CP.Abstractions.Enum;
using CP.Abstractions.Services.Business;
using CP.Business.Unit.Tests.Builders;

namespace CP.Business.Unit.Tests
{
    public class ProfileServiceTests : BaseTest
    {
        [Test]
        public async Task Profile_GetById_IsSuccessful()
        {
            //arrange
            var service = Build();
            var ProfileId = 1;

            //act
            var actual = await service.GetById<Abstractions.Contracts.Staff.InternProfileDTO>(ProfileId);

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual?.Id, Is.EqualTo(ProfileId));
                Assert.That(actual?.Status, Is.EqualTo(DefaultStatusType.Active));
            });
        }

        [Test]
        public async Task Profile_GetByProfileId_NoRecords_IsSuccessful()
        {
            //arrange
            var ProfileId = 1;
            var anotherProfileId = 99;
            var service = Build();

            //act
            var actual = await service.GetById<Abstractions.Contracts.Staff.InternProfileDTO>(anotherProfileId);

            //assert

            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Null);
                Assert.That(actual?.Id, Is.Not.EqualTo(ProfileId));
            });
        }


        public IProfileService Build()
        {
            return DefaultServiceBuilder.Build<IProfileService>();
        }
    }
}
