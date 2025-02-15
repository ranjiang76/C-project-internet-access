using Microsoft.AspNetCore.Mvc;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
//using static System.Runtime.InteropServices.JavaScript.JSType;
using CareerCloud.WebAPI.Exceptions;
using CareerCloud.ADODataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ApplicantEducationController : ControllerBase
    {
        private ApplicantEducationLogic _ApplicantEducationLogicInstance;


        public ApplicantEducationController()
        {
            EFGenericRepository<ApplicantEducationPoco> repository = new EFGenericRepository<ApplicantEducationPoco>();
            _ApplicantEducationLogicInstance = new ApplicantEducationLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _ApplicantEducationLogicInstance.GetAll();
            return Ok(profile);
        }

        [Route("education/{applicantEducationId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetApplicantEducation(Guid id)//Get everything
        {
            try
            {
                var profile = _ApplicantEducationLogicInstance.Get(id);
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
        [Route("education/{applicantEducationId}")]
        public ActionResult PostApplicantEducation(ApplicantEducationPoco[] profile)
        {
            try
            {
                _ApplicantEducationLogicInstance.Add(profile);
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
        [Route("education/{applicantEducationId}")]
        public ActionResult PutApplicantEducation(ApplicantEducationPoco[] profile)
        {
            try
            {
                 _ApplicantEducationLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("education/{applicantEducationId}")]
        public ActionResult DeleteApplicantEducation(ApplicantEducationPoco[] profile)
        {
            try
            {
                _ApplicantEducationLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
