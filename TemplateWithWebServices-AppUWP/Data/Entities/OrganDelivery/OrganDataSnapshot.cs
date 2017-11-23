using System;
using UwpClientApp.Data.Entities.Base;

namespace UwpClientApp.Data.Entities.OrganDelivery
{
    public class OrganDataSnapshot : BaseEntity
    {
        public int Id { get; set; }

        public double Altitude { get; set; }
        public double Longitude { get; set; }

        public DateTime Time { get; set; }

        public float Temperature { get; set; }

        public int OrganDeliveryId { get; set; }
        public virtual OrganDeliveryInfo OrganDelivery { get; set; }
    }
}
