﻿namespace ZooRestaurant.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Web.Common.Constants;

    public class Cart
    {
        private ICollection<ShoppingCart> shoppingCarts;

        public Cart()
        {
            this.shoppingCarts = new HashSet<ShoppingCart>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(ValidationConstants.MaxMealNameLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts
        {
            get { return this.shoppingCarts; }
            set { this.shoppingCarts = value; }
        }
    }
}