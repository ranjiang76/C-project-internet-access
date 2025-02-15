using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    public class ApplicantResumeController : ControllerBase
    {
        private ApplicantResumeLogic _ApplicantResumeLogicInstance;
        public ApplicantResumeController()
        {
            EFGenericRepository<ApplicantResumePoco> repository = new EFGenericRepository<ApplicantResumePoco>();
            _ApplicantResumeLogicInstance = new ApplicantResumeLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _ApplicantResumeLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("applicant/{ApplicantResumeId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetApplicantResume(Guid id)
        {
            try
            {
                var profile = _ApplicantResumeLogicInstance.Get(id);
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
        [Route("applicant,/{ApplicantResumeId}")]
        public ActionResult PostApplicantResume(ApplicantResumePoco[] profile)
        {
            try
            {
                _ApplicantResumeLogicInstance.Add(profile);
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
        [Route("applicant/{ApplicantResumeId}")]
        public ActionResult PutApplicantResume(ApplicantResumePoco[] profile)
        {
            try
            {
                _ApplicantResumeLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("applicant/{ApplicantResumeId}")]
        public ActionResult DeleteApplicantResume(ApplicantResumePoco[] profile)
        {
            try
            {
                _ApplicantResumeLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
