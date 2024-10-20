using Microsoft.AspNetCore.Mvc;
using SurveyProject.Core.DTOs.QuestionType;
using SurveyProject.Services.Interfaces;

namespace SurveyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypesController : ControllerBase
    {
        private readonly IQuestionTypeService _questionTypeService;

        public QuestionTypesController(IQuestionTypeService questionTypeService)
        {
            _questionTypeService = questionTypeService;
        }

        // GET: api/QuestionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadQuestionTypeDTO>>> GetQuestionTypes()
        {
            var questionTypes = await _questionTypeService.GetAllQuestionTypesAsync();
            return Ok(questionTypes);
        }

        // GET: api/QuestionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadQuestionTypeDTO>> GetQuestionType(int id)
        {
            var questionType = await _questionTypeService.GetQuestionTypeByIdAsync(id);
            if (questionType == null)
            {
                return NotFound();
            }
            return Ok(questionType);
        }

        // POST: api/QuestionTypes
        [HttpPost]
        public async Task<ActionResult<ReadQuestionTypeDTO>> CreateQuestionType(CreateQuestionTypeDTO createQuestionTypeDTO)
        {
            var questionType = await _questionTypeService.CreateQuestionTypeAsync(createQuestionTypeDTO);
            if (questionType == null)
            {
                return BadRequest("Failed to create question type.");
            }
            return CreatedAtAction(nameof(GetQuestionType), new { id = questionType.Id }, questionType);
        }

        // PUT: api/QuestionTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestionType(int id, UpdateQuestionTypeDTO updateQuestionTypeDTO)
        {
            var result = await _questionTypeService.UpdateQuestionTypeAsync(id, updateQuestionTypeDTO);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/QuestionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionType(int id)
        {
            var result = await _questionTypeService.DeleteQuestionTypeAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
