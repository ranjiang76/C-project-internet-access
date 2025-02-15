using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyJobSkillController : ControllerBase
    {
        private CompanyJobSkillLogic _CompanyJobSkillLogicInstance;
        public CompanyJobSkillController()
        {
            EFGenericRepository<CompanyJobSkillPoco> repository = new EFGenericRepository<CompanyJobSkillPoco>();
            _CompanyJobSkillLogicInstance = new CompanyJobSkillLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _CompanyJobSkillLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }


        [Route("company/{ CompanyJobSkillId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetCompanyJobSkill(Guid id)
        {
            try
            {
                var profile = _CompanyJobSkillLogicInstance.Get(id);
                if (profile == null)
                {
                    return NotFound();
                }
                return Ok(profile);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("company/{ CompanyJobSkillId}")]
        public ActionResult PostCompanyJobSkill(CompanyJobSkillPoco[] profile)
        {
            try
            {
                _CompanyJobSkillLogicInstance.Add(profile);
                return Ok();
            }
            catch (DuplicateException)
            {
                return Conflict();
            }
            catch (InvalidObjectException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("company/{ CompanyJobSkillId}")]
        public ActionResult PutCompanyJobSkill(CompanyJobSkillPoco[] profile)
        {
            try
            {
                _CompanyJobSkillLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("company/{ CompanyJobSkillId}")]
        public ActionResult DeleteCompanyJobSkill(CompanyJobSkillPoco[] profile)
        {
            try
            {
                _CompanyJobSkillLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
