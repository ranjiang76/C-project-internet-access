using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobDescriptionLogic : BaseLogic<CompanyJobDescriptionPoco>
    {
        public CompanyJobDescriptionLogic(IDataRepository<CompanyJobDescriptionPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyJobDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyJobDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobDescriptionPoco[] pocos)
        {
            List<ValidationException> liexcepiton = new List<ValidationException>();

            foreach (var item in pocos)
            {
                if (string.IsNullOrEmpty(item.JobName))
                {
                    liexcepiton.Add(new ValidationException(300, $" JobName {item.JobName} JobName cannot be empty."));
                }

                if (string.IsNullOrEmpty(item.JobDescriptions))
                {
                    liexcepiton.Add(new ValidationException(301, $" JobDescriptions {item.JobDescriptions} JobDescriptions cannot be empty."));
                }
            }

            if (liexcepiton.Count > 0)
            {
                throw new AggregateException(liexcepiton);
            }
        }
    }
}
