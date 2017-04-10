namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Server.Common.Enums;

    public class Book
    {
        private ICollection<Category> categories;

        public Book()
        {
            this.categories = new HashSet<Category>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        [StringLength(400)]
        public string Description { get; set; }

        [Range(0, 200)]
        public decimal Price { get; set; }

        public int Copies { get; set; }

        public EditionType Edition { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Category> Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
            }
        }
    }
}
