﻿// <auto-generated />
using System;
using ExerciseTracker.kalsson.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExerciseTracker.kalsson.Migrations
{
    [DbContext(typeof(ExerciseDbContext))]
    partial class ExerciseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExerciseTracker.kalsson.Models.ExerciseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("DurationExercise")
                        .HasColumnType("time");

                    b.Property<DateTime>("EndExercise")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExerciseComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartExercise")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
