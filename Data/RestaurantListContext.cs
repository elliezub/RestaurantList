using Microsoft.EntityFrameworkCore;
using RestaurantList.Models;

namespace RestaurantList.Data
{
    //Restaurantlistcontext class inherits from DbContext
    public class RestaurantListContext : DbContext
    {
        public RestaurantListContext(DbContextOptions<RestaurantListContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantDish>().HasKey(rd => new
            {
                rd.RestaurantId,
                rd.DishId
            });

            modelBuilder.Entity<RestaurantDish>()
                .HasOne(r => r.Restaurant)
                .WithMany(rd => rd.RestaurantDishes)
                .HasForeignKey(r => r.RestaurantId);

            modelBuilder.Entity<RestaurantDish>()
                .HasOne(d => d.Dish)
                .WithMany(rd => rd.RestaurantDishes)
                .HasForeignKey(d => d.DishId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
