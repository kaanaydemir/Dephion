using System;
using System.Collections.Generic;

namespace Reservation.Application.Responses
{
    public class ReservationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomId { get; set; }
        public List<ProductResponse> Products { get; set; } = new List<ProductResponse>();
    }

    public class ProductResponse
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public int Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
