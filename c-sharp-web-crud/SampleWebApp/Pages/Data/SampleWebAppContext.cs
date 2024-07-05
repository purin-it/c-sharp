using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Models;

namespace SampleWebApp.Data
{
    public class SampleWebAppContext : DbContext
    {
        public SampleWebAppContext (DbContextOptions<SampleWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<SampleWebApp.Models.User_Data> User_Data { get; set; } = default!;
    }
}
