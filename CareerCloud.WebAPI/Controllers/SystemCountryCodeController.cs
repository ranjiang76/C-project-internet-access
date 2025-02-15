using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    public class SystemCountryCodeController : ControllerBase
    {
        private SystemCountryCodeLogic _SystemCountryCodeLogicInstance;
        public SystemCountryCodeController()
        {
            EFGenericRepository<SystemCountryCodePoco> repository = new EFGenericRepository<SystemCountryCodePoco>();
            _SystemCountryCodeLogicInstance = new SystemCountryCodeLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _SystemCountryCodeLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("system/{ SystemCountryCodeCode}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetSystemCountryCode(string Code)
        {
            try
            {
                var profile = _SystemCountryCodeLogicInstance.Get(Code);
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
        [Route("system/{ SystemCountryCodeCode}")]
        public ActionResult PostSystemCountryCode(SystemCountryCodePoco[] profile)
        {
            try
            {
                _SystemCountryCodeLogicInstance.Add(profile);
                //return Created($"api/SystemCountryCode/{profile[0].Code}", profile);
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
        [Route("system/{SystemCountryCodeCode}")]
        public ActionResult PutSystemCountryCode(SystemCountryCodePoco[] profile)
        {
            try
            {
                _SystemCountryCodeLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("system/{SystemCountryCodeCode}")]
        public ActionResult DeleteSystemCountryCode(SystemCountryCodePoco[] profile)
        {
            try
            {
                _SystemCountryCodeLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }

}
