using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("recommendation_progress_message")]
    [Index("Id", Name = "ix_recommendation_progress_message_id")]
    public partial class RecommendationProgressMessage
    {
        public RecommendationProgressMessage()
        {
            ChildRecommendationProgressMessages = new HashSet<ChildRecommendationProgressMessage>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("percentage")]
        public int? Percentage { get; set; }
        [Column("data", TypeName = "jsonb")]
        public string? Data { get; set; }

        [InverseProperty("Message")]
        public virtual ICollection<ChildRecommendationProgressMessage> ChildRecommendationProgressMessages { get; set; }
    }
}
