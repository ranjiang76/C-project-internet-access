using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Grpc.Core;
using CareerCloud.gRPC.Protos;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;


namespace CareerCloud.gRPC.Services
{
    public class SystemLanguageCodeService: SystemLanguageCode.SystemLanguageCodeBase
    {
        private readonly SystemLanguageCodeLogic _repository;

        public SystemLanguageCodeService()
        {
            var repository = new EFGenericRepository<SystemLanguageCodePoco>();
            _repository = new SystemLanguageCodeLogic(repository);
        }

        public override Task<SystemLanguageCodeMessage> GetSystemLanguageCode(SystemLanguageCodeId request, ServerCallContext context)
        {
            SystemLanguageCodePoco poco = _repository.Get(request.LanguageID);
            return base.GetSystemLanguageCode(request, context);
        }

        private SystemLanguageCodeMessage FromPoco(SystemLanguageCodePoco poco)
        {
            return new SystemLanguageCodeMessage()
            {
                LanguageID=poco.LanguageID.ToString(),
                NativeName=poco.NativeName.ToString(),
                Name=poco.Name.ToString(),
            };
        }

        private SystemLanguageCodePoco ToPoco(SystemLanguageCodeMessage reply)
        {
            return new SystemLanguageCodePoco()
            {
                LanguageID = reply.LanguageID,
                NativeName = reply.NativeName,
                Name = reply.Name,
            };
        }

        public override Task<Empty> AddSystemLanguageCode(SystemLanguageCodeMessage request, ServerCallContext context)
        {
            SystemLanguageCodePoco _systemLanguageCode;

            _systemLanguageCode = ToPoco(request);

            _repository.Add(new SystemLanguageCodePoco[] { _systemLanguageCode });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateSystemLanguageCode(SystemLanguageCodeMessage request, ServerCallContext context)
        {
            SystemLanguageCodePoco _systemLanguageCode;

            _systemLanguageCode = ToPoco(request);

            _repository.Update(new SystemLanguageCodePoco[] { _systemLanguageCode });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteSystemLanguageCode(SystemLanguageCodeMessage request, ServerCallContext context)
        {
            SystemLanguageCodePoco _systemLanguageCode;

            _systemLanguageCode = ToPoco(request);
            _repository.Delete(new SystemLanguageCodePoco[] { _systemLanguageCode });

            return Task.FromResult(new Empty());
        }
    }
}
