using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco:IPoco
    {

        public  ApplicantProfilePoco ApplicantProfile { get; set; }

        public virtual CompanyJobPoco CompanyJob { get; set; }

        [Key]
        public Guid Id { get; set; }

 
        [Column("Application_Date")]
        public DateTime ApplicationDate{ get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp  { get; set; }

        public Guid Applicant { get; set; }
        public Guid Job { get; set; }
    }
}
