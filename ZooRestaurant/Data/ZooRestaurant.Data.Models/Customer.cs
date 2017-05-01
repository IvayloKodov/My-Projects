namespace ZooRestaurant.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using AddressModels;

    public class Customer
    {
        private ICollection<Order> orders;

        public Customer()
        {
            this.orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        public string Comment { get; set; }

        public int DeliveryAddressId { get; set; }

        [ForeignKey("DeliveryAddressId")]
        public virtual Address DeliveryAddress { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual ICollection<Order> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
        }
    }
}