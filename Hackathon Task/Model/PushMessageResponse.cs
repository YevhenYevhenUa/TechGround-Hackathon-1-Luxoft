using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("push_message_response")]
    [Index("Id", Name = "ix_push_message_response_id")]
    [Index("MessageId", "UserId", Name = "uq_push_message_response_message_id_user_id", IsUnique = true)]
    public partial class PushMessageResponse
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("message_id")]
        public int MessageId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("data", TypeName = "jsonb")]
        public string Data { get; set; } = null!;
        [Column("answered_at", TypeName = "timestamp without time zone")]
        public DateTime AnsweredAt { get; set; }

        [ForeignKey("MessageId")]
        [InverseProperty("PushMessageResponses")]
        public virtual PushMessage Message { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("PushMessageResponses")]
        public virtual User User { get; set; } = null!;
    }
}
