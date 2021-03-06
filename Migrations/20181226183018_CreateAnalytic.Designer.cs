﻿// <auto-generated />
using System;
using AnalyticStaticCode.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnalyticStaticCode.Migrations
{
    [DbContext(typeof(AnalyticStaticCodeContext))]
    [Migration("20181226183018_CreateAnalytic")]
    partial class CreateAnalytic
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnalyticStaticCode.Model.AnalyticData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnalyticReportAuxId");

                    b.Property<int>("Quantity");

                    b.Property<string>("Section");

                    b.HasKey("Id");

                    b.HasIndex("AnalyticReportAuxId");

                    b.ToTable("AnalyticData");
                });

            modelBuilder.Entity("AnalyticStaticCode.Model.AnalyticProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AnalyticProject");
                });

            modelBuilder.Entity("AnalyticStaticCode.Model.AnalyticReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AnalyticReport");
                });

            modelBuilder.Entity("AnalyticStaticCode.Model.AnalyticReportAux", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnalyticProjectId");

                    b.Property<int>("AnalyticReportId");

                    b.Property<string>("BuildNumber");

                    b.Property<DateTime>("DateAnalyticReportAux");

                    b.Property<string>("XmlInfo")
                        .HasColumnType("xml");

                    b.HasKey("Id");

                    b.HasIndex("AnalyticProjectId");

                    b.HasIndex("AnalyticReportId");

                    b.ToTable("AnalyticReportAux");
                });

            modelBuilder.Entity("AnalyticStaticCode.Model.AnalyticData", b =>
                {
                    b.HasOne("AnalyticStaticCode.Model.AnalyticReportAux")
                        .WithMany("ListAnalyticData")
                        .HasForeignKey("AnalyticReportAuxId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AnalyticStaticCode.Model.AnalyticReportAux", b =>
                {
                    b.HasOne("AnalyticStaticCode.Model.AnalyticProject")
                        .WithMany("ListAnalyticReportAux")
                        .HasForeignKey("AnalyticProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AnalyticStaticCode.Model.AnalyticReport")
                        .WithMany("ListAnalyticReportAux")
                        .HasForeignKey("AnalyticReportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
