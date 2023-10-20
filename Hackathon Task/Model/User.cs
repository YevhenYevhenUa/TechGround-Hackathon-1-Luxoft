using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("user")]
    [Index("BotId", Name = "ix_user_bot_id", IsUnique = true)]
    [Index("BotType", Name = "ix_user_bot_type")]
    [Index("Id", Name = "ix_user_id")]
    public partial class User
    {
        public User()
        {
            Children = new HashSet<Child>();
            PushMessageResponses = new HashSet<PushMessageResponse>();
            SentPushMessages = new HashSet<SentPushMessage>();
            UserBroadcastMessages = new HashSet<UserBroadcastMessage>();
            UserVideoRecommendations = new HashSet<UserVideoRecommendation>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("bot_id", TypeName = "character varying")]
        public string? BotId { get; set; }
        [Column("bot_type", TypeName = "character varying")]
        public string? BotType { get; set; }
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }
        [Column("region_id")]
        public int? RegionId { get; set; }
        [Column("is_subscribed")]
        public bool? IsSubscribed { get; set; }
        [Column("conversation_state", TypeName = "character varying")]
        public string? ConversationState { get; set; }
        [Column("utm_source", TypeName = "character varying")]
        public string? UtmSource { get; set; }
        [Column("recommendation_time", TypeName = "time with time zone")]
        public DateTimeOffset? RecommendationTime { get; set; }

        [ForeignKey("RegionId")]
        [InverseProperty("Users")]
        public virtual Region? Region { get; set; }
        [InverseProperty("CreatedBy")]
        public virtual ICollection<Child> Children { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<PushMessageResponse> PushMessageResponses { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<SentPushMessage> SentPushMessages { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserBroadcastMessage> UserBroadcastMessages { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserVideoRecommendation> UserVideoRecommendations { get; set; }
    }
}
