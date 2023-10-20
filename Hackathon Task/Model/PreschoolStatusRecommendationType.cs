using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("preschool_status_recommendation_type")]
    [Index("Id", Name = "ix_preschool_status_recommendation_type_id")]
    public partial class PreschoolStatusRecommendationType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
