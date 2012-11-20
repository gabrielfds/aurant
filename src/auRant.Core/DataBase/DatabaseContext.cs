using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using auRant.Core.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

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
        public DbSet<Supplier> Supliers { get; set; }
        public DbSet<Parameter> Parmeters { get; set; }
        
        public DatabaseContext()
            : base("auRant")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Supplier
            modelBuilder.Entity<Supplier>().Property(p => p.ID).HasColumnName("SUPL_ID_SUPPLIER");

            //category
            modelBuilder.Entity<ProductCategory>().Property(p => p.ID).HasColumnName("PRCA_ID_CATEGORY");

            //status
            modelBuilder.Entity<PublicationStatus>().Property(p => p.ID).HasColumnName("PBST_ID_PUBLICATION_STATUS");

            //Product
            modelBuilder.Entity<Product>().Property(p => p.ID).HasColumnName("PROD_ID_PRODUCT");
            modelBuilder.Entity<Product>().HasRequired(p => p.Supplier).WithMany().Map(m => m.MapKey("SUPL_ID_supplier"));
            modelBuilder.Entity<Product>().HasOptional(p => p.PublicationStatus).WithMany().Map(m => m.MapKey("PBST_ID_PUBLICATION_STATUS"));
            modelBuilder.Entity<Product>().HasRequired(p => p.Category).WithMany().Map(m => m.MapKey("PRCA_ID_CATEGORY")); 
     
             //Product
            modelBuilder.Entity<DraftProduct>().Property(p => p.ID).HasColumnName("DPRO_ID_DRAFT_PRODUCT");
            modelBuilder.Entity<DraftProduct>().HasOptional(p => p.OriginalProduct).WithMany().Map(m=>m.MapKey("PROD_ID_PRODUCT"));
            modelBuilder.Entity<DraftProduct>().HasRequired(p => p.Supplier).WithMany().Map(m => m.MapKey("SUPL_ID_SUPLIER"));
            modelBuilder.Entity<DraftProduct>().HasOptional(p => p.PublicationStatus).WithMany().Map(m => m.MapKey("PBST_ID_PUBLICATION_STATUS"));
            modelBuilder.Entity<DraftProduct>().HasRequired(p => p.Category).WithMany().Map(m => m.MapKey("PRCA_ID_CATEGORY"));  
      

            //Reviews
            modelBuilder.Entity<Review>().Property(p => p.ID).HasColumnName("REVI_ID_REVIEW");
            modelBuilder.Entity<Review>().HasRequired(p => p.Product).WithMany().Map(m => m.MapKey("PROD_ID_PRODUCT"));
            modelBuilder.Entity<Review>().HasOptional(p => p.PublicationStatus).WithMany().Map(m => m.MapKey("PBST_ID_PUBLICATION_STATUS"));

            modelBuilder.Entity<DraftReview>().Property(p => p.ID).HasColumnName("DREV_ID_REVIEW");
            modelBuilder.Entity<DraftReview>().HasRequired(p => p.OriginReview).WithMany().Map(m => m.MapKey("REVI_ID_REVIEW"));
            modelBuilder.Entity<DraftReview>().HasOptional(p => p.Product).WithMany().Map(m => m.MapKey("PROD_ID_PRODUCT"));
            modelBuilder.Entity<DraftReview>().HasOptional(p => p.PublicationStatus).WithMany().Map(m => m.MapKey("PBST_ID_PUBLICATION_STATUS"));

            //Parameter
            modelBuilder.Entity<Parameter>().Property(p => p.ID).HasColumnName("PARA_ID_PARAMETER");

            //Table
            modelBuilder.Entity<Table>().Property(t => t.ID).HasColumnName("TABL_ID_TABLE");
            modelBuilder.Entity<Table>().HasOptional(t => t.PublicationStatus).WithMany().Map(m => m.MapKey("PBST_ID_PUBLICATION_STATUS"));

            modelBuilder.Entity<DraftTable>().Property(t => t.ID).HasColumnName("DRTA_ID_DRAFT_TABLE");
            modelBuilder.Entity<DraftTable>().HasOptional(t => t.OriginalTable).WithMany().Map(m => m.MapKey("TABL_ID_TABLE"));
            modelBuilder.Entity<DraftTable>().HasOptional(t => t.PublicationStatus).WithMany().Map(m => m.MapKey("PBST_ID_PUBLICATION_STATUS"));

            //SupllierAddress
            modelBuilder.Entity<SupllierAddress>().Property(s => s.ID).HasColumnName("SUAD_ID_SUPLIER_ADDRESS");
            modelBuilder.Entity<SupllierAddress>().HasOptional(s => s.Supplier).WithMany().Map(m => m.MapKey("SUPL_ID_SUPLIER"));

        }
    }
}
