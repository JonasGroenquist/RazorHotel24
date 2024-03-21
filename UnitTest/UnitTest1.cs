using Microsoft.Extensions.Logging;
using RazorHotel24.Interfaces;
using RazorHotel24.Models;
using RazorHotel24.Services;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private IHotelService _hotelService = new HotelService();

        //private void TestSetUp()
        //{
        //    Hotel h1 = new Hotel(1001, "TestNavn", "TestAdresse");
        //    Hotel h2 = new Hotel(1001, "TestNavn", "TestAdresse");
        //    _hotelService.CreateHotel(h1);
        //    _hotelService.CreateHotel(h2);
        //}
        [TestMethod]
        public void TestCreateHotel()
        {
            //arrange 
            //TestSetUp();

            //act
            int numberBefore = _hotelService.GetAllHotel().Count;
            Hotel h1 = new Hotel(1001, "TestNavn", "TestAdresse");
            _hotelService.CreateHotel(h1);
            int numberAfter = _hotelService.GetAllHotel().Count;
            _hotelService.DeleteHotel(h1.HotelNr);
            //assert
            Assert.AreEqual(numberBefore + 1, numberAfter);

        }
    }
}