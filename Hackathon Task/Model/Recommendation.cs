using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("recommendation")]
    [Index("Id", Name = "ix_recommendation_id")]
    public partial class Recommendation
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("subskill_id")]
        public int? SubskillId { get; set; }
        [Column("text", TypeName = "character varying")]
        public string? Text { get; set; }

        [ForeignKey("SubskillId")]
        [InverseProperty("Recommendations")]
        public virtual Subskill? Subskill { get; set; }
    }
}
