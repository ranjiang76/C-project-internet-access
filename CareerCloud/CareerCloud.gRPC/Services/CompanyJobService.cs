using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Grpc.Core;
using CareerCloud.gRPC.Protos;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobService:CompanyJob.CompanyJobBase
    {
        private readonly CompanyJobLogic _repository;

        public CompanyJobService()
        {
            var repository = new EFGenericRepository<CompanyJobPoco>();
            _repository = new CompanyJobLogic(repository);
        }

        public override Task<CompanyJobReply> GetCompanyJob(CompanyJobId request, ServerCallContext context)
        {
            CompanyJobPoco poco = _repository.Get(Guid.Parse(request.Id));
            return base.GetCompanyJob(request, context);
        }

        private CompanyJobReply FromPoco(CompanyJobPoco poco)
        {
            return new CompanyJobReply()
            {
                Id = poco.Id.ToString(),

                Company = poco.Company.ToString(),
                ProfileCreated = poco.ProfileCreated == null ? null : Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.ProfileCreated,
                    DateTimeKind.Utc)),
                IsInactive =poco.IsInactive,
                IsCompanyHidden = poco.IsCompanyHidden,
                TimeStamp = ByteString.CopyFrom(poco.TimeStamp),
            };
        }

        private CompanyJobPoco ToPoco(CompanyJobRequest reply)
        {
            return new CompanyJobPoco()
            {
                Id = Guid.Parse(reply.Id),
                Company = Guid.Parse(reply.Company),
                ProfileCreated = reply.ProfileCreated.ToDateTime(),
                IsInactive = reply.IsInactive,
                IsCompanyHidden = reply.IsCompanyHidden,
            };
        }

        public override Task<Empty> AddCompanyJob(CompanyJobRequest request, ServerCallContext context)
        {
            CompanyJobPoco _applicantEducation;

            _applicantEducation = ToPoco(request);

            _repository.Add(new CompanyJobPoco[] { _applicantEducation });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateCompanyJob(CompanyJobRequest request, ServerCallContext context)
        {
            CompanyJobPoco _applicantEducation;

            _applicantEducation = ToPoco(request);

            _repository.Update(new CompanyJobPoco[] { _applicantEducation });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteCompanyJob(CompanyJobRequest request, ServerCallContext context)
        {
            CompanyJobPoco _applicantEducation;

            _applicantEducation = ToPoco(request);
            _repository.Delete(new CompanyJobPoco[] { _applicantEducation });

            return Task.FromResult(new Empty());
        }
    }
}
