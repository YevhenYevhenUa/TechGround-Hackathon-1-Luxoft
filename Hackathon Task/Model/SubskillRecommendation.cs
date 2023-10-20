using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("subskill_recommendation")]
    [Index("Id", Name = "ix_subskill_recommendation_id")]
    [Index("SurveyChoiceId", "SubskillId", Name = "uq_subskill_recommendation_survey_choice_id_subskill_id", IsUnique = true)]
    public partial class SubskillRecommendation
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("survey_choice_id")]
        public int? SurveyChoiceId { get; set; }
        [Column("subskill_id")]
        public int? SubskillId { get; set; }

        [ForeignKey("SubskillId")]
        [InverseProperty("SubskillRecommendations")]
        public virtual Subskill? Subskill { get; set; }
        [ForeignKey("SurveyChoiceId")]
        [InverseProperty("SubskillRecommendations")]
        public virtual SurveyChoice? SurveyChoice { get; set; }
    }
}
