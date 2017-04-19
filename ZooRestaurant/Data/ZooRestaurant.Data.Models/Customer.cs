namespace ZooRestaurant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CustomerAddressModels;

    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Comment { get; set; }

        public int DeliveryAddressId { get; set; }

        [ForeignKey("DeliveryAddressId")]
        public virtual Address DeliveryAddress { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}