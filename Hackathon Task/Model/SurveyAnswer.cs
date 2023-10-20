using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("survey_answer")]
    [Index("Id", Name = "ix_survey_answer_id")]
    [Index("ChildId", "QuestionId", Name = "survey_answer_child_id_question_id_key", IsUnique = true)]
    public partial class SurveyAnswer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("child_id")]
        public int? ChildId { get; set; }
        [Column("question_id")]
        public int? QuestionId { get; set; }
        [Column("choice_id")]
        public int? ChoiceId { get; set; }
        [Column("answered_at", TypeName = "timestamp without time zone")]
        public DateTime? AnsweredAt { get; set; }

        [ForeignKey("ChoiceId")]
        [InverseProperty("SurveyAnswers")]
        public virtual SurveyChoice? Choice { get; set; }
        [ForeignKey("QuestionId")]
        [InverseProperty("SurveyAnswers")]
        public virtual SurveyQuestion? Question { get; set; }
    }
}
