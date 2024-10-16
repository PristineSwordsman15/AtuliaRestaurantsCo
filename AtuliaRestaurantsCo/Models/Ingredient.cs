using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AtuliaRestaurantsCo.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        [ValidateNever]
        public ICollection<ProductIngredient> ProductIngredients { get; set; }
    }
}
