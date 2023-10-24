﻿using Microsoft.EntityFrameworkCore;
using Tkf_Complaint_System.Models;

namespace Tkf_Complaint_System.Data
{
    public class Tkf_Complaint_System_Context : DbContext
    {
        public Tkf_Complaint_System_Context(DbContextOptions<Tkf_Complaint_System_Context> options) : base(options)
        {

        }
        public DbSet<Province> provinces { get; set; }
        public DbSet<District> districts { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<UC> uCs { get; set; }
        public DbSet<Project> projects { get; set; }

        // Client Info
        public DbSet<ClientInformation> clientInformation { get; set; }
        public DbSet<Feedback> feedbacks { get; set; }
        public DbSet<Project_tbl> project_Tbls { get; set; }
        public DbSet<Status> statuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedData();

            modelBuilder.Entity<ClientInformation>()
                .HasMany(ci => ci.Feedbacks)
                .WithOne(f => f.ClientInformation)
                .HasForeignKey(f => f.ClientId);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Project)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(f => f.ProjectId);
        




    }


}
}




