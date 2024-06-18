using CP.Abstractions.Contracts.Staff;
using CP.Abstractions.Services.Business;
using CP.Api.Web.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace CP.Api.Web.Controllers
{
    /// <summary>
    /// program controller
    /// </summary>
    [Tags("Staff")]
    [Route("v1/programs")]
    public class ProgramController : Controller
    {
        private readonly IProgramService ProgramService;

        /// <summary>
        /// ProgramController constructor
        /// </summary>
        public ProgramController(IProgramService programService)
        {
            ProgramService = programService;
        }

        /// <summary>
        /// Gets all programs - gets all programs
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Abstractions.Contracts.Staff.StaffProgramDTO?>> GetPrograms()
        {
            var response = await ProgramService.GetAllPrograms<Abstractions.Contracts.Staff.StaffProgramDTO>();
            return response;
        }

        /// <summary>
        /// Add a program - creates a new program
        /// </summary>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<OperationStatusDTO> CreateProgram([FromBody] ProgramCreateDTO program)
        {
            var response = await ProgramService.CreateProgram(program);
            return response;
        }
    }
}
