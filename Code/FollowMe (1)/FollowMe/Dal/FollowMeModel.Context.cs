﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Efrat.Dal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FollowMeEntities : DbContext
    {
        public FollowMeEntities()
            : base("name=FollowMeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActiveAntenna> ActiveAntenna { get; set; }
        public virtual DbSet<ActiveOrder> ActiveOrder { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<ConnectionDetailsInStation> ConnectionDetailsInStation { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<ProcessDetails> ProcessDetails { get; set; }
        public virtual DbSet<Readers> Readers { get; set; }
        public virtual DbSet<Reading> Reading { get; set; }
        public virtual DbSet<Station> Station { get; set; }
    }
}
