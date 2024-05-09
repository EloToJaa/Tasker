﻿// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Execution.Execution", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateToComplete")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfExercises")
                        .HasColumnType("integer");

                    b.Property<Guid>("TrainingId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Execution", (string)null);
                });

            modelBuilder.Entity("Domain.Exercise.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("PartId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Exercises", (string)null);
                });

            modelBuilder.Entity("Domain.Part.Part", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Parts", (string)null);
                });

            modelBuilder.Entity("Domain.Training.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("NumberOfExercises")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Trainings", (string)null);
                });

            modelBuilder.Entity("Domain.Execution.Execution", b =>
                {
                    b.OwnsMany("Domain.Execution.Entities.ExecutionSet", "Sets", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("ExecutionSetId");

                            b1.Property<Guid>("ExecutionId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<Guid>("ExerciseId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Repetitions")
                                .HasColumnType("integer");

                            b1.Property<int>("Time")
                                .HasColumnType("integer");

                            b1.HasKey("Id", "ExecutionId");

                            b1.HasIndex("ExecutionId");

                            b1.ToTable("ExecutionSets", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ExecutionId");
                        });

                    b.Navigation("Sets");
                });

            modelBuilder.Entity("Domain.Exercise.Exercise", b =>
                {
                    b.OwnsOne("Domain.Common.ValueObjects.Image", "Photo", b1 =>
                        {
                            b1.Property<Guid>("ExerciseId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("ImageId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ExerciseId");

                            b1.ToTable("Exercises");

                            b1.WithOwner()
                                .HasForeignKey("ExerciseId");
                        });

                    b.Navigation("Photo")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Part.Part", b =>
                {
                    b.OwnsMany("Domain.Exercise.ExerciseId", "ExerciseIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .HasColumnType("integer");

                            b1.Property<Guid>("PartId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid")
                                .HasColumnName("ExerciseId");

                            b1.HasKey("Id");

                            b1.HasIndex("PartId");

                            b1.ToTable("PartExerciseIds", (string)null);

                            b1.HasDiscriminator().HasValue("ExerciseId");

                            b1.WithOwner()
                                .HasForeignKey("PartId");
                        });

                    b.Navigation("ExerciseIds");
                });

            modelBuilder.Entity("Domain.Training.Training", b =>
                {
                    b.OwnsMany("Domain.Training.Entities.TrainingSet", "Sets", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("TrainingSetId");

                            b1.Property<Guid>("TrainingId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<Guid>("ExerciseId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Repetitions")
                                .HasColumnType("integer");

                            b1.Property<int>("Time")
                                .HasColumnType("integer");

                            b1.HasKey("Id", "TrainingId");

                            b1.HasIndex("TrainingId");

                            b1.ToTable("TrainingSets", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("TrainingId");
                        });

                    b.Navigation("Sets");
                });
#pragma warning restore 612, 618
        }
    }
}
