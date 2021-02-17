using System;
namespace WebUI.Settings
{
    public class ApiSettings : IApiSettings
    {
        public string BaseAddress { get; set; }
        public string ItemPath { get; set; }
        public string RoomPath { get; set; }
        public string ReservationPath { get; set; }
    }
}
