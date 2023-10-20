using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_Task.Model
{
    [Table("survey")]
    [Index("Id", Name = "ix_survey_id")]
    public partial class Survey
    {
        public Survey()
        {
            SurveyQuestions = new HashSet<SurveyQuestion>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("version")]
        public int? Version { get; set; }

        [InverseProperty("Survey")]
        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; }
    }
}
