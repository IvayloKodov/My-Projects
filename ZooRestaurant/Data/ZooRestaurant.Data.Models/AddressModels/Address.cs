namespace ZooRestaurant.Data.Models.AddressModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        private ICollection<Customer> customers;

        public Address()
        {
            this.customers = new HashSet<Customer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string AdditionalAddress { get; set; }

        public int NeighborhoodId { get; set; }

        public virtual Neighborhood Neighborhood { get; set; }

        public virtual ICollection<Customer> Customers
        {
            get { return this.customers; }
            set { this.customers = value; }
        }
    }
}