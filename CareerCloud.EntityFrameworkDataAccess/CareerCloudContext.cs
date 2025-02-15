using Microsoft.EntityFrameworkCore;
using CareerCloud.Pocos;


namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public DbSet<ApplicantEducationPoco> ApplicantEducation { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplication { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfile { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResume { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkill { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescription { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducation { get; set; }
        public DbSet<CompanyJobPoco> CompanyJob { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkill { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocation { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfile { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogin { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLog { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRole { get; set; }
        public DbSet<SecurityRolePoco> SecurityRole { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCode { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCode { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=JOB_PORTAL_DB"); //(localdb)\mssqllocaldb;Database=Test ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicantEducationPoco>().HasOne(x => x.ApplicantProfile).WithMany(x => x.ApplicantEducations).HasForeignKey(x => x.Applicant);
            modelBuilder.Entity<ApplicantEducationPoco>().Ignore(c => c.TimeStamp);

            modelBuilder.Entity<ApplicantJobApplicationPoco>().HasOne(x => x.ApplicantProfile).WithMany(x => x.ApplicantJobApplications).HasForeignKey(x => x.Applicant);
            modelBuilder.Entity<ApplicantJobApplicationPoco>().HasOne(x => x.CompanyJob).WithMany(x => x.ApplicantJobApplications).HasForeignKey(x => x.Job);
            modelBuilder.Entity<ApplicantJobApplicationPoco>().Ignore(c => c.TimeStamp);


            modelBuilder.Entity<ApplicantProfilePoco>().HasOne(x => x.SystemCountryCode).WithMany(x => x.ApplicantProfiles).HasForeignKey(x => x.Country);
            modelBuilder.Entity<ApplicantProfilePoco>().HasOne(x => x.SecurityLogins).WithMany(x => x.ApplicantProfiles).HasForeignKey(x => x.Login);
            modelBuilder.Entity<ApplicantProfilePoco>().Ignore(c => c.TimeStamp);


            modelBuilder.Entity<ApplicantProfilePoco>().Ignore(c => c.TimeStamp);

            modelBuilder.Entity<ApplicantResumePoco>().HasOne(x => x.ApplicantProfile).WithMany(x => x.ApplicantResumes).HasForeignKey(x => x.Applicant);

            modelBuilder.Entity<ApplicantSkillPoco>().HasOne(x => x.ApplicantProfile).WithMany(x => x.ApplicantSkills).HasForeignKey(x => x.Applicant);
            modelBuilder.Entity<ApplicantSkillPoco>().Ignore(c => c.TimeStamp);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>().HasOne(x => x.SystemCountryCode).WithMany(x => x.ApplicantWorkHistorys).HasForeignKey(x => x.CountryCode);
            modelBuilder.Entity<ApplicantWorkHistoryPoco>().HasOne(x => x.ApplicantProfile).WithMany(x => x.ApplicantWorkHistorys).HasForeignKey(x => x.Applicant);
            modelBuilder.Entity<ApplicantWorkHistoryPoco>().Ignore(c => c.TimeStamp);

            modelBuilder.Entity<CompanyDescriptionPoco>().HasOne(x => x.CompanyProfile).WithMany(s => s.CompanyDescriptions).HasForeignKey(x => x.Company);
            modelBuilder.Entity<CompanyDescriptionPoco>().HasOne(x => x.SystemLanguageCode).WithMany(x => x.CompanyDescriptions).HasForeignKey(x => x.LanguageId);
            modelBuilder.Entity<CompanyDescriptionPoco>().Ignore(c => c.TimeStamp);


            modelBuilder.Entity<CompanyJobDescriptionPoco>().HasOne(x => x.CompanyJob).WithMany(x => x.CompanyJobDescriptions).HasForeignKey(x => x.Job);
            modelBuilder.Entity<CompanyJobDescriptionPoco>().Ignore(c => c.TimeStamp);

            modelBuilder.Entity<CompanyJobEducationPoco>().HasOne(x => x.CompanyJob).WithMany(x => x.CompanyJobEducations).HasForeignKey(x => x.Job);
            modelBuilder.Entity<CompanyJobEducationPoco>().Ignore(c => c.TimeStamp);

            modelBuilder.Entity<CompanyJobPoco>().HasOne(x => x.CompanyProfile).WithMany(x => x.CompanyJobs).HasForeignKey(x => x.Company);
            modelBuilder.Entity<CompanyJobPoco>().Ignore(c => c.TimeStamp);

            modelBuilder.Entity<CompanyJobSkillPoco>().HasOne(x => x.CompanyJob).WithMany(x => x.CompanyJobSkills).HasForeignKey(x => x.Job);
            modelBuilder.Entity<CompanyJobSkillPoco>().Ignore(c => c.TimeStamp);

            modelBuilder.Entity<CompanyLocationPoco>().HasOne(x => x.CompanyProfile).WithMany(x => x.CompanyLocations).HasForeignKey(x => x.Company);
            modelBuilder.Entity<CompanyLocationPoco>().HasOne(x => x.SystemCountryCode).WithMany(x => x.CompanyLocations).HasForeignKey(x => x.CountryCode);
            modelBuilder.Entity<CompanyLocationPoco>().Ignore(c => c.TimeStamp);

            modelBuilder.Entity<CompanyProfilePoco>().Ignore(c => c.TimeStamp);

            modelBuilder.Entity<SecurityLoginPoco>().Ignore(c => c.TimeStamp);


            modelBuilder.Entity<SecurityLoginsLogPoco>().HasOne(x => x.SecurityLogin).WithMany(x => x.SecurityLoginsLogs).HasForeignKey(x => x.Login);

            modelBuilder.Entity<SecurityLoginsRolePoco>().HasOne(x => x.SecurityLogin).WithMany(x => x.SecurityLoginsRoles).HasForeignKey(x => x.Login);
            modelBuilder.Entity<SecurityLoginsRolePoco>().HasOne(x => x.SecurityRole).WithMany(x => x.SecurityLoginsRoles).HasForeignKey(x => x.Role);
            modelBuilder.Entity<SecurityLoginsRolePoco>().Ignore(c => c.TimeStamp);



        }
    }
}

