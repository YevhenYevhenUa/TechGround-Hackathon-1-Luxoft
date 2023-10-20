using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("child_recommendation")]
    [Index("Id", Name = "ix_child_recommendation_id")]
    public partial class ChildRecommendation
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("child_id")]
        public int? ChildId { get; set; }
        [Column("sent_at", TypeName = "timestamp without time zone")]
        public DateTime? SentAt { get; set; }
        [Column("subskill_id")]
        public int? SubskillId { get; set; }

        [ForeignKey("SubskillId")]
        [InverseProperty("ChildRecommendations")]
        public virtual Subskill? Subskill { get; set; }
    }
}
