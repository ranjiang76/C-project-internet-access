using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    public class SystemLanguageCodeController : ControllerBase
    {
        private SystemLanguageCodeLogic _SystemLanguageCodeLogicInstance;
        public SystemLanguageCodeController()
        {
            EFGenericRepository<SystemLanguageCodePoco> repository = new EFGenericRepository<SystemLanguageCodePoco>();
            _SystemLanguageCodeLogicInstance = new SystemLanguageCodeLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _SystemLanguageCodeLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("system/{ SystemLanguageCodeLanguageID}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetSystemLanguageCode(string LanguageID)
        {
            try
            {
                var profile = _SystemLanguageCodeLogicInstance.Get(LanguageID);
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
        [Route("system/{ SystemLanguageCodeLanguageID}")]
        public ActionResult PostSystemLanguageCode(SystemLanguageCodePoco[] profile)
        {
            try
            {
                _SystemLanguageCodeLogicInstance.Add(profile);
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
        [Route("system/{SystemLanguageCodeLanguageID}")]
        public ActionResult PutSystemLanguageCode(SystemLanguageCodePoco[] profile)
        {
            try
            {
                _SystemLanguageCodeLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("system/{SystemLanguageCodeLanguageID}")]
        public ActionResult DeleteSystemLanguageCode(SystemLanguageCodePoco[] profile)
        {
            try
            {
                _SystemLanguageCodeLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
