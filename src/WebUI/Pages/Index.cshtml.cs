using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebUI.ApiCollection.Interfaces;
using WebUI.Models;

namespace WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IItemApi _itemApi;
        private readonly IRoomApi _roomApi;
        private readonly IReservationApi _reservationApi;

        public IndexModel(IItemApi itemApi, IRoomApi roomApi, IReservationApi reservationApi)
        {
            _itemApi = itemApi;
            _roomApi = roomApi;
            _reservationApi = reservationApi;
        }

        public IEnumerable<RoomModel> RoomList { get; set; } = new List<RoomModel>();
        public IEnumerable<ReservationModel> ReservationList { get; set; } = new List<ReservationModel>();
        public IEnumerable<ItemModel> ItemList { get; set; } = new List<ItemModel>();
        public List<SelectListItem> Rooms { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync()
        {

            ItemList = await _itemApi.GetItems();
            //ReservationList = await _reservationApi.GetReservations();
            //RoomList = await _roomApi.GetRooms();

            //Rooms = RoomList.Select(x => new SelectListItem()
            //{
            //     Text = x.Name,
            //     Value = x.Id
            //}).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ItemList = await _itemApi.GetItems();
            ReservationList = await _reservationApi.GetReservations();
            RoomList = await _roomApi.GetRooms();

            Rooms = RoomList.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id
            }).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostGetAvailableRoomsAsync(DateTime startDate,DateTime endDate)
        {
            //ItemList = await _itemApi.GetItems();
            ReservationList = await _reservationApi.GetReservations();
            ReservationList = ReservationList.Where(b => (b.StartDate > startDate && b.StartDate < endDate) || (b.EndDate > startDate) && b.EndDate < endDate).ToList();

            RoomList = await _roomApi.GetRooms();
            RoomList = RoomList.Where(x=> ReservationList.Where(y => y.RoomId == x.Id).ToList().Count == 0).ToList();

            Rooms = RoomList.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id
            }).ToList();

            TempData["startDate"] = startDate;
            TempData["endDate"] = endDate;

            return Page();
        }

        public async Task<IActionResult> OnPostCreateReservationAsync(string id)
        {
            DateTime sDate = Convert.ToDateTime(TempData["startDate"]);
            DateTime eDate = Convert.ToDateTime(TempData["endDate"]);

            await _reservationApi.CreateReservation(new ReservationModel()
            {
                 EndDate = eDate,
                 StartDate = sDate,
                 RoomId = id,
                 Name = "MyReservation"
            });

            return Page();
        }
    }
}
