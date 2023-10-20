using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("child_recommendation_progress_message")]
    [Index("Id", Name = "ix_child_recommendation_progress_message_id")]
    public partial class ChildRecommendationProgressMessage
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("child_id")]
        public int? ChildId { get; set; }
        [Column("message_id")]
        public int? MessageId { get; set; }
        [Column("sent_at", TypeName = "timestamp without time zone")]
        public DateTime? SentAt { get; set; }

        [ForeignKey("MessageId")]
        [InverseProperty("ChildRecommendationProgressMessages")]
        public virtual RecommendationProgressMessage? Message { get; set; }
    }
}
