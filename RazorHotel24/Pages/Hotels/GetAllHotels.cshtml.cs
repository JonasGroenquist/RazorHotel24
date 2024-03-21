using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotel24.Interfaces;
using RazorHotel24.Models;

namespace RazorHotel24.Pages.Hotels
{
    public class GetAllHotelsModel : PageModel
    {
        private IHotelService _hotelService;
        public List<Hotel> Hotels { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public GetAllHotelsModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public void OnGet()
        {
            try
            {
                if (!string.IsNullOrEmpty(FilterCriteria))
                {
                    Hotels = _hotelService.FilterHotels(FilterCriteria);
                }
                else
                {
                    Hotels = _hotelService.GetAllHotel();
                }
            }
            catch (Exception ex)
            {
                Hotels = new List<Models.Hotel>();
                ViewData["ErrorMessage"] = ex.Message;
            }
        }
    }
}
