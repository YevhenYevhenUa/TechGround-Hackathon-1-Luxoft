using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Hackathon_Task.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Hackathon_Task.Data
{
    public partial class numobotdbContext : IdentityDbContext<IdentityUser>
    {
        public numobotdbContext()
        {
        }

        public numobotdbContext(DbContextOptions<numobotdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlembicVersion> AlembicVersions { get; set; } = null!;
        public virtual DbSet<BroadcastMessage> BroadcastMessages { get; set; } = null!;
        public virtual DbSet<Child> Children { get; set; } = null!;
        public virtual DbSet<ChildRecommendation> ChildRecommendations { get; set; } = null!;
        public virtual DbSet<ChildRecommendationProgressMessage> ChildRecommendationProgressMessages { get; set; } = null!;
        public virtual DbSet<PreschoolStatusRecommendationType> PreschoolStatusRecommendationTypes { get; set; } = null!;
        public virtual DbSet<PushMessage> PushMessages { get; set; } = null!;
        public virtual DbSet<PushMessageResponse> PushMessageResponses { get; set; } = null!;
        public virtual DbSet<Recommendation> Recommendations { get; set; } = null!;
        public virtual DbSet<RecommendationProgressMessage> RecommendationProgressMessages { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<SentPushMessage> SentPushMessages { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<Subskill> Subskills { get; set; } = null!;
        public virtual DbSet<SubskillReaction> SubskillReactions { get; set; } = null!;
        public virtual DbSet<SubskillRecommendation> SubskillRecommendations { get; set; } = null!;
        public virtual DbSet<Survey> Surveys { get; set; } = null!;
        public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; } = null!;
        public virtual DbSet<SurveyChoice> SurveyChoices { get; set; } = null!;
        public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserBroadcastMessage> UserBroadcastMessages { get; set; } = null!;
        public virtual DbSet<UserVideoRecommendation> UserVideoRecommendations { get; set; } = null!;
        public virtual DbSet<VideoRecommendation> VideoRecommendations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql(/*"Host=localhost;Port=5001;Database=numo-bot-db;Username=postgres;Password=1111"*/
                    "Host=localhost; Database=TestDB2; Username=postgres; Password=kasdjij24io");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresEnum("answerchoice", new[] { "beginner", "intermediate", "advanced" })
                .HasPostgresEnum("choicelevel", new[] { "one", "two", "three", "four" })
                .HasPostgresEnum("dialogmessagetype", new[] { "welcome", "age_question", "skill_question", "survey_finished" })
                .HasPostgresEnum("preschoolstatus", new[] { "preschool", "homeschool", "no" })
                .HasPostgresEnum("pushmessage", new[] { "change_settings", "visit_website", "add_child", "yes_no_question", "open_ended_question" })
                .HasPostgresEnum("reaction", new[] { "like", "dislike", "postpone", "read" })
                .HasPostgresEnum("recommendationday", new[] { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" })
                .HasPostgresEnum("recommendationfrequency", new[] { "daily", "weekly" })
                .HasPostgresEnum("recommendationtype", new[] { "tell", "do", "ask" });

            modelBuilder.Entity<AlembicVersion>(entity =>
            {
                entity.HasKey(e => e.VersionNum)
                    .HasName("alembic_version_pkc");
            });

            modelBuilder.Entity<Child>(entity =>
            {
                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("child_created_by_id_fkey");
            });

            modelBuilder.Entity<ChildRecommendation>(entity =>
            {
                entity.HasOne(d => d.Subskill)
                    .WithMany(p => p.ChildRecommendations)
                    .HasForeignKey(d => d.SubskillId)
                    .HasConstraintName("child_recommendation_subskill_id_fkey");
            });

            modelBuilder.Entity<ChildRecommendationProgressMessage>(entity =>
            {
                entity.HasOne(d => d.Message)
                    .WithMany(p => p.ChildRecommendationProgressMessages)
                    .HasForeignKey(d => d.MessageId)
                    .HasConstraintName("child_recommendation_progress_message_message_id_fkey");
            });

            modelBuilder.Entity<PushMessageResponse>(entity =>
            {
                entity.HasOne(d => d.Message)
                    .WithMany(p => p.PushMessageResponses)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("push_message_response_message_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PushMessageResponses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("push_message_response_user_id_fkey");
            });

            modelBuilder.Entity<Recommendation>(entity =>
            {
                entity.HasOne(d => d.Subskill)
                    .WithMany(p => p.Recommendations)
                    .HasForeignKey(d => d.SubskillId)
                    .HasConstraintName("recommendation_subskill_id_fkey");
            });

            modelBuilder.Entity<SentPushMessage>(entity =>
            {
                entity.HasOne(d => d.Message)
                    .WithMany(p => p.SentPushMessages)
                    .HasForeignKey(d => d.MessageId)
                    .HasConstraintName("sent_push_message_message_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SentPushMessages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("sent_push_message_user_id_fkey");
            });

            modelBuilder.Entity<Subskill>(entity =>
            {
                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Subskills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("subskill_skill_id_fkey");
            });

            modelBuilder.Entity<SubskillReaction>(entity =>
            {
                entity.HasOne(d => d.Subskill)
                    .WithMany(p => p.SubskillReactions)
                    .HasForeignKey(d => d.SubskillId)
                    .HasConstraintName("subskill_reaction_subskill_id_fkey");
            });

            modelBuilder.Entity<SubskillRecommendation>(entity =>
            {
                entity.HasOne(d => d.Subskill)
                    .WithMany(p => p.SubskillRecommendations)
                    .HasForeignKey(d => d.SubskillId)
                    .HasConstraintName("subskill_recommendation_subskill_id_fkey");

                entity.HasOne(d => d.SurveyChoice)
                    .WithMany(p => p.SubskillRecommendations)
                    .HasForeignKey(d => d.SurveyChoiceId)
                    .HasConstraintName("subskill_recommendation_survey_choice_id_fkey");
            });

            modelBuilder.Entity<SurveyAnswer>(entity =>
            {
                entity.HasOne(d => d.Choice)
                    .WithMany(p => p.SurveyAnswers)
                    .HasForeignKey(d => d.ChoiceId)
                    .HasConstraintName("survey_answer_choice_id_fkey");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.SurveyAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("survey_answer_question_id_fkey");
            });

            modelBuilder.Entity<SurveyChoice>(entity =>
            {
                entity.HasOne(d => d.Question)
                    .WithMany(p => p.SurveyChoices)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("survey_choice_question_id_fkey");
            });

            modelBuilder.Entity<SurveyQuestion>(entity =>
            {
                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyQuestions)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("survey_question_survey_id_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("user_region_id_fkey");
            });

            modelBuilder.Entity<UserBroadcastMessage>(entity =>
            {
                entity.HasOne(d => d.Message)
                    .WithMany(p => p.UserBroadcastMessages)
                    .HasForeignKey(d => d.MessageId)
                    .HasConstraintName("user_broadcast_message_message_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBroadcastMessages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_broadcast_message_user_id_fkey");
            });

            modelBuilder.Entity<UserVideoRecommendation>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserVideoRecommendations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_video_recommendation_user_id_fkey");

                entity.HasOne(d => d.VideoRecommendation)
                    .WithMany(p => p.UserVideoRecommendations)
                    .HasForeignKey(d => d.VideoRecommendationId)
                    .HasConstraintName("user_video_recommendation_video_recommendation_id_fkey");
            });

            modelBuilder.Entity<VideoRecommendation>(entity =>
            {
                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.VideoRecommendations)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("video_recommendation_skill_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
