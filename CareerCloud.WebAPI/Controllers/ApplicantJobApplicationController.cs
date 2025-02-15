using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    public class ApplicantJobApplicationController : ControllerBase
    {
        private ApplicantJobApplicationLogic _ApplicantJobApplicationLogicInstance;
        public ApplicantJobApplicationController( )
        {
            EFGenericRepository<ApplicantJobApplicationPoco> repository = new EFGenericRepository<ApplicantJobApplicationPoco>();
            _ApplicantJobApplicationLogicInstance = new ApplicantJobApplicationLogic(repository);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _ApplicantJobApplicationLogicInstance.GetAll();
            return Ok(profile);
        }

        [Route("applicant/{ApplicantJobApplicationId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetApplicantJobApplication(Guid id)
        {
            try
            {
                var profile = _ApplicantJobApplicationLogicInstance.Get(id);
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
        [Route("applicant,/{ApplicantJobApplicationId}")]
        public ActionResult PostApplicantJobApplication(ApplicantJobApplicationPoco[] profile)
        {
            try
            {
                _ApplicantJobApplicationLogicInstance.Add(profile);
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
        [Route("applicant/{ApplicantJobApplicationId}")]
        public ActionResult PutApplicantJobApplication(ApplicantJobApplicationPoco[] profile)
        {
            try
            {
                _ApplicantJobApplicationLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("applicant/{ApplicantJobApplicationId}")]
        public ActionResult DeleteApplicantJobApplication(ApplicantJobApplicationPoco[] profile)
        {
            try
            {
                _ApplicantJobApplicationLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
