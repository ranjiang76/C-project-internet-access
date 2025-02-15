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
    [Table("Security_Logins_Roles")]
    public class SecurityLoginsRolePoco:IPoco
    {
        public virtual SecurityLoginPoco SecurityLogin { get; set; }

        public virtual SecurityRolePoco SecurityRole { get; set; }



       [Key]
        public Guid Id { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        public Guid Login { get; set; }
        public Guid Role { get; set; }
    }
}
