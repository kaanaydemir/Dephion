using System;
namespace WebUI.Settings
{
    public interface IApiSettings
    {
        string BaseAddress { get; set; }
        string ItemPath { get; set; }
        string RoomPath { get; set; }
        string ReservationPath { get; set; }
    }
}
