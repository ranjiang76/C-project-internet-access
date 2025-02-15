using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Grpc.Core;
using CareerCloud.gRPC.Protos;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;


namespace CareerCloud.gRPC.Services
{
    public class CompanyJobEducationService: CompanyJobEducation.CompanyJobEducationBase
    {
        private readonly CompanyJobEducationLogic _repository;

        public CompanyJobEducationService()
        {
            var repository = new EFGenericRepository<CompanyJobEducationPoco>();
            _repository = new CompanyJobEducationLogic(repository);
        }

        public override Task<CompanyJobEducationReply> GetCompanyJobEducation(CompanyJobEducatioId request, ServerCallContext context)
        {
            CompanyJobEducationPoco poco = _repository.Get(Guid.Parse(request.Id));
            return base.GetCompanyJobEducation(request, context);
        }

        private CompanyJobEducationReply FromPoco(CompanyJobEducationPoco poco)
        {
            return new CompanyJobEducationReply()
            {
                Id = poco.Id.ToString(),
                Major = poco.Major.ToString(),
                Importance = poco.Importance,
                Job = poco.Job.ToString(),
                TimeStamp = ByteString.CopyFrom(poco.TimeStamp),
            };
        }

        private CompanyJobEducationPoco ToPoco(CompanyJobEducationRequest reply)
        {
            return new CompanyJobEducationPoco()
            {
                Id = Guid.Parse(reply.Id),
                Major = reply.Major,
                Importance = (short)reply.Importance,
                Job = Guid.Parse(reply.Job),
            };
        }

        public override Task<Empty> AddCompanyJobEducation(CompanyJobEducationRequest request, ServerCallContext context)
        {
            CompanyJobEducationPoco _companyJobEducation;

            _companyJobEducation = ToPoco(request);

            _repository.Add(new CompanyJobEducationPoco[] { _companyJobEducation });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateCompanyJobEducation(CompanyJobEducationRequest request, ServerCallContext context)
        {
            CompanyJobEducationPoco _companyJobEducation;

            _companyJobEducation = ToPoco(request);

            _repository.Update(new CompanyJobEducationPoco[] { _companyJobEducation });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteCompanyJobEducation(CompanyJobEducationRequest request, ServerCallContext context)
        {
            CompanyJobEducationPoco _companyJobEducation;

            _companyJobEducation = ToPoco(request);
            _repository.Delete(new CompanyJobEducationPoco[] { _companyJobEducation });

            return Task.FromResult(new Empty());
        }

    }
}
