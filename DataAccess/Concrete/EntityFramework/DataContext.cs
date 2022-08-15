using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=MyExampleDb2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(x => x.ProductCategory)
                .WithMany(y => y.Product)
                .HasForeignKey(z => z.ProductCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            });



        }

        public override int SaveChanges()
        {

            var data = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in data)
            {
                var result = item.State switch
                {
                    EntityState.Added =>  item.Entity.CreateDate = DateTime.UtcNow  ,
                    EntityState.Modified => item.Entity.UpdateDate = DateTime.UtcNow,

                };
            }
            return base.SaveChanges();
        }

    }
}
