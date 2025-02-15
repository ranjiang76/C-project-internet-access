using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    public class ApplicantWorkHistoryController : ControllerBase
    {
        private ApplicantWorkHistoryLogic _ApplicantWorkHistoryLogicInstance;
        public ApplicantWorkHistoryController()
        {
            EFGenericRepository<ApplicantWorkHistoryPoco> repository = new EFGenericRepository<ApplicantWorkHistoryPoco>();
            _ApplicantWorkHistoryLogicInstance = new ApplicantWorkHistoryLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _ApplicantWorkHistoryLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("applicant/{ApplicantWorkHistoryId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetApplicantWorkHistory(Guid id)
        {
            try
            {
                var profile = _ApplicantWorkHistoryLogicInstance.Get(id);
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
        [Route("applicant/{ApplicantWorkHistoryId}")]
        public ActionResult PostApplicantWorkHistory(ApplicantWorkHistoryPoco[] profile)
        {
            try
            {
                _ApplicantWorkHistoryLogicInstance.Add(profile);
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
        [Route("applicant/{ApplicantWorkHistoryId}")]
        public ActionResult PutApplicantWorkHistory(ApplicantWorkHistoryPoco[] profile)
        {
            try
            {
                _ApplicantWorkHistoryLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("applicant/{ApplicantWorkHistoryId}")]
        public ActionResult DeleteApplicantWorkHistory(ApplicantWorkHistoryPoco[] profile)
        {
            try
            {
                _ApplicantWorkHistoryLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
