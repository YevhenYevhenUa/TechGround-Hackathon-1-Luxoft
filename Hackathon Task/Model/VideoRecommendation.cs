using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("video_recommendation")]
    [Index("Id", Name = "ix_video_recommendation_id")]
    public partial class VideoRecommendation
    {
        public VideoRecommendation()
        {
            UserVideoRecommendations = new HashSet<UserVideoRecommendation>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("skill_id")]
        public int? SkillId { get; set; }
        [Column("text", TypeName = "character varying")]
        public string? Text { get; set; }

        [ForeignKey("SkillId")]
        [InverseProperty("VideoRecommendations")]
        public virtual Skill? Skill { get; set; }
        [InverseProperty("VideoRecommendation")]
        public virtual ICollection<UserVideoRecommendation> UserVideoRecommendations { get; set; }
    }
}
