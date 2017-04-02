namespace CamBazaar.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CameraBazaar.Web.Common.Enums;

    public class LightMetering
    {
        private ICollection<Camera> cameras;

        public LightMetering()
        {
            this.cameras = new HashSet<Camera>();
        }

        [Key]
        public int Id { get; set; }

        public LightMeteringType LightMeteringType { get; set; }

       // public bool IsChecked { get; set; }

        public virtual ICollection<Camera> Cameras
        {
            get { return this.cameras; }
            set { this.cameras = value; }
        }
    }
}