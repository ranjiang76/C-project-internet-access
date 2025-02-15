using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantWorkHistoryLogic : BaseLogic<ApplicantWorkHistoryPoco>
    {
        public ApplicantWorkHistoryLogic(IDataRepository<ApplicantWorkHistoryPoco> repository) : base(repository)
        {
        }
        public override void Add(ApplicantWorkHistoryPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantWorkHistoryPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantWorkHistoryPoco[] pocos)
        {
            List<ValidationException> liexcepiton = new List<ValidationException>();

            foreach (var item in pocos)
            {
                if (item.CompanyName.Length<3)
                {
                    liexcepiton.Add(new ValidationException(105, $" ApplicantWorkHistory {item.CompanyName} Must be greater then 2 characters."));
                }
            }

            if (liexcepiton.Count > 0)
            {
                throw new AggregateException(liexcepiton);
            }
        }

    }
}
