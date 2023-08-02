using Microsoft.AspNetCore.Mvc;
using Online_Tests_API.Entities;
using Online_Tests_API.Services.Exam;

namespace Online_Tests_API.Controllers
{
    [Route("online-examination/exam")]
    public class ExamController: ControllerBase
    {

        private readonly IQuestionPaperService _questionPaperService;
        private readonly IQuestionService _questionService;
        private readonly IOptionsService _optionsService;
        private readonly IBranchAndSectionService _branchesAndSectionService;
        private readonly IQuestionPaperSectionService _questionPaperSectionService;
        public ExamController(IQuestionPaperService questionPaperService, IQuestionService questionService, IOptionsService optionsService, IBranchAndSectionService branchesAndSectionService, IQuestionPaperSectionService questionPaperSectionService) {
            _questionPaperService = questionPaperService;
            _questionService = questionService;
            _optionsService = optionsService;
            _branchesAndSectionService = branchesAndSectionService;
            _questionPaperSectionService = questionPaperSectionService;
        }

        // Question Paper Endpoints

        [HttpGet]
        [Route("get-all-question-papers")]
        public async Task<IActionResult> GetAllQuestionPapers()
        {
            try
            {
                var questionPapers = await _questionPaperService.GetAllQuestionPapers();
                return Ok(questionPapers);
            } catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("create-question-paper")]
        public async Task<IActionResult> CreateQuestionPaper([FromBody] QuestionPaperEntity questionPaper)
        {
            try
            {
                var data = await _questionPaperService.CreateQuestionPaper(questionPaper);
                return Ok(data);
            } catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-question-paper")]
        public async Task<IActionResult> UpdateQuestionPaper([FromBody] QuestionPaperEntity questionPaper)
        {
            try
            {
                var data = await _questionPaperService.UpdateQuestionPaper(questionPaper);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-question-paper")]
        public async Task<IActionResult> DeleteQuestionPaper([FromBody] QuestionPaperEntity questionPaper)
        {
            try
            {
                var data = await _questionPaperService.DeleteQuestionPaper(questionPaper);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // Question Endpoints

        [HttpGet]
        [Route("get-all-questions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            try
            {
                var questionPapers = await _questionService.GetAllQuestions();
                return Ok(questionPapers);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("create-question")]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionEntity question)
        {
            try
            {
                var data = await _questionService.CreateQuestion(question);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-question")]
        public async Task<IActionResult> UpdateQuestion([FromBody] QuestionEntity question)
        {
            try
            {
                var data = await _questionService.UpdateQuestion(question);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-question")]
        public async Task<IActionResult> DeleteQuestion([FromBody] QuestionEntity question)
        {
            try
            {
                var data = await _questionService.DeleteQuestion(question);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // Option Endpoints

        [HttpGet]
        [Route("get-all-options")]
        public async Task<IActionResult> GetAllOptions()
        {
            try
            {
                var questionPapers = await _optionsService.GetAllOptions();
                return Ok(questionPapers);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("create-option")]
        public async Task<IActionResult> CreateOption([FromBody] OptionsEntity option)
        {
            try
            {
                var data = await _optionsService.CreateOption(option);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-option")]
        public async Task<IActionResult> UpdateOption([FromBody] OptionsEntity option)
        {
            try
            {
                var data = await _optionsService.UpdateOption(option);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-option")]
        public async Task<IActionResult> DeleteOption([FromBody] OptionsEntity option)
        {
            try
            {
                var data = await _optionsService.DeleteOption(option);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // Branches And Sections Endpoints

        [HttpGet]
        [Route("get-all-branches-and-sections-by-question-papaer-id")]
        public async Task<IActionResult> GetAllBranchesAndSectionsByQuestionPaperId(int questionPaperId)
        {
            try
            {
                var questionPapers = await _branchesAndSectionService.GetAllBranchesAndSectionsByQuestionPaperId(questionPaperId);
                return Ok(questionPapers);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("create-branch-and-section")]
        public async Task<IActionResult> CreateBranchAndSection([FromBody] BranchesAndSectionsForTestEntity branchAndSection)
        {
            try
            {
                var data = await _branchesAndSectionService.CreateBranchAndSection(branchAndSection);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-branch-and-section")]
        public async Task<IActionResult> UpdateBranchAndSection([FromBody] BranchesAndSectionsForTestEntity branchAndSection)
        {
            try
            {
                var data = await _branchesAndSectionService.UpdateBranchAndSection(branchAndSection);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-branch-and-section")]
        public async Task<IActionResult> DeleteBranchAndSection([FromBody] BranchesAndSectionsForTestEntity branchAndSection)
        {
            try
            {
                var data = await _branchesAndSectionService.DeleteBranchAndSection(branchAndSection);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // Question Paper Section Endpoints

        [HttpGet]
        [Route("get-all-question-paper-sections")]
        public async Task<IActionResult> GetAllQuestionPaperSections()
        {
            try
            {
                var questionPapers = await _questionPaperSectionService.GetAllQuestionPaperSections();
                return Ok(questionPapers);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-all-question-paper-sections-by-question-paper-id")]
        public async Task<IActionResult> GetQuestionPaperSectionsByQuestionPaperId(int questionPaperId)
        {
            try
            {
                var questionPapers = await _questionPaperSectionService.GetQuestionPaperSectionsByQuestionPaperId(questionPaperId);
                return Ok(questionPapers);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("create-question-paper-section")]
        public async Task<IActionResult> CreateQuestionPaperSection([FromBody] QuestionPaperSectionEntity questionPaperSection)
        {
            try
                 {
                var data = await _questionPaperSectionService.CreateQuestionPaperSection(questionPaperSection);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-question-paper-section")]
        public async Task<IActionResult> UpdateQuestionPaperSection([FromBody] QuestionPaperSectionEntity questionPaperSection)
        {
            try
            {
                var data = await _questionPaperSectionService.UpdateQuestionPaperSection(questionPaperSection);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-question-paper-section")]
        public async Task<IActionResult> DeleteQuestionPaperSection([FromBody] QuestionPaperSectionEntity questionPaperSection)
        {
            try
            {
                var data = await _questionPaperSectionService.DeleteQuestionPaperSection(questionPaperSection);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
