using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Grpc.Core;
using CareerCloud.gRPC.Protos;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;


namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginService: SecurityLogin.SecurityLoginBase
    {
        private readonly SecurityLoginLogic _repository;

        public SecurityLoginService()
        {
            var repository = new EFGenericRepository<SecurityLoginPoco>();
            _repository = new SecurityLoginLogic(repository);
        }

        public override Task<SecurityLoginReply> GetSecurityLogin(SecurityLoginId request, ServerCallContext context)
        {
            SecurityLoginPoco poco = _repository.Get(Guid.Parse(request.Id));
            return base.GetSecurityLogin(request, context);
        }

        private SecurityLoginReply FromPoco(SecurityLoginPoco poco)
        {
            return new SecurityLoginReply()
            {
                Id = poco.Id.ToString(),
                PasswordUpdate = poco.PasswordUpdate == null ? null : Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.PasswordUpdate,
                    DateTimeKind.Utc)),
                AgreementAccepted = poco.AgreementAccepted == null ? null : Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.AgreementAccepted,
                    DateTimeKind.Utc)),
                IsLocked = poco.IsLocked,
                IsInactive = poco.IsInactive,
                EmailAddress = poco.EmailAddress,
                PhoneNumber = poco.PhoneNumber,
                FullName = poco.FullName.ToString(),
                ForceChangePassword = poco.ForceChangePassword,
                PrefferredLanguage = poco.PrefferredLanguage.ToString(),
                Login = poco.Login.ToString(),
                Password = poco.Password.ToString(),
                TimeStamp = ByteString.CopyFrom(poco.TimeStamp),
            };
        }

        private SecurityLoginPoco ToPoco(SecurityLoginRequest reply)
        {
            return new SecurityLoginPoco()
            {
                Id = Guid.Parse(reply.Id),
                PasswordUpdate = reply.PasswordUpdate.ToDateTime(),
                AgreementAccepted = reply.AgreementAccepted.ToDateTime(),
                IsLocked = reply.IsLocked,
                IsInactive = reply.IsInactive,
                EmailAddress = reply.EmailAddress,
                PhoneNumber = reply.PhoneNumber,
                FullName = reply.FullName,
                ForceChangePassword = reply.ForceChangePassword,
                PrefferredLanguage = reply.PrefferredLanguage,
                Login = reply.Login,
                Password = reply.Password,
            };
        }

        public override Task<Empty> AddSecurityLogin(SecurityLoginRequest request, ServerCallContext context)
        {
            SecurityLoginPoco _securityLogin;

            _securityLogin = ToPoco(request);

            _repository.Add(new SecurityLoginPoco[] { _securityLogin });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateSecurityLogin(SecurityLoginRequest request, ServerCallContext context)
        {
            SecurityLoginPoco _securityLogin;

            _securityLogin = ToPoco(request);

            _repository.Update(new SecurityLoginPoco[] { _securityLogin });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteSecurityLogin(SecurityLoginRequest request, ServerCallContext context)
        {
            SecurityLoginPoco _securityLogin;

            _securityLogin = ToPoco(request);
            _repository.Delete(new SecurityLoginPoco[] { _securityLogin });

            return Task.FromResult(new Empty());
        }
    }
}
