namespace RestaurantList.Models
{
    public class RestaurantDish
    {
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
