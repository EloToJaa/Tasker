﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "api");

            migrationBuilder.CreateTable(
                name: "execution",
                schema: "api",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    training_id = table.Column<Guid>(type: "uuid", nullable: false),
                    pupil_id = table.Column<Guid>(type: "uuid", nullable: false),
                    trainer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date_to_complete = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    completion_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    number_of_exercises = table.Column<int>(type: "integer", nullable: false),
                    duration = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_execution", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exercises",
                schema: "api",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    photo_image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    photo_url = table.Column<string>(type: "text", nullable: false),
                    part_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exercises", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "parts",
                schema: "api",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_parts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pupils",
                schema: "api",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    trainer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pupils", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trainers",
                schema: "api",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trainings",
                schema: "api",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    number_of_exercises = table.Column<int>(type: "integer", nullable: false),
                    duration = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "execution_sets",
                schema: "api",
                columns: table => new
                {
                    execution_set_id = table.Column<Guid>(type: "uuid", nullable: false),
                    execution_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    repetitions = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<int>(type: "integer", nullable: false),
                    exercise_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_execution_sets", x => new { x.execution_set_id, x.execution_id });
                    table.ForeignKey(
                        name: "fk_execution_sets_execution_execution_id",
                        column: x => x.execution_id,
                        principalSchema: "api",
                        principalTable: "execution",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "part_exercise_ids",
                schema: "api",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    part_id = table.Column<Guid>(type: "uuid", nullable: false),
                    exercise_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_part_exercise_ids", x => x.id);
                    table.ForeignKey(
                        name: "fk_part_exercise_ids_parts_part_id",
                        column: x => x.part_id,
                        principalSchema: "api",
                        principalTable: "parts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainer_pupil_ids",
                schema: "api",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    trainer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    pupil_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainer_pupil_ids", x => x.id);
                    table.ForeignKey(
                        name: "fk_trainer_pupil_ids_trainers_trainer_id",
                        column: x => x.trainer_id,
                        principalSchema: "api",
                        principalTable: "trainers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "training_sets",
                schema: "api",
                columns: table => new
                {
                    training_set_id = table.Column<Guid>(type: "uuid", nullable: false),
                    training_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    repetitions = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<int>(type: "integer", nullable: false),
                    exercise_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_training_sets", x => new { x.training_set_id, x.training_id });
                    table.ForeignKey(
                        name: "fk_training_sets_trainings_training_id",
                        column: x => x.training_id,
                        principalSchema: "api",
                        principalTable: "trainings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_execution_sets_execution_id",
                schema: "api",
                table: "execution_sets",
                column: "execution_id");

            migrationBuilder.CreateIndex(
                name: "ix_part_exercise_ids_part_id",
                schema: "api",
                table: "part_exercise_ids",
                column: "part_id");

            migrationBuilder.CreateIndex(
                name: "ix_trainer_pupil_ids_trainer_id",
                schema: "api",
                table: "trainer_pupil_ids",
                column: "trainer_id");

            migrationBuilder.CreateIndex(
                name: "ix_training_sets_training_id",
                schema: "api",
                table: "training_sets",
                column: "training_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "execution_sets",
                schema: "api");

            migrationBuilder.DropTable(
                name: "exercises",
                schema: "api");

            migrationBuilder.DropTable(
                name: "part_exercise_ids",
                schema: "api");

            migrationBuilder.DropTable(
                name: "pupils",
                schema: "api");

            migrationBuilder.DropTable(
                name: "trainer_pupil_ids",
                schema: "api");

            migrationBuilder.DropTable(
                name: "training_sets",
                schema: "api");

            migrationBuilder.DropTable(
                name: "execution",
                schema: "api");

            migrationBuilder.DropTable(
                name: "parts",
                schema: "api");

            migrationBuilder.DropTable(
                name: "trainers",
                schema: "api");

            migrationBuilder.DropTable(
                name: "trainings",
                schema: "api");
        }
    }
}
