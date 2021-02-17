using System;
namespace WebUI.Models
{
    public class ReservationItemModel
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int ReserveId { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public int Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
