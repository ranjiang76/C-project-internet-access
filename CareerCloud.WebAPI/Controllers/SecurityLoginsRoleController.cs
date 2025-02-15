using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    public class SecurityLoginsRoleController : ControllerBase
    {
        private SecurityLoginsRoleLogic _SecurityLoginsRoleLogicInstance;
        public SecurityLoginsRoleController()
        {
            EFGenericRepository<SecurityLoginsRolePoco> repository = new EFGenericRepository<SecurityLoginsRolePoco>();
            _SecurityLoginsRoleLogicInstance = new SecurityLoginsRoleLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _SecurityLoginsRoleLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("security/{ SecurityLoginsRoleLogId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetSecurityLoginsRole(Guid id)
        {
            try
            {
                var profile = _SecurityLoginsRoleLogicInstance.Get(id);
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
        [Route("security/{ SecurityLoginsRoleId}")]
        public ActionResult PostSecurityLoginRole(SecurityLoginsRolePoco[] profile)
        {
            try
            {
                _SecurityLoginsRoleLogicInstance.Add(profile);
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
        [Route("security/{SecurityLoginsRoleId}")]
        public ActionResult PutSecurityLoginsRole(SecurityLoginsRolePoco[] profile)
        {
            try
            {
                _SecurityLoginsRoleLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("security/{SecurityLoginsRoleId}")]
        public ActionResult DeleteSecurityLoginRole(SecurityLoginsRolePoco[] profile)
        {
            try
            {
                _SecurityLoginsRoleLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
