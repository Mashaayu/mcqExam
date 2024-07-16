using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Hospital.Models;

namespace Hospital.Data
{
    public partial class EmployeeDbcontext : DbContext
    {
        public EmployeeDbcontext()
        {
        }

        public EmployeeDbcontext(DbContextOptions<EmployeeDbcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<AssignmentExtraInformation> AssignmentExtraInformations { get; set; } = null!;
        public virtual DbSet<BasicDetail> BasicDetails { get; set; } = null!;
        public virtual DbSet<DirectiveReport> DirectiveReports { get; set; } = null!;
        public virtual DbSet<DrivingLicense> DrivingLicenses { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Link> Links { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=PC0632\MSSQL2019;Database=EmployeeDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

    }
}
