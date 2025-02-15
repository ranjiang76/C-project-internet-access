using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        {
        }
        public override void Add(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> liexcepiton = new List<ValidationException>();

            foreach (var item in pocos)
            {
                if (string.IsNullOrEmpty(item.CompanyName)||(item.CompanyName.Length < 3))
                {
                    liexcepiton.Add(new ValidationException(106, $" CompanyName {item.CompanyName} must be greater then 2 characters."));
                }

                if (string.IsNullOrEmpty(item.CompanyDescription) ||(item.CompanyDescription.Length < 3))
                {
                    liexcepiton.Add(new ValidationException(107, $" CompanyDescription {item.CompanyDescription} must be greater then 2 characters."));
                }
            }

            if (liexcepiton.Count > 0)
            {
                throw new AggregateException(liexcepiton);
            }
        }

    }
}
