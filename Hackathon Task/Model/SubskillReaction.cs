using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("subskill_reaction")]
    [Index("Id", Name = "ix_subskill_reaction_id")]
    public partial class SubskillReaction
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("child_id")]
        public int? ChildId { get; set; }
        [Column("subskill_id")]
        public int? SubskillId { get; set; }
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey("SubskillId")]
        [InverseProperty("SubskillReactions")]
        public virtual Subskill? Subskill { get; set; }
    }
}
