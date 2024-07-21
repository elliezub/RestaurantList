namespace RestaurantList.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<RestaurantDish>? RestaurantDishes { get; set; }
    }
}
