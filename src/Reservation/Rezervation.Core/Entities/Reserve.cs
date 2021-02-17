using System;
using System.Collections.Generic;
using Reservation.Core.Entities.Base;

namespace Reservation.Core.Entities
{
    public class Reserve : Entity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
