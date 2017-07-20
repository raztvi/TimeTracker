using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TimeTracker.Models;

namespace TimeTracker.Migrations
{
    [DbContext(typeof(TimeTrackerContext))]
    partial class TimeTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeTracker.Models.CreateProjectModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientAdress");

                    b.Property<string>("ClientName");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("ProjectName")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("TaskName");

                    b.HasKey("ID");

                    b.ToTable("CreateProjectModel");
                });
        }
    }
}
