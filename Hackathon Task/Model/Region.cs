using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("region")]
    [Index("Id", Name = "ix_region_id")]
    [Index("Name", Name = "region_name_key", IsUnique = true)]
    public partial class Region
    {
        public Region()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name", TypeName = "character varying")]
        public string? Name { get; set; }

        [InverseProperty("Region")]
        public virtual ICollection<User> Users { get; set; }
    }
}
