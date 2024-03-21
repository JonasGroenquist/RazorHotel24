using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotel24.Interfaces;
using RazorHotel24.Models;

namespace RazorHotel24.Pages.Hotels
{
    public class DeleteHotelModel : PageModel
    {
        private IHotelService _hotelService;
        public Hotel Hotel { get; set; }
        public DeleteHotelModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public void OnGet(int hotelnr)
        {
            Hotel = _hotelService.GetHotelFromId(hotelnr);
        }
        public IActionResult OnPostDelete(int number)
        {
            _hotelService.DeleteHotel(number);
            return RedirectToPage("GetAllHotels");
        }
    }
}
