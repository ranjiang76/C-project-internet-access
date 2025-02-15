using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Grpc.Core;
using CareerCloud.gRPC.Protos;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;
namespace CareerCloud.gRPC.Services
{
    public class ApplicantProfileService: ApplicantProfile.ApplicantProfileBase
    {
        private readonly ApplicantProfileLogic _repository;

        public ApplicantProfileService()
        {
            var repository = new EFGenericRepository<ApplicantProfilePoco>();
            _repository = new ApplicantProfileLogic(repository);
        }

        public override Task<ApplicantProfileReply> GetApplicantProfile(ApplicantProfileId request, ServerCallContext context)
        {
            ApplicantProfilePoco poco = _repository.Get(Guid.Parse(request.Id));
            return base.GetApplicantProfile(request, context);
        }

        private ApplicantProfileReply FromPoco(ApplicantProfilePoco poco)
        {
            return new ApplicantProfileReply()
            {
                Id = poco.Id.ToString(),
                Login = poco.Login.ToString(),
                CurrentSalary = (int)poco.CurrentSalary,
                CurrentRate = (float)poco.CurrentRate,
                Currency=poco.Currency.ToString(),
                Country = poco.Country.ToString(),
                Province = poco.Province.ToString(),
                Street = poco.Street.ToString(),
                City = poco.City.ToString(),
                PostalCode = poco.PostalCode.ToString(),
                TimeStamp = ByteString.CopyFrom(poco.TimeStamp),
            };
        }

        private ApplicantProfilePoco ToPoco(ApplicantProfileRequest reply)
        {
            return new ApplicantProfilePoco()
            {
                Id = Guid.Parse(reply.Id),
                Login = Guid.Parse(reply.Login),
                CurrentSalary = reply.CurrentSalary,
                CurrentRate = (decimal)reply.CurrentRate,
                Currency = reply.Currency.ToString(),
                Country = reply.Country.ToString(),
                Province = reply.Province.ToString(),
                Street = reply.Street.ToString(),
                City = reply.City.ToString(),
                PostalCode = reply.PostalCode.ToString(),
            };
        }

        public override Task<Empty> AddApplicantProfile(ApplicantProfileRequest request, ServerCallContext context)
        {
            ApplicantProfilePoco _applicantProfile;

            _applicantProfile = ToPoco(request);

            _repository.Add(new ApplicantProfilePoco[] { _applicantProfile });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateApplicantProfile(ApplicantProfileRequest request, ServerCallContext context)
        {
            ApplicantProfilePoco _applicantProfile;

            _applicantProfile = ToPoco(request);

            _repository.Update(new ApplicantProfilePoco[] { _applicantProfile });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteApplicantProfile(ApplicantProfileRequest request, ServerCallContext context)
        {
            ApplicantProfilePoco _applicantProfile;

            _applicantProfile = ToPoco(request);
            _repository.Delete(new ApplicantProfilePoco[] { _applicantProfile });

            return Task.FromResult(new Empty());
        }

    }
}
