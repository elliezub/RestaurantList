namespace RestaurantList.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public List<RestaurantDish>? RestaurantDishes { get; set; }
    }
}
