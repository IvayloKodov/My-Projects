﻿namespace ZooRestaurant.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Web.Common.Constants;

    public class Image
    {
        private ICollection<Cart> carts;

        public Image()
        {
            this.carts = new HashSet<Cart>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxFileExtensionLength)]
        public string FileExtension { get; set; }

        public byte[] Content { get; set; }

        public string UrlPath { get; set; }

        public int? MealId { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual ICollection<Cart> Carts
        {
            get { return this.carts; }
            set { this.carts = value; }
        }
    }
}