using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyJobController : ControllerBase
    {
        private CompanyJobLogic _CompanyJobLogicInstance;
        public CompanyJobController()
        {
            EFGenericRepository<CompanyJobPoco> repository = new EFGenericRepository<CompanyJobPoco>();
            _CompanyJobLogicInstance = new CompanyJobLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _CompanyJobLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("company/{CompanyJobId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetCompanyJob(Guid id)
        {
            try
            {
                var profile = _CompanyJobLogicInstance.Get(id);
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
        [Route("company/{CompanyJobId}")]
        public ActionResult PostCompanyJob(CompanyJobPoco[] profile)
        {
            try
            {
                _CompanyJobLogicInstance.Add(profile);
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
        [Route("company/{CompanyJobId}")]
        public ActionResult PutCompanyJob(CompanyJobPoco[] profile)
        {
            try
            {
                _CompanyJobLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("company/{CompanyJobId}")]
        public ActionResult DeleteCompanyJob(CompanyJobPoco[] profile)
        {
            try
            {
                _CompanyJobLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
