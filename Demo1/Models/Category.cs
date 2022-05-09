namespace Demo1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        //relationship
        public List<ProductMaster> Product { get; set; }
    }
    public class CategoryDbcontext : DbContext
    {
        public CategoryDbcontext()
            : base("DefaultConnection")
        {
        }

        public static CategoryDbcontext Create()
        {
            return new CategoryDbcontext();
        }
        public DbSet<Category> Category { get; set; }
    }
}
