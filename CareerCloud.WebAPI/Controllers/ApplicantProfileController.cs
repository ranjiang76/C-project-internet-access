using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    public class ApplicantProfileController : ControllerBase
    {
        private ApplicantProfileLogic _ApplicantProfileLogicInstance;
        public ApplicantProfileController()
        {
            EFGenericRepository<ApplicantProfilePoco> repository = new EFGenericRepository<ApplicantProfilePoco>();
            _ApplicantProfileLogicInstance = new ApplicantProfileLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _ApplicantProfileLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("applicant/{ApplicantProfileId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetApplicantProfile(Guid id)
        {
            try
            {
                var profile = _ApplicantProfileLogicInstance.Get(id);
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
        [Route("applicant,/{ApplicantProfileId}")]
        public ActionResult PostApplicantProfile(ApplicantProfilePoco[] profile)
        {
            try
            {
                _ApplicantProfileLogicInstance.Add(profile);
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
        [Route("applicant/{ApplicantProfileId}")]
        public ActionResult PutApplicantProfile(ApplicantProfilePoco[] profile)
        {
            try
            {
                _ApplicantProfileLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("applicant/{ApplicantProfileId}")]
        public ActionResult DeleteApplicantProfile(ApplicantProfilePoco[] profile)
        {
            try
            {
                _ApplicantProfileLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

    }


}
