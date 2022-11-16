﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnet_check.Data;

#nullable disable

namespace dotnetcheck.Migrations
{
    [DbContext(typeof(dotnet_checkContext))]
    [Migration("20221116222326_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("CheckDotnetVersions.BackGroundServices.ReleasesIndex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("channelversion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "channel-version");

                    b.Property<string>("eoldate")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "eol-date");

                    b.Property<string>("latestrelease")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "latest-release");

                    b.Property<string>("latestreleasedate")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "latest-release-date");

                    b.Property<string>("latestruntime")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "latest-runtime");

                    b.Property<string>("latestsdk")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "latest-sdk");

                    b.Property<string>("product")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("releasesjson")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "releases.json");

                    b.Property<string>("releasetype")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "release-type");

                    b.Property<bool>("security")
                        .HasColumnType("INTEGER");

                    b.Property<string>("supportphase")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "support-phase");

                    b.HasKey("Id");

                    b.ToTable("ReleasesIndex");
                });
#pragma warning restore 612, 618
        }
    }
}
