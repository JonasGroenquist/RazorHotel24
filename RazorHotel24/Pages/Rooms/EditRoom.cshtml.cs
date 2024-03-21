using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotel24.Interfaces;
using RazorHotel24.Models;

namespace RazorHotel24.Pages.Rooms
{
    public class EditRoomModel : PageModel
    {
        private IRoomService _roomService;
        private IHotelService _hotelService;
        [BindProperty]
        public Room Room { get; set; }
        public EditRoomModel(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public void OnGet(int roomNr, int hotelNr)
        {
            Room = _roomService.GetRoomFromId(roomNr, hotelNr);
        }
        public IActionResult OnPostUpdate()
        {
            _roomService.UpdateRoom(Room, Room.RoomNr, Room.HotelNr);
            return RedirectToPage("GetAllRooms", new { hotelNo = Room.HotelNr});
        }

    }
}
