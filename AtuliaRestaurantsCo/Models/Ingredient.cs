namespace AtuliaRestaurantsCo.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public ICollection<ProductIngredient> ProductIngredients { get; set; }
    }
}
