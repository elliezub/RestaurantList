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

            modelBuilder.Entity<Restaurant>().HasData(new Restaurant
            {
                Id = 1,
                Name = "Gourmet Pizzaria",
                Address = "1234 Culinary St, Flavor, CA 90210",
                ImageUrl = "https://www.whereyoueat.com/r_gallery_images/rgallery-21635/Best_Italian_Pizza2.jpg"
            }
            );

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Pizza", Price = 10 },
                new Dish { Id = 2, Name = "Pasta", Price = 9 }

            );

            modelBuilder.Entity<RestaurantDish>().HasData(
                new RestaurantDish { RestaurantId = 1, DishId = 1},
                new RestaurantDish { RestaurantId = 1, DishId = 2}                                                                              
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Restaurant> Restaurants { get; set;}
        public DbSet<Dish> Dishes { get; set;}
        public DbSet<RestaurantDish> RestaurantsDish { get; set;}

    }
}
