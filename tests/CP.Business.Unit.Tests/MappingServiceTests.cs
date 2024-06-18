using CP.Abstractions.Contracts.Intern;
using CP.Abstractions.Models;
using CP.Abstractions.Services.Infrastructure;
using CP.Business.Unit.Tests.Builders;

namespace CP.Business.Unit.Tests
{
    [TestFixture]
    public class MappingServiceTests : BaseTest
    {
        private IMappingService _mappingService;

        [SetUp]
        public void Setup()
        {
            _mappingService = Build();
        }

        [Test]
        public void Map_GenericType_ShouldReturnMappedObject()
        {
            // Arrange
            var source = new Program();

            // Act
            var result = _mappingService.Map<ProgramDTO>(source);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ProgramDTO>(result);
        }

        [Test]
        public void Map_SourceAndDestinationType_ShouldReturnMappedObject()
        {
            // Arrange
            var source = new Program();
            var destination = new ProgramDTO();

            // Act
            var result = _mappingService.Map(source, destination);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ProgramDTO>(result);
        }

        [Test]
        public void Map_SourceAndDestinationType_Generic_ShouldReturnMappedObject()
        {
            // Arrange
            var source = new Program();

            // Act
            var result = _mappingService.Map<Program, ProgramDTO>(source);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ProgramDTO>(result);
        }

        [Test]
        public void Map_SourceSourceTypeDestinationType_ShouldReturnMappedObject()
        {
            // Arrange
            var source = new Program();

            // Act
            var result = _mappingService.Map(source, typeof(Program), typeof(ProgramDTO));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ProgramDTO>(result);
        }

        [Test]
        public void Map_SourceDestinationSourceSourceTypeDestinationType_ShouldReturnMappedObject()
        {
            // Arrange
            var source = new Program();
            var destination = new ProgramDTO();

            // Act
            var result = _mappingService.Map(source, destination, typeof(Program), typeof(ProgramDTO));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ProgramDTO>(result);
        }

        public IMappingService Build()
        {
            return DefaultServiceBuilder.Build<IMappingService>();
        }
    }
}
