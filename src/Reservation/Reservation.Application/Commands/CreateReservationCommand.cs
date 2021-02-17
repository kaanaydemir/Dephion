using System;
using System.Collections.Generic;
using MediatR;
using Reservation.Application.Responses;

namespace Reservation.Application.Commands
{
    public class CreateReservationCommand : IRequest<ReservationResponse>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }

    public class Product
    {
        public string ProductId { get; set; }
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public int Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
