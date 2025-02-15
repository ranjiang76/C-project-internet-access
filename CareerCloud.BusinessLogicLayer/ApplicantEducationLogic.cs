using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> liexcepiton = new List<ValidationException>();

            foreach (var item in pocos)
            {
                if (string.IsNullOrEmpty(item.Major))
                {
                    liexcepiton.Add(new ValidationException(107, $"Major for ApplicantEducation {item.Major} cannot be null"));
                }
                else if (item.Major.Length < 3)
                {
                    liexcepiton.Add(new ValidationException(107, $"Major for ApplicantEducation {item.Major} must be at least 3 characters."));
                }

                DateTime dtnow = DateTime.Now;

                if (item.StartDate.HasValue)
                {
                    DateTime dtstart = (DateTime)item.StartDate;

                    if (DateTime.Compare(dtstart, dtnow) > 0)
                    {
                        liexcepiton.Add(new ValidationException(108, $"StartDate for ApplicantEducation {item.StartDate} cannot be greater than today."));
                    }

                    if (item.CompletionDate.HasValue)
                    {
                        DateTime dtcompletion = (DateTime)item.CompletionDate;
                        if (DateTime.Compare(dtcompletion, (DateTime)item.StartDate) < 0)
                        {
                            liexcepiton.Add(new ValidationException(109, $"CompletionDate for ApplicantEducation {item.CompletionDate} cannot be earlier than StartDate."));
                        }
                    }
                    else
                    {
                        liexcepiton.Add(new ValidationException(108, $"CompletionDate for ApplicantEducation {item.StartDate} cannot be null."));
                    }
                }
                else
                {
                    liexcepiton.Add(new ValidationException(108, $"StartDate for ApplicantEducation {item.StartDate} cannot be null."));

                    if (!item.CompletionDate.HasValue)
                    {
                        liexcepiton.Add(new ValidationException(108, $"CompletionDate for ApplicantEducation {item.StartDate} cannot be null."));
                    }
                }

            }

            if (liexcepiton.Count > 0)
            {
                throw new AggregateException(liexcepiton);
            }
        }

    }
}
