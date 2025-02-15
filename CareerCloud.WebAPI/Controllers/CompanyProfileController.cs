using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyProfileController : ControllerBase
    {
        private CompanyProfileLogic _CompanyProfileLogicInstance;
        public CompanyProfileController()
        {
            EFGenericRepository<CompanyProfilePoco> repository = new EFGenericRepository<CompanyProfilePoco>();
            _CompanyProfileLogicInstance = new CompanyProfileLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _CompanyProfileLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("company/{ CompanyProfileId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetCompanyProfile(Guid id)
        {
            try
            {
                var profile = _CompanyProfileLogicInstance.Get(id);
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
        [Route("company/{ CompanyLocationId}")]
        public ActionResult PostCompanyProfile(CompanyProfilePoco[] profile)
        {
            try
            {
                _CompanyProfileLogicInstance.Add(profile);
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
        [Route("company/{ CompanyProfileId}")]
        public ActionResult PutCompanyProfile(CompanyProfilePoco[] profile)
        {
            try
            {
                _CompanyProfileLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("company/{ CompanyProfileId}")]
        public ActionResult DeleteCompanyProfile(CompanyProfilePoco[] profile)
        {
            try
            {
                _CompanyProfileLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
