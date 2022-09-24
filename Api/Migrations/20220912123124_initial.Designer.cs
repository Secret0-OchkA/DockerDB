﻿// <auto-generated />
using System;
using DockerTestBD.Api.Models.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DockerTestBD.Api.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20220912123124_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DockerTestBD.Api.Models.EF.Tables.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("DockerTestBD.Api.Models.EF.Tables.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("WorkId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("DockerTestBD.Api.Models.EF.Tables.Person", b =>
                {
                    b.HasOne("DockerTestBD.Api.Models.EF.Tables.Company", "Work")
                        .WithMany("Workers")
                        .HasForeignKey("WorkId");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("DockerTestBD.Api.Models.EF.Tables.Company", b =>
                {
                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}
