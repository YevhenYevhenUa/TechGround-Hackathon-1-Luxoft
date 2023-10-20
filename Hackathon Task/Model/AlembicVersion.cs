﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("alembic_version")]
    public partial class AlembicVersion
    {
        [Key]
        [Column("version_num")]
        [StringLength(32)]
        public string VersionNum { get; set; } = null!;
    }
}
