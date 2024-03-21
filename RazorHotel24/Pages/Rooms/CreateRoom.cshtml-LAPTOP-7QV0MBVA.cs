using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotel24.Interfaces;
using RazorHotel24.Models;

namespace RazorHotel24.Pages.Rooms
{
    public class CreateRoomModel : PageModel
    {
        private IRoomService _roomService;
        [BindProperty]
        public Room Room { get; set; }
        public CreateRoomModel(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost(int hotelNr)
        {
            _roomService.CreateRoom(hotelNr, Room);
            return RedirectToPage("GetAllRooms");
        }
    }
}
