﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using motitask;

#nullable disable

namespace motitask.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.19");

            modelBuilder.Entity("motitask.Alternative", b =>
                {
                    b.Property<int>("A_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("A_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("A_id");

                    b.ToTable("Alternatives");
                });

            modelBuilder.Entity("motitask.Criterion", b =>
                {
                    b.Property<int>("C_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("C_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("C_range")
                        .HasColumnType("INTEGER");

                    b.Property<string>("C_type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("C_weight")
                        .HasColumnType("REAL");

                    b.Property<string>("optim_type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("C_id");

                    b.ToTable("Criteria");
                });

            modelBuilder.Entity("motitask.LPR", b =>
                {
                    b.Property<int>("L_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("L_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("L_range")
                        .HasColumnType("INTEGER");

                    b.HasKey("L_id");

                    b.ToTable("LPRs");
                });

            modelBuilder.Entity("motitask.Mark", b =>
                {
                    b.Property<int>("M_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("C_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("M_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("M_norm")
                        .HasColumnType("REAL");

                    b.Property<int>("M_num")
                        .HasColumnType("INTEGER");

                    b.Property<int>("M_range")
                        .HasColumnType("INTEGER");

                    b.HasKey("M_id");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("motitask.Result", b =>
                {
                    b.Property<int>("R_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("A_id")
                        .HasColumnType("INTEGER");

                    b.Property<double>("A_weight")
                        .HasColumnType("REAL");

                    b.Property<int>("L_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("L_range")
                        .HasColumnType("INTEGER");

                    b.HasKey("R_id");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("motitask.Vector", b =>
                {
                    b.Property<int>("V_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("A_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("M_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("V_id");

                    b.ToTable("Vectors");
                });
#pragma warning restore 612, 618
        }
    }
}
