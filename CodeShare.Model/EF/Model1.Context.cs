﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeShare.Model.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataShareCodeEntities : DbContext
    {
        public DataShareCodeEntities()
            : base("name=DataShareCodeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Code> Codes { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Pakage> Pakages { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tool> Tools { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<TakePrice> TakePrices { get; set; }
    }
}
