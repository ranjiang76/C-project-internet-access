using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    public class SecurityRoleController : ControllerBase
    {
        private SecurityRoleLogic _SecurityRoleLogicInstance;
        public SecurityRoleController()
        {
            EFGenericRepository<SecurityRolePoco> repository = new EFGenericRepository<SecurityRolePoco>();
            _SecurityRoleLogicInstance = new SecurityRoleLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _SecurityRoleLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("security/{ SecurityRoleId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetSecurityRole(Guid id)
        {
            try
            {
                var profile = _SecurityRoleLogicInstance.Get(id);
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
        [Route("security/{ SecurityRoleId}")]
        public ActionResult PostSecurityRole(SecurityRolePoco[] profile)
        {
            try
            {
                _SecurityRoleLogicInstance.Add(profile);
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
        [Route("security/{SecurityRoleId}")]
        public ActionResult PutSecurityRole(SecurityRolePoco[] profile)
        {
            try
            {
                _SecurityRoleLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("security/{SecurityRoleId}")]
        public ActionResult DeleteSecurityRole(SecurityRolePoco[] profile)
        {
            try
            {
                _SecurityRoleLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
