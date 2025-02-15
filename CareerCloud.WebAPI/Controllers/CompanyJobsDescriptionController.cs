using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyJobsDescriptionController : ControllerBase
    {
        private CompanyJobDescriptionLogic _CompanyJobDescriptionLogicInstance;
        public CompanyJobsDescriptionController()
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repository = new EFGenericRepository<CompanyJobDescriptionPoco>();
            _CompanyJobDescriptionLogicInstance = new CompanyJobDescriptionLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _CompanyJobDescriptionLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("company/{CompanyJobDescriptionId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetCompanyJobsDescription(Guid id)
        {
            try
            {
                var profile = _CompanyJobDescriptionLogicInstance.Get(id);
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
        [Route("company/{CompanyJobDescriptionId}")]
        public ActionResult PostCompanyJobsDescription(CompanyJobDescriptionPoco[] profile)
        {
            try
            {
                _CompanyJobDescriptionLogicInstance.Add(profile);
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
        [Route("company/{CompanyJobsDescriptionId}")]
        public ActionResult PutCompanyJobsDescription(CompanyJobDescriptionPoco[] profile)
        {
            try
            {
                _CompanyJobDescriptionLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("company/{CompanyJobDescriptionId}")]
        public ActionResult DeleteCompanyJobsDescription(CompanyJobDescriptionPoco[] profile)
        {
            try
            {
                _CompanyJobDescriptionLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
