using Microsoft.AspNetCore.Mvc;
using SurveyProject.Core.DTOs.Respondent;
using SurveyProject.Services.Interfaces;

namespace SurveyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespondentsController : ControllerBase
    {
        private readonly IRespondentService _respondentService;

        public RespondentsController(IRespondentService respondentService)
        {
            _respondentService = respondentService;
        }

        // POST: api/Respondents
        [HttpPost]
        public async Task<ActionResult<ReadRespondentDTO>> CreateRespondent(CreateRespondentDTO createRespondentDTO)
        {
            var respondent = await _respondentService.CreateRespondentAsync(createRespondentDTO);
            if (respondent == null)
            {
                return BadRequest("Failed to create respondent. Ensure the survey exists and the data is valid.");
            }
            return Ok(respondent);
        }
    }
}
