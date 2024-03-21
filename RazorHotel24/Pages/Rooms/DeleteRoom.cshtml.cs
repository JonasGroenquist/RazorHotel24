using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotel24.Interfaces;
using RazorHotel24.Models;

namespace RazorHotel24.Pages.Rooms
{
    public class DeleteRoomModel : PageModel
    {
        private IRoomService _roomService;
        public Room Room { get; set; }
        public DeleteRoomModel(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public void OnGet(int roomNr, int hotelNr)
        {
            Room = _roomService.GetRoomFromId(roomNr, hotelNr);
        }
        public IActionResult OnPostDelete(int roomNr, int hotelNr)
        {
            _roomService.DeleteRoom(roomNr, hotelNr);
            return RedirectToPage("GetAllRooms");
        }
    }
}
