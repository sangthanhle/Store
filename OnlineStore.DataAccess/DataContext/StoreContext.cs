using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Data;

namespace OnlineStore.DataAccess.DataContext
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockEvent> StockEvents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
        .HasOne(o => o.Clerk)
        .WithMany(u => u.ClerkOrders)
        .HasForeignKey(o => o.ClerkId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
       .HasOne(p => p.CreatedBy)
       .WithMany(u => u.CreatedProducts)
       .HasForeignKey(p => p.CreatedById)
       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ cho bảng ProductImage
            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade); // Điều này có nghĩa là khi xóa một sản phẩm, hình ảnh liên quan sẽ bị xóa

            // Cấu hình mối quan hệ cho bảng Stock
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Product)
                .WithOne(p => p.Stock)
                .HasForeignKey<Stock>(s => s.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ cho bảng StockEvent
            modelBuilder.Entity<StockEvent>()
                .HasOne(se => se.Stock)
                .WithMany(s => s.StockEvents)
                .HasForeignKey(se => se.StockId)
                .OnDelete(DeleteBehavior.Cascade); // Tương tự như StockEvent, khi xóa một Stock, các sự kiện liên quan cũng bị xóa

            // Cấu hình mối quan hệ cho bảng Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Clerk)
                .WithMany(u => u.ClerkOrders)
                .HasForeignKey(o => o.ClerkId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(u => u.CustomerOrders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ cho bảng OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
