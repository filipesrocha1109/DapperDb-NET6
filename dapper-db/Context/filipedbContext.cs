//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace dapper_db.Entities
//{
//    public partial class filipedbContext : DbContext
//    {
//        public virtual DbSet<Products> Products { get; set; }

//        public filipedbContext(DbContextOptions<filipedbContext> options) : base(options)
//        {
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Products>(entity =>
//            {
//                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
