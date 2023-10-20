using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("push_message")]
    [Index("Id", Name = "ix_push_message_id")]
    public partial class PushMessage
    {
        public PushMessage()
        {
            PushMessageResponses = new HashSet<PushMessageResponse>();
            SentPushMessages = new HashSet<SentPushMessage>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("text", TypeName = "character varying")]
        public string? Text { get; set; }
        [Column("interval")]
        public TimeSpan? Interval { get; set; }

        [InverseProperty("Message")]
        public virtual ICollection<PushMessageResponse> PushMessageResponses { get; set; }
        [InverseProperty("Message")]
        public virtual ICollection<SentPushMessage> SentPushMessages { get; set; }
    }
}
