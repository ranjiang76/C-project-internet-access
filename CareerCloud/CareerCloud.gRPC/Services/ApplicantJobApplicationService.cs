using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Grpc.Core;
using CareerCloud.gRPC.Protos;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;


namespace CareerCloud.gRPC.Services
{

        public class ApplicantJobApplicationService:ApplicantJobApplicantion.ApplicantJobApplicantionBase
        {
            private readonly ApplicantJobApplicationLogic _repository;

            public ApplicantJobApplicationService()
            {
                var repository = new EFGenericRepository<ApplicantJobApplicationPoco>();
                _repository = new ApplicantJobApplicationLogic(repository);
            }

            public override Task<ApplicantJobApplicantionReply> GetApplicantJobApplicantion(ApplicantJobApplicantionId request, ServerCallContext context)
            {
                ApplicantJobApplicationPoco poco = _repository.Get(Guid.Parse(request.Id));
                return base.GetApplicantJobApplicantion(request, context);
            }

            private ApplicantJobApplicantionReply FromPoco(ApplicantJobApplicationPoco poco)
            {
                return new ApplicantJobApplicantionReply()
                {
                    Id = poco.Id.ToString(),
                    Applicant = poco.Applicant.ToString(),
                    Job = poco.Job.ToString(),
                    ApplicationDate = poco.ApplicationDate == null ? null : Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.ApplicationDate,
                        DateTimeKind.Utc)),
                    TimeStamp = ByteString.CopyFrom(poco.TimeStamp),
                };
            }

            private ApplicantJobApplicationPoco ToPoco(ApplicantJobApplicantionRequest reply)
            {
                return new ApplicantJobApplicationPoco()
                {
                    Id = Guid.Parse(reply.Id),
                    Applicant = Guid.Parse(reply.Applicant),
                    Job = Guid.Parse(reply.Job),
                    ApplicationDate = reply.ApplicationDate.ToDateTime(),

                };
            }

            public override Task<Empty> AddApplicantJobApplicantion(ApplicantJobApplicantionRequest request, ServerCallContext context)
            {
                ApplicantJobApplicationPoco _applicantEducation;

                _applicantEducation = ToPoco(request);

                _repository.Add(new ApplicantJobApplicationPoco[] { _applicantEducation });


                return Task.FromResult(new Empty());
            }

            public override Task<Empty> UpdateApplicantJobApplicantion(ApplicantJobApplicantionRequest request, ServerCallContext context)
            {
                ApplicantJobApplicationPoco _applicantEducation;

                _applicantEducation = ToPoco(request);

                _repository.Update(new ApplicantJobApplicationPoco[] { _applicantEducation });


                return Task.FromResult(new Empty());
            }

            public override Task<Empty> DeleteApplicantJobApplicantion(ApplicantJobApplicantionRequest request, ServerCallContext context)
            {
                ApplicantJobApplicationPoco _applicantEducation;

                _applicantEducation = ToPoco(request);
                _repository.Delete(new ApplicantJobApplicationPoco[] { _applicantEducation });

                return Task.FromResult(new Empty());
            }

        }
}
