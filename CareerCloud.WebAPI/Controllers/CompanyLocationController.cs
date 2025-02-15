using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyLocationController : ControllerBase
    {
        private CompanyLocationLogic _CompanyLocationLogicInstance;
        public CompanyLocationController()
        {
            EFGenericRepository<CompanyLocationPoco> repository = new EFGenericRepository<CompanyLocationPoco>();
            _CompanyLocationLogicInstance = new CompanyLocationLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _CompanyLocationLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("company/{ CompanyLocationId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetCompanyLocation(Guid id)
        {
            try
            {
                var profile = _CompanyLocationLogicInstance.Get(id);
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
        public ActionResult PostCompanyLocation(CompanyLocationPoco[] profile)
        {
            try
            {
                _CompanyLocationLogicInstance.Add(profile);
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
        [Route("company/{ CompanyLocationId}")]
        public ActionResult PutCompanyLocation(CompanyLocationPoco[] profile)
        {
            try
            {
                _CompanyLocationLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("company/{ CompanyLocationId}")]
        public ActionResult DeleteCompanyLocation(CompanyLocationPoco[] profile)
        {
            try
            {
                _CompanyLocationLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
