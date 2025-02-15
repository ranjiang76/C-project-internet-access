using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyJobEducationController : ControllerBase
    {
        private CompanyJobEducationLogic _CompanyJobEducationLogicInstance;
        public CompanyJobEducationController()
        {
            EFGenericRepository<CompanyJobEducationPoco> repository = new EFGenericRepository<CompanyJobEducationPoco>();
            _CompanyJobEducationLogicInstance = new CompanyJobEducationLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _CompanyJobEducationLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("company/{CompanyJobEducationId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetCompanyJobEducation(Guid id)
        {
            try
            {
                var profile = _CompanyJobEducationLogicInstance.Get(id);
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
        [Route("company/{CompanyJobEducationId}")]
        public ActionResult PostCompanyJobEducation(CompanyJobEducationPoco[] profile)
        {
            try
            {
                _CompanyJobEducationLogicInstance.Add(profile);
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
        [Route("company/{CompanyJobEducationId}")]
        public ActionResult PutCompanyJobEducation(CompanyJobEducationPoco[] profile)
        {
            try
            {
                _CompanyJobEducationLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("company/{CompanyJobEducationId}")]
        public ActionResult DeleteCompanyJobEducation(CompanyJobEducationPoco[] profile)
        {
            try
            {
                _CompanyJobEducationLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
