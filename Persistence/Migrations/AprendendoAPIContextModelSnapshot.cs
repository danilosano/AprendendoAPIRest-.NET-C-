﻿// <auto-generated />
using AprendendoAPI.API.Pesistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AprendendoAPI.API.Persistence.Migrations
{
    [DbContext(typeof(AprendendoAPIContext))]
    partial class AprendendoAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AprendendoAPI.Entities.JobApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicantEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApplicantName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdJobVacancy")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdJobVacancy");

                    b.ToTable("JobApplication");
                });

            modelBuilder.Entity("AprendendoAPI.Entities.JobVacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CreatedAt")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRemote")
                        .HasColumnType("boolean");

                    b.Property<string>("SalaryRange")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("JobVacancies");
                });

            modelBuilder.Entity("AprendendoAPI.Entities.JobApplication", b =>
                {
                    b.HasOne("AprendendoAPI.Entities.JobVacancy", null)
                        .WithMany("Applications")
                        .HasForeignKey("IdJobVacancy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AprendendoAPI.Entities.JobVacancy", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
