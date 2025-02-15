using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic : CountryBaseLogic<SystemCountryCodePoco>
    {

        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository) : base(repository)
        {
        }

        public override void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> liexcepiton = new List<ValidationException>();

            foreach (var item in pocos)
            {
                if (string.IsNullOrEmpty(item.Code))
                {
                   
                    liexcepiton.Add(new ValidationException(900, $" Code {item.Code} cannot be empty."));

                }

                if (string.IsNullOrEmpty(item.Name))
                {
                    liexcepiton.Add(new ValidationException(901, $" Name {item.Name} cannot be empty."));

                }

            }

            if (liexcepiton.Count > 0)
            {
                throw new AggregateException(liexcepiton);
            }
        }

    }
}
