using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("broadcast_message")]
    [Index("Id", Name = "ix_broadcast_message_id")]
    public partial class BroadcastMessage
    {
        public BroadcastMessage()
        {
            UserBroadcastMessages = new HashSet<UserBroadcastMessage>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("text", TypeName = "character varying")]
        public string? Text { get; set; }
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        [InverseProperty("Message")]
        public virtual ICollection<UserBroadcastMessage> UserBroadcastMessages { get; set; }
    }
}
