using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/security/v1")]
    public class SecurityLoginController : ControllerBase
    {
        private SecurityLoginLogic _SecurityLoginLogicInstance;
        public SecurityLoginController()
        {
            EFGenericRepository<SecurityLoginPoco> repository = new EFGenericRepository<SecurityLoginPoco>();
            _SecurityLoginLogicInstance = new SecurityLoginLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _SecurityLoginLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("security/{ SecurityLoginId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetSecurityLogin(Guid id)
        {
            try
            {
                var profile = _SecurityLoginLogicInstance.Get(id);
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
        [Route("security/{ SecurityLoginId}")]
        public ActionResult PostSecurityLogin(SecurityLoginPoco[] profile)
        {
            try
            {
                _SecurityLoginLogicInstance.Add(profile);
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
        [Route("security/{SecurityLoginId}")]
        public ActionResult PutSecurityLogin(SecurityLoginPoco[] profile)
        {
            try
            {
                _SecurityLoginLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("security/{ SecurityLoginId}")]
        public ActionResult DeleteSecurityLogin(SecurityLoginPoco[] profile)
        {
            try
            {
                _SecurityLoginLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }

}
