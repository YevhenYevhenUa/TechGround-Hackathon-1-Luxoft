using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("skill")]
    [Index("Id", Name = "ix_skill_id")]
    [Index("Code", Name = "skill_code_key", IsUnique = true)]
    [Index("Name", Name = "skill_name_key", IsUnique = true)]
    public partial class Skill
    {
        public Skill()
        {
            Subskills = new HashSet<Subskill>();
            VideoRecommendations = new HashSet<VideoRecommendation>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name", TypeName = "character varying")]
        public string? Name { get; set; }
        [Column("code")]
        public int? Code { get; set; }

        [InverseProperty("Skill")]
        public virtual ICollection<Subskill> Subskills { get; set; }
        [InverseProperty("Skill")]
        public virtual ICollection<VideoRecommendation> VideoRecommendations { get; set; }
    }
}
