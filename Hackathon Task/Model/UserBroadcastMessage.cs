using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("user_broadcast_message")]
    [Index("Id", Name = "ix_user_broadcast_message_id")]
    public partial class UserBroadcastMessage
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }
        [Column("message_id")]
        public int? MessageId { get; set; }
        [Column("sent_at", TypeName = "timestamp without time zone")]
        public DateTime? SentAt { get; set; }

        [ForeignKey("MessageId")]
        [InverseProperty("UserBroadcastMessages")]
        public virtual BroadcastMessage? Message { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("UserBroadcastMessages")]
        public virtual User? User { get; set; }
    }
}
