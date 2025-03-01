﻿// <auto-generated />
using System;
using MacroMateApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MacroMateApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("MacroMateApp.Models.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Calories")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Carbs")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Fats")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MealType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Protein")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("FoodLog");
                });

            modelBuilder.Entity("MacroMateApp.Models.UserGoals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CaloriesGoal")
                        .HasColumnType("REAL");

                    b.Property<double>("CarbGoal")
                        .HasColumnType("REAL");

                    b.Property<double>("FatGoal")
                        .HasColumnType("REAL");

                    b.Property<double>("ProteinGoal")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("UserGoals");
                });
#pragma warning restore 612, 618
        }
    }
}
