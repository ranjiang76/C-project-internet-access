using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    public class ApplicantSkillController : ControllerBase
    {
        private ApplicantSkillLogic _ApplicantSkillLogicInstance;
        public ApplicantSkillController()
        {
            EFGenericRepository<ApplicantSkillPoco> repository = new EFGenericRepository<ApplicantSkillPoco>();
            _ApplicantSkillLogicInstance = new ApplicantSkillLogic(repository);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profile = _ApplicantSkillLogicInstance.GetAll();
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [Route("applicant/{ApplicantSkillId}")]
        [HttpGet]
        //[ProducesResponseType]
        public ActionResult GetApplicantSkill(Guid id)
        {
            try
            {
                var profile = _ApplicantSkillLogicInstance.Get(id);
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
        [Route("applicant/{ApplicantSkillId}")]
        public ActionResult PostApplicantSkill(ApplicantSkillPoco[] profile)
        {
            try
            {
                _ApplicantSkillLogicInstance.Add(profile);
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
        [Route("applicant/{ApplicantSkillId}")]
        public ActionResult PutApplicantSkill(ApplicantSkillPoco[] profile)
        {
            try
            {
                _ApplicantSkillLogicInstance.Update(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("applicant/{ApplicantSkillId}")]
        public ActionResult DeleteApplicantSkill(ApplicantSkillPoco[] profile)
        {
            try
            {
                _ApplicantSkillLogicInstance.Delete(profile);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
