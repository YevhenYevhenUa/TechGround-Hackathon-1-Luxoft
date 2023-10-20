using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("sent_push_message")]
    [Index("Id", Name = "ix_sent_push_message_id")]
    [Index("UserId", Name = "ix_sent_push_message_user_id")]
    public partial class SentPushMessage
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("message_id")]
        public int? MessageId { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }
        [Column("sent_at", TypeName = "timestamp without time zone")]
        public DateTime? SentAt { get; set; }

        [ForeignKey("MessageId")]
        [InverseProperty("SentPushMessages")]
        public virtual PushMessage? Message { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("SentPushMessages")]
        public virtual User? User { get; set; }
    }
}
