﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hr_201_file.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<FileContents> FileContents { get; set; }
        public DbSet<FileCategory> FileCategories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FileExtension> FileExtensions { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Superuser> Superusers { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
