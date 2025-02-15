using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Grpc.Core;
using CareerCloud.gRPC.Protos;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;


namespace CareerCloud.gRPC.Services
{
    public class CompanyDescriptionService: CompanyDescription.CompanyDescriptionBase
    {
        private readonly CompanyDescriptionLogic _repository;

        public CompanyDescriptionService()
        {
            var repository = new EFGenericRepository<CompanyDescriptionPoco>();
            _repository = new CompanyDescriptionLogic(repository);
        }

        public override Task<CompanyDescriptionReply> GetCompanyDescription(CompanyDescriptionId request, ServerCallContext context)
        {
            CompanyDescriptionPoco poco = _repository.Get(Guid.Parse(request.Id));
            return base.GetCompanyDescription(request, context);
        }

        private CompanyDescriptionReply FromPoco(CompanyDescriptionPoco poco)
        {
            return new CompanyDescriptionReply()
            {
                Id = poco.Id.ToString(),
                Company = poco.Company.ToString(),
                CompanyName = poco.CompanyName.ToString(),
                CompanyDescription = poco.CompanyDescription.ToString(),
                LanguageId = poco.LanguageId.ToString(),
                TimeStamp = ByteString.CopyFrom(poco.TimeStamp),
            };
        }

        private CompanyDescriptionPoco ToPoco(CompanyDescriptionRequest reply)
        {
            return new CompanyDescriptionPoco()
            {
                Id = Guid.Parse(reply.Id),
                Company = Guid.Parse(reply.Company),
                CompanyName = reply.CompanyName,
                CompanyDescription = reply.CompanyDescription,
                LanguageId = reply.LanguageId,
            };
        }

        public override Task<Empty> AddCompanyDescription(CompanyDescriptionRequest request, ServerCallContext context)
        {
            CompanyDescriptionPoco _companydescription;

            _companydescription = ToPoco(request);

            _repository.Add(new CompanyDescriptionPoco[] { _companydescription });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateCompanyDescription(CompanyDescriptionRequest request, ServerCallContext context)
        {
            CompanyDescriptionPoco _companydescription;

            _companydescription = ToPoco(request);

            _repository.Update(new CompanyDescriptionPoco[] { _companydescription });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteCompanyDescription(CompanyDescriptionRequest request, ServerCallContext context)
        {
            CompanyDescriptionPoco _companydescription;

            _companydescription = ToPoco(request);
            _repository.Delete(new CompanyDescriptionPoco[] { _companydescription });

            return Task.FromResult(new Empty());
        }
    }
}
