using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> liexcepiton = new List<ValidationException>();

            foreach (var item in pocos)
            {
                string sPattern = "^\\d{3}-\\d{3}-\\d{4}$";

                if (string.IsNullOrEmpty(item.CompanyWebsite))
                {
                    liexcepiton.Add(new ValidationException(600, $" CompanyWebsite {item.CompanyWebsite} Valid websites must end with the following extensions – \".ca\", \".com\", \".biz\"."));
                }
                else if (!item.CompanyWebsite.EndsWith(".ca")&& !item.CompanyWebsite.EndsWith(".com")&& !item.CompanyWebsite.EndsWith(".biz"))
                {
                    liexcepiton.Add(new ValidationException(600, $" CompanyWebsite {item.CompanyWebsite} Valid websites must end with the following extensions – \".ca\", \".com\", \".biz\"."));
                }

                if (string.IsNullOrEmpty(item.ContactPhone))
                {
                    liexcepiton.Add(new ValidationException(601, $" ContactPhone {item.ContactPhone} Must correspond to a valid phone number (e.g. 416-555-1234)."));
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(item.ContactPhone, sPattern))
                {
                    liexcepiton.Add(new ValidationException(601, $" ContactPhone {item.ContactPhone} Must correspond to a valid phone number (e.g. 416-555-1234)."));
                }

            }

            if (liexcepiton.Count > 0)
            {
                throw new AggregateException(liexcepiton);
            }
        }
    }
}
