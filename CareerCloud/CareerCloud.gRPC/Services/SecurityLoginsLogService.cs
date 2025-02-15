using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Grpc.Core;
using CareerCloud.gRPC.Protos;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginsLogService:SecurityLoginsLog.SecurityLoginsLogBase
    {
        private readonly SecurityLoginsLogLogic _repository;

        public SecurityLoginsLogService()
        {
            var repository = new EFGenericRepository<SecurityLoginsLogPoco>();
            _repository = new SecurityLoginsLogLogic(repository);
        }

        public override Task<SecurityLoginsLogMessage> GetSecurityLoginsLog(SecurityLoginsLogId request, ServerCallContext context)
        {
            SecurityLoginsLogPoco poco = _repository.Get(Guid.Parse(request.Id));
            return base.GetSecurityLoginsLog(request, context);
        }

        private SecurityLoginsLogMessage FromPoco(SecurityLoginsLogPoco poco)
        {
            return new SecurityLoginsLogMessage()
            {
                Id = poco.Id.ToString(),
                SourceIP = poco.SourceIP.ToString(),
                LogonDate = poco.LogonDate == null ? null : Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.LogonDate,
                    DateTimeKind.Utc)),
                IsSuccesful = poco.IsSuccesful,
                Login = poco.Login.ToString(),
            };
        }

        private SecurityLoginsLogPoco ToPoco(SecurityLoginsLogMessage reply)
        {
            return new SecurityLoginsLogPoco()
            {
                Id = Guid.Parse(reply.Id),
                SourceIP = reply.SourceIP,
                LogonDate = reply.LogonDate.ToDateTime(),
                IsSuccesful = reply.IsSuccesful,
                Login = Guid.Parse(reply.Login),
            };
        }

        public override Task<Empty> AddSecurityLoginsLog(SecurityLoginsLogMessage request, ServerCallContext context)
        {
            SecurityLoginsLogPoco _securityLoginsLog;

            _securityLoginsLog = ToPoco(request);

            _repository.Add(new SecurityLoginsLogPoco[] { _securityLoginsLog });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateSecurityLoginsLog(SecurityLoginsLogMessage request, ServerCallContext context)
        {
            SecurityLoginsLogPoco _securityLoginsLog;

            _securityLoginsLog = ToPoco(request);

            _repository.Update(new SecurityLoginsLogPoco[] { _securityLoginsLog });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteSecurityLoginsLog(SecurityLoginsLogMessage request, ServerCallContext context)
        {
            SecurityLoginsLogPoco _securityLoginsLog;

            _securityLoginsLog = ToPoco(request);
            _repository.Delete(new SecurityLoginsLogPoco[] { _securityLoginsLog });

            return Task.FromResult(new Empty());
        }
    }
}
