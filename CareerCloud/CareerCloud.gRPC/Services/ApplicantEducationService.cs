using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Grpc.Core;
using CareerCloud.gRPC.Protos;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;


namespace CareerCloud.gRPC.Services
{
    public class ApplicantEducationService: ApplicantEducation.ApplicantEducationBase
    {
       
        private readonly ApplicantEducationLogic _repository;

        public ApplicantEducationService()
        {
           var repository = new EFGenericRepository<ApplicantEducationPoco>();
            _repository = new ApplicantEducationLogic(repository);
        }

        public override Task<ApplicantEducationReply> GetApplicantEducation(ApplicantEducationId request, ServerCallContext context)
        {
            ApplicantEducationPoco poco = _repository.Get(Guid.Parse(request.Id));
            return base.GetApplicantEducation(request, context);
        }

        private ApplicantEducationReply FromPoco(ApplicantEducationPoco poco) 
        {
            return new ApplicantEducationReply()
            {
                Id = poco.Id.ToString(),
                Applicant = poco.Applicant.ToString(),
                CertificateDiploma = poco.CertificateDiploma,
                Major = poco.Major,
                StartDate=poco.StartDate==null?null:Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.StartDate,
                    DateTimeKind.Utc)),
                CompletionDate=poco.CompletionDate==null?null:Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)poco.CompletionDate,
                    DateTimeKind.Utc)),
                CompletionPercent=poco.CompletionPercent==null?0:(byte)poco.CompletionPercent,
                TimeStamp=ByteString.CopyFrom(poco.TimeStamp),
            };
        }

        private ApplicantEducationPoco ToPoco(ApplicantEducationRequest reply)
        {
            return new ApplicantEducationPoco()
            {
                Id = Guid.Parse(reply.Id),
                Applicant = Guid.Parse(reply.Applicant),
                CertificateDiploma = reply.CertificateDiploma,
                Major = reply.Major,
                StartDate = reply.StartDate.ToDateTime(),
                CompletionDate = reply.CompletionDate.ToDateTime(),
                CompletionPercent = (byte?)reply.CompletionPercent,
            };   
        }

        public override Task<Empty> AddApplicantEducation(ApplicantEducationRequest request, ServerCallContext context)
        {
            ApplicantEducationPoco _applicantEducation;

            _applicantEducation = ToPoco(request);

            _repository.Add(new ApplicantEducationPoco[] { _applicantEducation });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateApplicantEducation(ApplicantEducationRequest request, ServerCallContext context)
        {
            ApplicantEducationPoco _applicantEducation;

            _applicantEducation = ToPoco(request);

            _repository.Update(new ApplicantEducationPoco[] { _applicantEducation });


            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteApplicantEducation(ApplicantEducationRequest request, ServerCallContext context)
        {
            ApplicantEducationPoco _applicantEducation;

            _applicantEducation = ToPoco(request);
            _repository.Delete(new ApplicantEducationPoco[] { _applicantEducation });

            return Task.FromResult(new Empty());
        }

    }
}
