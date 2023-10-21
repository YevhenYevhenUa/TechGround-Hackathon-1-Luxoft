using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hackathon_Task.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:answerchoice", "beginner,intermediate,advanced")
                .Annotation("Npgsql:Enum:choicelevel", "one,two,three,four")
                .Annotation("Npgsql:Enum:dialogmessagetype", "welcome,age_question,skill_question,survey_finished")
                .Annotation("Npgsql:Enum:preschoolstatus", "preschool,homeschool,no")
                .Annotation("Npgsql:Enum:pushmessage", "change_settings,visit_website,add_child,yes_no_question,open_ended_question")
                .Annotation("Npgsql:Enum:reaction", "like,dislike,postpone,read")
                .Annotation("Npgsql:Enum:recommendationday", "monday,tuesday,wednesday,thursday,friday,saturday,sunday")
                .Annotation("Npgsql:Enum:recommendationfrequency", "daily,weekly")
                .Annotation("Npgsql:Enum:recommendationtype", "tell,do,ask");

            migrationBuilder.CreateTable(
                name: "alembic_version",
                columns: table => new
                {
                    version_num = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("alembic_version_pkc", x => x.version_num);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "broadcast_message",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_broadcast_message", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "preschool_status_recommendation_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preschool_status_recommendation_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "push_message",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying", nullable: true),
                    interval = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_push_message", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recommendation_progress_message",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    percentage = table.Column<int>(type: "integer", nullable: true),
                    data = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recommendation_progress_message", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "region",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_region", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skill",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    code = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "survey",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    version = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "child_recommendation_progress_message",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    child_id = table.Column<int>(type: "integer", nullable: true),
                    message_id = table.Column<int>(type: "integer", nullable: true),
                    sent_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_child_recommendation_progress_message", x => x.id);
                    table.ForeignKey(
                        name: "child_recommendation_progress_message_message_id_fkey",
                        column: x => x.message_id,
                        principalTable: "recommendation_progress_message",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bot_id = table.Column<string>(type: "character varying", nullable: true),
                    bot_type = table.Column<string>(type: "character varying", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    region_id = table.Column<int>(type: "integer", nullable: true),
                    is_subscribed = table.Column<bool>(type: "boolean", nullable: true),
                    conversation_state = table.Column<string>(type: "character varying", nullable: true),
                    utm_source = table.Column<string>(type: "character varying", nullable: true),
                    recommendation_time = table.Column<DateTimeOffset>(type: "time with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "user_region_id_fkey",
                        column: x => x.region_id,
                        principalTable: "region",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "subskill",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    skill_id = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    code = table.Column<int>(type: "integer", nullable: true),
                    title = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subskill", x => x.id);
                    table.ForeignKey(
                        name: "subskill_skill_id_fkey",
                        column: x => x.skill_id,
                        principalTable: "skill",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "video_recommendation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    skill_id = table.Column<int>(type: "integer", nullable: true),
                    text = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_recommendation", x => x.id);
                    table.ForeignKey(
                        name: "video_recommendation_skill_id_fkey",
                        column: x => x.skill_id,
                        principalTable: "skill",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "survey_question",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying", nullable: true),
                    order = table.Column<int>(type: "integer", nullable: true),
                    survey_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey_question", x => x.id);
                    table.ForeignKey(
                        name: "survey_question_survey_id_fkey",
                        column: x => x.survey_id,
                        principalTable: "survey",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "child",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    age = table.Column<int>(type: "integer", nullable: true),
                    created_by_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_child", x => x.id);
                    table.ForeignKey(
                        name: "child_created_by_id_fkey",
                        column: x => x.created_by_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "push_message_response",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    message_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    data = table.Column<string>(type: "jsonb", nullable: false),
                    answered_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_push_message_response", x => x.id);
                    table.ForeignKey(
                        name: "push_message_response_message_id_fkey",
                        column: x => x.message_id,
                        principalTable: "push_message",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "push_message_response_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sent_push_message",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    message_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    sent_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sent_push_message", x => x.id);
                    table.ForeignKey(
                        name: "sent_push_message_message_id_fkey",
                        column: x => x.message_id,
                        principalTable: "push_message",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "sent_push_message_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_broadcast_message",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    message_id = table.Column<int>(type: "integer", nullable: true),
                    sent_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_broadcast_message", x => x.id);
                    table.ForeignKey(
                        name: "user_broadcast_message_message_id_fkey",
                        column: x => x.message_id,
                        principalTable: "broadcast_message",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "user_broadcast_message_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "child_recommendation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    child_id = table.Column<int>(type: "integer", nullable: true),
                    sent_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    subskill_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_child_recommendation", x => x.id);
                    table.ForeignKey(
                        name: "child_recommendation_subskill_id_fkey",
                        column: x => x.subskill_id,
                        principalTable: "subskill",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "recommendation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subskill_id = table.Column<int>(type: "integer", nullable: true),
                    text = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recommendation", x => x.id);
                    table.ForeignKey(
                        name: "recommendation_subskill_id_fkey",
                        column: x => x.subskill_id,
                        principalTable: "subskill",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "subskill_reaction",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    child_id = table.Column<int>(type: "integer", nullable: true),
                    subskill_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subskill_reaction", x => x.id);
                    table.ForeignKey(
                        name: "subskill_reaction_subskill_id_fkey",
                        column: x => x.subskill_id,
                        principalTable: "subskill",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_video_recommendation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    video_recommendation_id = table.Column<int>(type: "integer", nullable: true),
                    sent_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_video_recommendation", x => x.id);
                    table.ForeignKey(
                        name: "user_video_recommendation_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "user_video_recommendation_video_recommendation_id_fkey",
                        column: x => x.video_recommendation_id,
                        principalTable: "video_recommendation",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "survey_choice",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question_id = table.Column<int>(type: "integer", nullable: true),
                    text = table.Column<string>(type: "character varying", nullable: true),
                    order = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey_choice", x => x.id);
                    table.ForeignKey(
                        name: "survey_choice_question_id_fkey",
                        column: x => x.question_id,
                        principalTable: "survey_question",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "subskill_recommendation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    survey_choice_id = table.Column<int>(type: "integer", nullable: true),
                    subskill_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subskill_recommendation", x => x.id);
                    table.ForeignKey(
                        name: "subskill_recommendation_subskill_id_fkey",
                        column: x => x.subskill_id,
                        principalTable: "subskill",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "subskill_recommendation_survey_choice_id_fkey",
                        column: x => x.survey_choice_id,
                        principalTable: "survey_choice",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "survey_answer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    child_id = table.Column<int>(type: "integer", nullable: true),
                    question_id = table.Column<int>(type: "integer", nullable: true),
                    choice_id = table.Column<int>(type: "integer", nullable: true),
                    answered_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey_answer", x => x.id);
                    table.ForeignKey(
                        name: "survey_answer_choice_id_fkey",
                        column: x => x.choice_id,
                        principalTable: "survey_choice",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "survey_answer_question_id_fkey",
                        column: x => x.question_id,
                        principalTable: "survey_question",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_broadcast_message_id",
                table: "broadcast_message",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "child_name_created_by_id_key",
                table: "child",
                columns: new[] { "name", "created_by_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_child_created_by_id",
                table: "child",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_child_id",
                table: "child",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_child_name",
                table: "child",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_child_recommendation_id",
                table: "child_recommendation",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_child_recommendation_subskill_id",
                table: "child_recommendation",
                column: "subskill_id");

            migrationBuilder.CreateIndex(
                name: "ix_child_recommendation_progress_message_id",
                table: "child_recommendation_progress_message",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_child_recommendation_progress_message_message_id",
                table: "child_recommendation_progress_message",
                column: "message_id");

            migrationBuilder.CreateIndex(
                name: "ix_preschool_status_recommendation_type_id",
                table: "preschool_status_recommendation_type",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_push_message_id",
                table: "push_message",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_push_message_response_id",
                table: "push_message_response",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_push_message_response_user_id",
                table: "push_message_response",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "uq_push_message_response_message_id_user_id",
                table: "push_message_response",
                columns: new[] { "message_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_recommendation_id",
                table: "recommendation",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_recommendation_subskill_id",
                table: "recommendation",
                column: "subskill_id");

            migrationBuilder.CreateIndex(
                name: "ix_recommendation_progress_message_id",
                table: "recommendation_progress_message",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_region_id",
                table: "region",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "region_name_key",
                table: "region",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_sent_push_message_id",
                table: "sent_push_message",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_sent_push_message_message_id",
                table: "sent_push_message",
                column: "message_id");

            migrationBuilder.CreateIndex(
                name: "ix_sent_push_message_user_id",
                table: "sent_push_message",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_skill_id",
                table: "skill",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "skill_code_key",
                table: "skill",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "skill_name_key",
                table: "skill",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_subskill_id",
                table: "subskill",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "subskill_skill_id_code_key",
                table: "subskill",
                columns: new[] { "skill_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_subskill_reaction_id",
                table: "subskill_reaction",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_subskill_reaction_subskill_id",
                table: "subskill_reaction",
                column: "subskill_id");

            migrationBuilder.CreateIndex(
                name: "ix_subskill_recommendation_id",
                table: "subskill_recommendation",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_subskill_recommendation_subskill_id",
                table: "subskill_recommendation",
                column: "subskill_id");

            migrationBuilder.CreateIndex(
                name: "uq_subskill_recommendation_survey_choice_id_subskill_id",
                table: "subskill_recommendation",
                columns: new[] { "survey_choice_id", "subskill_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_survey_id",
                table: "survey",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_survey_answer_choice_id",
                table: "survey_answer",
                column: "choice_id");

            migrationBuilder.CreateIndex(
                name: "ix_survey_answer_id",
                table: "survey_answer",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_survey_answer_question_id",
                table: "survey_answer",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "survey_answer_child_id_question_id_key",
                table: "survey_answer",
                columns: new[] { "child_id", "question_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_survey_choice_id",
                table: "survey_choice",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_survey_choice_question_id",
                table: "survey_choice",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "ix_survey_question_id",
                table: "survey_question",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_survey_question_survey_id",
                table: "survey_question",
                column: "survey_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_bot_id",
                table: "user",
                column: "bot_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_bot_type",
                table: "user",
                column: "bot_type");

            migrationBuilder.CreateIndex(
                name: "ix_user_id",
                table: "user",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_user_region_id",
                table: "user",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_broadcast_message_id",
                table: "user_broadcast_message",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_user_broadcast_message_message_id",
                table: "user_broadcast_message",
                column: "message_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_broadcast_message_user_id",
                table: "user_broadcast_message",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_video_recommendation_id",
                table: "user_video_recommendation",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_user_video_recommendation_user_id",
                table: "user_video_recommendation",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_video_recommendation_video_recommendation_id",
                table: "user_video_recommendation",
                column: "video_recommendation_id");

            migrationBuilder.CreateIndex(
                name: "ix_video_recommendation_id",
                table: "video_recommendation",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_video_recommendation_skill_id",
                table: "video_recommendation",
                column: "skill_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alembic_version");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "child");

            migrationBuilder.DropTable(
                name: "child_recommendation");

            migrationBuilder.DropTable(
                name: "child_recommendation_progress_message");

            migrationBuilder.DropTable(
                name: "preschool_status_recommendation_type");

            migrationBuilder.DropTable(
                name: "push_message_response");

            migrationBuilder.DropTable(
                name: "recommendation");

            migrationBuilder.DropTable(
                name: "sent_push_message");

            migrationBuilder.DropTable(
                name: "subskill_reaction");

            migrationBuilder.DropTable(
                name: "subskill_recommendation");

            migrationBuilder.DropTable(
                name: "survey_answer");

            migrationBuilder.DropTable(
                name: "user_broadcast_message");

            migrationBuilder.DropTable(
                name: "user_video_recommendation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "recommendation_progress_message");

            migrationBuilder.DropTable(
                name: "push_message");

            migrationBuilder.DropTable(
                name: "subskill");

            migrationBuilder.DropTable(
                name: "survey_choice");

            migrationBuilder.DropTable(
                name: "broadcast_message");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "video_recommendation");

            migrationBuilder.DropTable(
                name: "survey_question");

            migrationBuilder.DropTable(
                name: "region");

            migrationBuilder.DropTable(
                name: "skill");

            migrationBuilder.DropTable(
                name: "survey");
        }
    }
}
