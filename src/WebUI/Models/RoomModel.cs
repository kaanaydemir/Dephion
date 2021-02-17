using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public class RoomModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Location { get; set; }
        public List<RoomItemModel> Items { get; set; } = new List<RoomItemModel>();
    }
}
