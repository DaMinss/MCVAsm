namespace Demo1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("ProductMaster")]
    public partial class ProductMaster
    {        
        public ProductMaster()
        {
            Image = "~/Content/Image/add.png";
        }
        [Key]
       
        public int BookId { get; set; }

        [StringLength(50)]
        public string BookName { get; set; }

        [StringLength(50)]
        public string Publisher { get; set; }
        public string Description { get; set; }

       
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category category { get; set; }
       
        public double? BookPrice { get; set; }
        public double? BookQuantity { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
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

        //not sure what this does. Uncomment if you wanna mess with it.
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductMaster>()
                .Property(e => e.BookName)
                .IsFixedLength();

            modelBuilder.Entity<ProductMaster>()
                .Property(e => e.BookCategory)
                .IsFixedLength();
        }*/
    }
}
