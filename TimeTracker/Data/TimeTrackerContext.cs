using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TimeTracker.Models
{
    public class TimeTrackerContext : DbContext
    {
        public TimeTrackerContext (DbContextOptions<TimeTrackerContext> options )
            : base(options)
        {
        }

        public DbSet<TimeTracker.Models.CreateProjectModel> CreateProjectModel { get; set; }
    }
}
