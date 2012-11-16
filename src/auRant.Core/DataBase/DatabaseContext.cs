using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using auRant.Core.Entities;

namespace auRant.Core.DataBase
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<PublicationStatus> PulicationStatus { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<Manufactor> Manufactors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<DraftReview> DraftReviews { get; set; }
        public DbSet<DraftProduct> DraftProducts { get; set; }
        public DbSet<Parameter> Parmeters { get; set; }
        public DatabaseContext()
            : base("auRant")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Manufactor
            modelBuilder.Entity<Manufactor>().Property(p => p.ID).HasColumnName("MANU_SQ_MANUFACTOR");

            //category
            modelBuilder.Entity<ProductCategory>().Property(p => p.ID).HasColumnName("PRCA_SQ_CATEGORY");

            //status
            modelBuilder.Entity<PublicationStatus>().Property(p => p.ID).HasColumnName("PBST_SQ_PUBLICATION_STATUS");

            //Product
            modelBuilder.Entity<Product>().Property(p => p.ID).HasColumnName("PROD_SQ_PRODUCT");
            modelBuilder.Entity<Product>().HasRequired(p => p.Manufactor).WithMany().Map(m => m.MapKey("MANU_SQ_MANUFACTOR"));
            modelBuilder.Entity<Product>().HasRequired(p => p.PublicationStatus).WithMany().Map(m => m.MapKey("PBST_SQ_PUBLICATION_STATUS"));
            modelBuilder.Entity<Product>().HasRequired(p => p.Category).WithMany().Map(m => m.MapKey("PRCA_SQ_CATEGORY"));

            //Reviews
            modelBuilder.Entity<Review>().Property(p => p.ID).HasColumnName("REVI_SQ_REVIEW");
            modelBuilder.Entity<Review>().HasRequired(p => p.Product).WithMany().Map(m => m.MapKey("PROD_SQ_PRODUCT"));

            //Parameter
            modelBuilder.Entity<Parameter>().Property(p => p.ID).HasColumnName("PARA_SQ_PARAMETER");

        }
    }
}
