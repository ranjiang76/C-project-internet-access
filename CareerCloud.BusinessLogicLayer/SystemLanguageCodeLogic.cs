using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic : LanguageBaseLogic<SystemLanguageCodePoco>
    {
        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository) : base(repository)
        {
        }
        public override void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> liexcepiton = new List<ValidationException>();

            foreach (var item in pocos)
            {
                if (string.IsNullOrEmpty(item.LanguageID))
                {

                    liexcepiton.Add(new ValidationException(1000, $" LanguageID {item.LanguageID} cannot be empty."));

                }

                if (string.IsNullOrEmpty(item.Name))
                {
                    liexcepiton.Add(new ValidationException(1001, $" Name {item.Name} cannot be empty."));

                }

                if (string.IsNullOrEmpty(item.NativeName))
                {
                    liexcepiton.Add(new ValidationException(1002, $" NativeName {item.NativeName} cannot be empty."));

                }
            }

            if (liexcepiton.Count > 0)
            {
                throw new AggregateException(liexcepiton);
            }
        }

    }
}
