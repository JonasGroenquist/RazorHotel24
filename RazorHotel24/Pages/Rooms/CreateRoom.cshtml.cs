using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotel24.Interfaces;
using RazorHotel24.Models;
using System.ComponentModel;

namespace RazorHotel24.Pages.Rooms
{
    public class CreateRoomModel : PageModel
    {
        private IRoomService _roomService;
        [BindProperty]
        public Room Room { get; set; }

        [BindProperty]
        public int HotelNr { get; set; }
        public CreateRoomModel(IRoomService roomService)
        {
            _roomService = roomService;
            Room = new Room();
        }
        public void OnGet(int hotelNr)
        {
           HotelNr = hotelNr;
        }
        public IActionResult OnPost()
        {
            Room.HotelNr = HotelNr;
            _roomService.CreateRoom(HotelNr, Room);
            return RedirectToPage("GetAllRooms", new { hotelNo = HotelNr });
        }
    }
}
