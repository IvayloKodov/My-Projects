namespace ZooRestaurant.Web.Common.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum MealCategoryEnType
    {
        [Display(Name = "Salads")]
        Salads = 0,

        [Display(Name = "Starters")]
        Starters = 1,

        [Display(Name = "Chicken Dishes")]
        ChickenDishes = 2,

        [Display(Name = "Fish Dishes")]
        FishDishes = 3,

        [Display(Name = "Pork Dishes")]
        PorkDishes = 4,

        [Display(Name = "Beaf Dishes")]
        BeafDishes = 5,

        [Display(Name = "Garnitures")]
        Garnitures = 6,

        [Display(Name = "Desserts")]
        Desserts = 7,

        [Display(Name = "Sauces")]
        Sauces = 8
    }
}