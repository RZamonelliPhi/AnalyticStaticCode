using AnalyticStaticCode.BL;
using AnalyticStaticCode.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AnalyticStaticCode.Context
{
    public class AnalyticStaticCodeContext : DbContext
    {
        public DbSet<AnalyticReport> AnalyticReport { get; set; }
        public DbSet<AnalyticReportAux> AnalyticReportAux { get; set; }
        public DbSet<AnalyticData> AnalyticData { get; set; }
        public DbSet<AnalyticProject> AnalyticProject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            INIFile inif = new INIFile(Path.Combine(Environment.CurrentDirectory, "config.ini"));
            optionsBuilder.UseSqlServer(inif.Read("DataBase", "ConnectionString"));
      
        }
    }
}
