﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mobil
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MobilEntities : DbContext
    {
        public MobilEntities()
            : base("name=MobilEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbl_DailySheet> tbl_DailySheet { get; set; }
        public DbSet<tbl_User> tbl_User { get; set; }
        public DbSet<tbl_UserType> tbl_UserType { get; set; }

        public System.Data.Entity.DbSet<Mobil.Models.DailySheet> DailySheets { get; set; }
    }
}