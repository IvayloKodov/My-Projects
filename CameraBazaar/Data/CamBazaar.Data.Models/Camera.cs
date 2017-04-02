namespace CamBazaar.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CameraBazaar.Web.Common.Enums;
    using ValidationAttributes;

    public class Camera
    {
        private ICollection<LightMetering> lightMeterings;

        public Camera()
        {
            this.lightMeterings = new HashSet<LightMetering>();
        }

        private int quantity;

        [Key]
        public int Id { get; set; }

        public MakeType Make { get; set; }

        [StringLength(20)]
        [Model]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
                this.IsInStock = value > 0;
            }
        }

        [Range(1, 30)]
        public int MinShutterSpeed { get; set; }

        [Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        [Range(50, 100)]
        public int MinISO { get; set; }

        [Range(200, 409600)]
        public int MaxISO { get; set; }

        public bool IsFullFrame { get; set; }

        [StringLength(15)]
        public string VideoResolution { get; set; }

        [StringLength(6000)]
        public string Description { get; set; }

        [ImageUrl]
        public string ImageUrl { get; set; }

        public bool IsInStock { get; set; }

        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }

        public virtual ICollection<LightMetering> LightMeterings
        {
            get { return this.lightMeterings; }
            set { this.lightMeterings = value; }
        }
    }
}