using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotel24.Interfaces;
using RazorHotel24.Models;
using RazorHotel24.Services;

namespace RazorHotel24.Pages.Rooms
{
    public class GetAllRoomsModel : PageModel
    {
        private IRoomService _roomService;
        public List<Room> Rooms { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Hotel_nr { get; set; }
        public GetAllRoomsModel(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public void OnGet(int hotelNo)
        {
            Hotel_nr = hotelNo;
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Rooms = _roomService.FilterRooms(FilterCriteria);
            }
            else
            {
                Rooms = _roomService.GetAllRoom(Hotel_nr);
            }
        }
        //public void OnGetFilter(int hotelNo)
        //{
        //    Hotel_nr = hotelNo;
        //    OnGet();
        //}
    }
}