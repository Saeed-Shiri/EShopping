﻿// <auto-generated />
using System;
using HealthChecks.UI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthCheck.Migrations
{
    [DbContext(typeof(HealthChecksDb))]
    [Migration("20240915074635_InitialHealthCheckMigration")]
    partial class InitialHealthCheckMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthChecks.UI.Data.HealthCheckConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiscoveryService")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("HealthChecks.UI.Data.HealthCheckExecution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiscoveryService")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastExecuted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("OnStateFrom")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Executions");
                });

            modelBuilder.Entity("HealthChecks.UI.Data.HealthCheckExecutionEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int?>("HealthCheckExecutionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HealthCheckExecutionId");

                    b.ToTable("HealthCheckExecutionEntries");
                });

            modelBuilder.Entity("HealthChecks.UI.Data.HealthCheckExecutionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HealthCheckExecutionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("On")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HealthCheckExecutionId");

                    b.ToTable("HealthCheckExecutionHistories");
                });

            modelBuilder.Entity("HealthChecks.UI.Data.HealthCheckFailureNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HealthCheckName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsUpAndRunning")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastNotified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Failures");
                });

            modelBuilder.Entity("HealthChecks.UI.Data.HealthCheckExecutionEntry", b =>
                {
                    b.HasOne("HealthChecks.UI.Data.HealthCheckExecution", null)
                        .WithMany("Entries")
                        .HasForeignKey("HealthCheckExecutionId");
                });

            modelBuilder.Entity("HealthChecks.UI.Data.HealthCheckExecutionHistory", b =>
                {
                    b.HasOne("HealthChecks.UI.Data.HealthCheckExecution", null)
                        .WithMany("History")
                        .HasForeignKey("HealthCheckExecutionId");
                });

            modelBuilder.Entity("HealthChecks.UI.Data.HealthCheckExecution", b =>
                {
                    b.Navigation("Entries");

                    b.Navigation("History");
                });
#pragma warning restore 612, 618
        }
    }
}
