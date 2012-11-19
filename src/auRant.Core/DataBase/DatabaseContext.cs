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
        public DbSet<Review> Reviews { get; set; }
        public DbSet<DraftReview> DraftReviews { get; set; }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<DraftProduct> DraftProducts { get; set; }

        public DbSet<Table> Tables { get; set; }
        public DbSet<DraftTable> DraftTables { get; set; }

        public DbSet<PublicationStatus> PulicationStatus { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<Suplier> Manufactors { get; set; }
        public DbSet<Parameter> Parmeters { get; set; }
        
        public DatabaseContext()
            : base("auRant")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Manufactor
            modelBuilder.Entity<Suplier>().Property(p => p.ID).HasColumnName("SUPL_ID_MANUFACTOR");

            //category
            modelBuilder.Entity<ProductCategory>().Property(p => p.ID).HasColumnName("PRCA_ID_CATEGORY");

            //status
            modelBuilder.Entity<PublicationStatus>().Property(p => p.ID).HasColumnName("PBST_ID_PUBLICATION_STATUS");

            //Product
            modelBuilder.Entity<Product>().Property(p => p.ID).HasColumnName("PROD_ID_PRODUCT");
            modelBuilder.Entity<Product>().HasRequired(p => p.Manufactor).WithMany().Map(m => m.MapKey("SUPL_ID_MANUFACTOR"));
            modelBuilder.Entity<Product>().HasRequired(p => p.PublicationStatus).WithMany().Map(m => m.MapKey("PBST_ID_PUBLICATION_STATUS"));
            modelBuilder.Entity<Product>().HasRequired(p => p.Category).WithMany().Map(m => m.MapKey("PRCA_ID_CATEGORY"));

            //Reviews
            modelBuilder.Entity<Review>().Property(p => p.ID).HasColumnName("REVI_ID_REVIEW");
            modelBuilder.Entity<Review>().HasRequired(p => p.Product).WithMany().Map(m => m.MapKey("PROD_ID_PRODUCT"));

            //Parameter
            modelBuilder.Entity<Parameter>().Property(p => p.ID).HasColumnName("PARA_ID_PARAMETER");

            //Table
            modelBuilder.Entity<Table>().Property(t => t.ID).HasColumnName("TABL_ID_TABLE");
            modelBuilder.Entity<Table>().HasRequired(t => t.PublicationStatus).WithMany().Map(m => m.MapKey("PBST_ID_PUBLICATION_STATUS"));

            modelBuilder.Entity<DraftTable>().Property(t => t.ID).HasColumnName("DRTA_ID_DRAFT_TABLE");
            /*modelBuilder.Entity<DraftTable>().HasRequired(t => t.PublicationStatus).WithMany().Map(m => m.MapKey("PBST_ID_PUBLICATION_STATUS"));
            modelBuilder.Entity<DraftTable>().HasOptional(t => t.OriginalTable).WithMany().Map(m => m.MapKey("ID_TABL"));*/

        }
    }
}
