using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("subskill")]
    [Index("Id", Name = "ix_subskill_id")]
    [Index("SkillId", "Code", Name = "subskill_skill_id_code_key", IsUnique = true)]
    public partial class Subskill
    {
        public Subskill()
        {
            ChildRecommendations = new HashSet<ChildRecommendation>();
            Recommendations = new HashSet<Recommendation>();
            SubskillReactions = new HashSet<SubskillReaction>();
            SubskillRecommendations = new HashSet<SubskillRecommendation>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("skill_id")]
        public int? SkillId { get; set; }
        [Column("name", TypeName = "character varying")]
        public string? Name { get; set; }
        [Column("code")]
        public int? Code { get; set; }
        [Column("title", TypeName = "character varying")]
        public string? Title { get; set; }

        [ForeignKey("SkillId")]
        [InverseProperty("Subskills")]
        public virtual Skill? Skill { get; set; }
        [InverseProperty("Subskill")]
        public virtual ICollection<ChildRecommendation> ChildRecommendations { get; set; }
        [InverseProperty("Subskill")]
        public virtual ICollection<Recommendation> Recommendations { get; set; }
        [InverseProperty("Subskill")]
        public virtual ICollection<SubskillReaction> SubskillReactions { get; set; }
        [InverseProperty("Subskill")]
        public virtual ICollection<SubskillRecommendation> SubskillRecommendations { get; set; }
    }
}
