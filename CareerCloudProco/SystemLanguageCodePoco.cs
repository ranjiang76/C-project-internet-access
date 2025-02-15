﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("System_Language_Codes")]
    public class SystemLanguageCodePoco: IPocoLanguageID
    {
        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }

        [Key]
        public string LanguageID { get; set; } = default!;

        [Column("Native_Name")]
        public string NativeName { get; set; } = default!;

        public string Name { get; set; } = default!;
    }
}
