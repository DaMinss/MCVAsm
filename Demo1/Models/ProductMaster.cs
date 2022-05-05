namespace Demo1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("ProductMaster")]
    public partial class ProductMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookId { get; set; }

        [StringLength(50)]
        public string BookName { get; set; }

        [StringLength(50)]
        public string BookCategory { get; set; }

        public double? BookPrice { get; set; }
    }
    
    public class ProductDbContext : DbContext
    {
        public ProductDbContext()
            : base("DefaultConnection")
        {
        }

        public static ProductDbContext Create()
        {
            return new ProductDbContext();
        }
        public DbSet<ProductMaster> ProductMasters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductMaster>()
                .Property(e => e.BookName)
                .IsFixedLength();

            modelBuilder.Entity<ProductMaster>()
                .Property(e => e.BookCategory)
                .IsFixedLength();
        }
    }
}
