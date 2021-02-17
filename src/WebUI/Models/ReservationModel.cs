using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomId { get; set; }
        public List<ReservationItemModel> Products { get; set; } = new List<ReservationItemModel>();
    }
}
