using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("survey_question")]
    [Index("Id", Name = "ix_survey_question_id")]
    public partial class SurveyQuestion
    {
        public SurveyQuestion()
        {
            SurveyAnswers = new HashSet<SurveyAnswer>();
            SurveyChoices = new HashSet<SurveyChoice>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("text", TypeName = "character varying")]
        public string? Text { get; set; }
        [Column("order")]
        public int? Order { get; set; }
        [Column("survey_id")]
        public int? SurveyId { get; set; }

        [ForeignKey("SurveyId")]
        [InverseProperty("SurveyQuestions")]
        public virtual Survey? Survey { get; set; }
        [InverseProperty("Question")]
        public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; }
        [InverseProperty("Question")]
        public virtual ICollection<SurveyChoice> SurveyChoices { get; set; }
    }
}
