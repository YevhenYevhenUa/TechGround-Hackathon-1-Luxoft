using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("survey_choice")]
    [Index("Id", Name = "ix_survey_choice_id")]
    public partial class SurveyChoice
    {
        public SurveyChoice()
        {
            SubskillRecommendations = new HashSet<SubskillRecommendation>();
            SurveyAnswers = new HashSet<SurveyAnswer>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("question_id")]
        public int? QuestionId { get; set; }
        [Column("text", TypeName = "character varying")]
        public string? Text { get; set; }
        [Column("order")]
        public int? Order { get; set; }

        [ForeignKey("QuestionId")]
        [InverseProperty("SurveyChoices")]
        public virtual SurveyQuestion? Question { get; set; }
        [InverseProperty("SurveyChoice")]
        public virtual ICollection<SubskillRecommendation> SubskillRecommendations { get; set; }
        [InverseProperty("Choice")]
        public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; }
    }
}
