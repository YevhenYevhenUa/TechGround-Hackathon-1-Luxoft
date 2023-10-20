using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("child")]
    [Index("Name", "CreatedById", Name = "child_name_created_by_id_key", IsUnique = true)]
    [Index("Id", Name = "ix_child_id")]
    [Index("Name", Name = "ix_child_name")]
    public partial class Child
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name", TypeName = "character varying")]
        public string? Name { get; set; }
        [Column("age")]
        public int? Age { get; set; }
        [Column("created_by_id")]
        public int? CreatedById { get; set; }
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey("CreatedById")]
        [InverseProperty("Children")]
        public virtual User? CreatedBy { get; set; }
    }
}
