using Microsoft.AspNetCore.Mvc;
using SurveyProject.Core.DTOs.Survey;
using SurveyProject.Services.Interfaces;

namespace SurveyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveysController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        // GET: api/Surveys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadSurveyDTO>>> GetSurveys()
        {
            var surveys = await _surveyService.GetAllSurveysAsync();
            return Ok(surveys);
        }

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadSurveyDTO>> GetSurvey(int id)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(id);
            if (survey == null)
            {
                return NotFound();
            }
            return Ok(survey);
        }

        // POST: api/Surveys
        [HttpPost]
        public async Task<ActionResult<ReadSurveyDTO>> CreateSurvey(CreateSurveyDTO createSurveyDTO)
        {
            var survey = await _surveyService.CreateSurveyAsync(createSurveyDTO);
            if (survey == null)
            {
                return BadRequest("Failed to create survey.");
            }
            return CreatedAtAction(nameof(GetSurvey), new { id = survey.Id }, survey);
        }

        // PUT: api/Surveys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurvey(int id, UpdateSurveyDTO updateSurveyDTO)
        {
            var result = await _surveyService.UpdateSurveyAsync(id, updateSurveyDTO);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            var result = await _surveyService.DeleteSurveyAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
