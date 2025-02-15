using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{

    [Route("api/careercloud/security/v1")]
    public class SecurityLoginsLogController : ControllerBase
    {
        private SecurityLoginsLogLogic _SecurityLoginsLogLogicInstance;
        public SecurityLoginsLogController()
        {
            EFGenericRepository<SecurityLoginsLogPoco> repository = new EFGenericRepository<SecurityLoginsLogPoco>();
            _SecurityLoginsLogLogicInstance = new SecurityLoginsLogLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _SecurityLoginsLogLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("security/{ SecurityLoginsLogId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetSecurityLoginLog(Guid id)
        {
            try
            {
                var profile = _SecurityLoginsLogLogicInstance.Get(id);
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
        [Route("security/{ SecurityLoginsLogId}")]
        public ActionResult PostSecurityLoginLog(SecurityLoginsLogPoco[] profile)
        {
            try
            {
                _SecurityLoginsLogLogicInstance.Add(profile);
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
        [Route("security/{SecurityLoginsLogId}")]
        public ActionResult PutSecurityLoginLog(SecurityLoginsLogPoco[] profile)
        {
            try
            {
                _SecurityLoginsLogLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("security/{ SecurityLoginsLogId}")]
        public ActionResult DeleteSecurityLoginLog(SecurityLoginsLogPoco[] profile)
        {
            try
            {
                _SecurityLoginsLogLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
