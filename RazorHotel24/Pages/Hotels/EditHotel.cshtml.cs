using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotel24.Interfaces;
using RazorHotel24.Models;

namespace RazorHotel24.Pages.Hotels
{
    public class EditHotelModel : PageModel
    {
        private IHotelService _hotelService;
        [BindProperty]
        public Hotel Hotel { get; set; }
        public EditHotelModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public void OnGet(int hotelNr)
        {
            Hotel = _hotelService.GetHotelFromId(hotelNr);
        }
        public IActionResult OnPostUpdate(int hotelNr)
        {
            _hotelService.UpdateHotel(Hotel, hotelNr);
            return RedirectToPage("GetAllHotels");
        }
        
    }
}
