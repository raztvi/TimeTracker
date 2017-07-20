using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TimeTracker.Models;

namespace TimeTracker.Migrations
{
    [DbContext(typeof(TimeTrackerContext))]
    [Migration("20170717170832_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeTracker.Models.CreateProjectModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("ProjectName");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("TaskName");

                    b.Property<string>("ClientName");

                    b.Property<string>("ClientAdress");

                    b.HasKey("ID");

                    b.ToTable("CreateProjectModel");
                });
        }
    }
}
