using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("user_video_recommendation")]
    [Index("Id", Name = "ix_user_video_recommendation_id")]
    public partial class UserVideoRecommendation
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }
        [Column("video_recommendation_id")]
        public int? VideoRecommendationId { get; set; }
        [Column("sent_at", TypeName = "timestamp without time zone")]
        public DateTime? SentAt { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("UserVideoRecommendations")]
        public virtual User? User { get; set; }
        [ForeignKey("VideoRecommendationId")]
        [InverseProperty("UserVideoRecommendations")]
        public virtual VideoRecommendation? VideoRecommendation { get; set; }
    }
}
