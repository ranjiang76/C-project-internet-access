using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
    {
        public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyLocationPoco[] pocos)
        {
            List<ValidationException> liexcepiton = new List<ValidationException>();

            foreach (var item in pocos)
            {
                if (string.IsNullOrEmpty(item.CountryCode))
                {
                    liexcepiton.Add(new ValidationException(500, $" CountryCode {item.CountryCode} CountryCode cannot be empty."));
                }

                if (string.IsNullOrEmpty(item.Province))
                {
                    liexcepiton.Add(new ValidationException(501, $" Province {item.Province} Province cannot be empty."));
                }

                if (string.IsNullOrEmpty(item.Street))
                {
                    liexcepiton.Add(new ValidationException(502, $" Street {item.Street} Street cannot be empty."));
                }

                if (string.IsNullOrEmpty(item.City))
                {
                    liexcepiton.Add(new ValidationException(503, $" City {item.City} City cannot be empty."));
                }

                if (string.IsNullOrEmpty(item.PostalCode))
                {
                    liexcepiton.Add(new ValidationException(504, $" PostalCode {item.PostalCode} PostalCode cannot be empty."));
                }
            }

            if (liexcepiton.Count > 0)
            {
                throw new AggregateException(liexcepiton);
            }
        }
    }
}
