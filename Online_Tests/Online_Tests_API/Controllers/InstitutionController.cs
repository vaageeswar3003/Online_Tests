using Microsoft.AspNetCore.Mvc;
using Online_Tests_API.Entities;
using Online_Tests_API.Services.Institution;

namespace Online_Tests_API.Controllers
{
    [Route("online-examination/institution")]
    public class InstitutionController:ControllerBase
    {
        private IBranchesService _branchesService;
        private ISectionsService _sectionsService;
        public InstitutionController(IBranchesService branchesService, ISectionsService sectionsService) {
            _branchesService = branchesService;
            _sectionsService = sectionsService;
        }

        // Branch Endpoints

        [HttpGet]
        [Route("get-branches-by-institution-id")]
        public async Task<IActionResult> GetBranchesByInstitutionId([FromQuery] int institutionId)
        {
            try
            {
                var data = await _branchesService.GetBranchesByInstitutionId(institutionId);
                return Ok(data);
            } catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("add-branch-to-institution")]
        public async Task<IActionResult> AddBranchToInstitutionet([FromBody] BranchesEntity branch)
        {
            try
            {
                var data = await _branchesService.AddBranchToInstitution(branch);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPut]
        [Route("update-branch-in-institution")]
        public async Task<IActionResult> UpdateBranchInInstitution([FromBody] BranchesEntity branch)
        {
            try
            {
                var data = await _branchesService.UpdateBranchInInstitution(branch);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpDelete]
        [Route("delete-branch-in-institution")]
        public async Task<IActionResult> DeleteBranchInInstitution([FromBody] BranchesEntity branch)
        {
            try
            {
                var data = await _branchesService.DeleteBranchInInstitution(branch);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // Sections Endpoints

        [HttpGet]
        [Route("get-sections-by-branch-id")]
        public async Task<IActionResult> GetSectionsByBranchId([FromQuery] int branchId)
        {
            try
            {
                var data = await _sectionsService.GetSectionsByBranchId(branchId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("add-section-to-branch")]
        public async Task<IActionResult> AddSectionToBranch([FromBody] SectionsEntity section)
        {
            try
            {
                var data = await _sectionsService.AddSectionToBranch(section);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPut]
        [Route("update-section-in-branch")]
        public async Task<IActionResult> UpdateSectionInBranch([FromBody] SectionsEntity section)
        {
            try
            {
                var data = await _sectionsService.UpdateSectionInBranch(section);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpDelete]
        [Route("delete-section-in-branch")]
        public async Task<IActionResult> DeleteSectionInBranch([FromBody] SectionsEntity section)
        {
            try
            {
                var data = await _sectionsService.DeleteSectionInBranch(section);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
