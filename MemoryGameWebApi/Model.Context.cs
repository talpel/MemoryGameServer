﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MemoryGameWebApi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MemoryGameEntities1 : DbContext
    {
        public MemoryGameEntities1()
            : base("name=MemoryGameEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ContactMessage> ContactMessage { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<GameResult> GameResult { get; set; }
        public virtual DbSet<Images> Images { get; set; }
    }
}
