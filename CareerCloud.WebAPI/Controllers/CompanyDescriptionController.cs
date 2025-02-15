using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{

    [Route("api/careercloud/company/v1")]
    public class CompanyDescriptionController : ControllerBase
    {
        private CompanyDescriptionLogic _CompanyDescriptionLogicInstance;
        public CompanyDescriptionController()
        {
            EFGenericRepository<CompanyDescriptionPoco> repository = new EFGenericRepository<CompanyDescriptionPoco>();
            _CompanyDescriptionLogicInstance = new CompanyDescriptionLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _CompanyDescriptionLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("company/{CompanyDescriptionId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetCompanyDescription(Guid id)
        {
            try
            {
                var profile = _CompanyDescriptionLogicInstance.Get(id);
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
        [Route("company/{CompanyDescriptionId}")]
        public ActionResult PostCompanyDescription(CompanyDescriptionPoco[] profile)
        {
            try
            {
                _CompanyDescriptionLogicInstance.Add(profile);
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
        [Route("company/{CompanyDescriptionId}")]
        public ActionResult PutCompanyDescription(CompanyDescriptionPoco[] profile)
        {
            try
            {
                _CompanyDescriptionLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("company/{CompanyDescriptionId}")]
        public ActionResult DeleteCompanyDescription(CompanyDescriptionPoco[] profile)
        {
            try
            {
                _CompanyDescriptionLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }

}
