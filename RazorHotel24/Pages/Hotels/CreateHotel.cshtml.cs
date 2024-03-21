using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotel24.Interfaces;
using RazorHotel24.Models;

namespace RazorHotel24.Pages.Hotels
{
    public class CreateHotelModel : PageModel
    {
        private IHotelService _hotelService;
        [BindProperty]
        public Hotel Hotel { get; set; }
        public CreateHotelModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            _hotelService.CreateHotel(Hotel);
            return RedirectToPage("GetAllHotels");
        }
    }
}
