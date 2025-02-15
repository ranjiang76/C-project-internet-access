using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantSkillLogic : BaseLogic<ApplicantSkillPoco>
    {
        public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : base(repository)
        {
        }
        public override void Add(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantSkillPoco[] pocos)
        {
            List<ValidationException> liexcepiton = new List<ValidationException>();

            foreach (var item in pocos)
            {
                int startmonth = item.StartMonth;
                if (startmonth > 12)
                {
                    liexcepiton.Add(new ValidationException(101, $" ApplicantSkill {item.StartMonth} Cannot be greater than 12."));
                }

                int endmonth = item.EndMonth;
                if (endmonth > 12)
                {
                    liexcepiton.Add(new ValidationException(102, $" ApplicantSkill {item.EndMonth} Cannot be greater than 12."));
                }

                if (item.StartYear < 1900)
                {
                    liexcepiton.Add(new ValidationException(103, $" ApplicantSkill {item.StartYear} Cannot be less then 1900."));
                }

                if (item.EndYear < item.StartYear)
                {
                    liexcepiton.Add(new ValidationException(104, $" ApplicantSkill {item.EndYear} Cannot be less then StartYear."));
                }
            }

            if (liexcepiton.Count > 0)
            {
                throw new AggregateException(liexcepiton);
            }
        }
    }
}
