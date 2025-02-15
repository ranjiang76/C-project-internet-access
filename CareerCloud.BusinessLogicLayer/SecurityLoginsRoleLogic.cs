using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityLoginsRoleLogic : BaseLogic<SecurityLoginsRolePoco>
    {
        public SecurityLoginsRoleLogic(IDataRepository<SecurityLoginsRolePoco> repository) : base(repository)
        {
        }

        public override void Add(SecurityLoginsRolePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(SecurityLoginsRolePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(SecurityLoginsRolePoco[] pocos)
        {
            List<ValidationException> liexcepiton = new List<ValidationException>();

            foreach (var item in pocos)
            {
                if (item.Role == Guid.Empty)
                {
                    liexcepiton.Add(new ValidationException(800, $" Role {item.Role} cannot be empty."));
                }

            }

            if (liexcepiton.Count > 0)
            {
                throw new AggregateException(liexcepiton);
            }
        }
    }
}
