using Microsoft.Data.SqlClient;
using RazorHotel24.Interfaces;
using RazorHotel24.Models;
using System.Data;

namespace RazorHotel24.Services
{
    public class HotelService : Connection, IHotelService
    {
        private string queryString = "SELECT Hotel_No, Name, Address FROM Hotel";
        private string insertSql = "INSERT INTO Hotel VALUES(@ID, @Navn, @Adresse)";
        private string getSqlID = "SELECT Hotel_No, Name, Address FROM Hotel WHERE Hotel_No=@ID";
        private string getSqlByName = "SELECT Hotel_No, Name, Address FROM Hotel WHERE Hotel.Name LIKE '%' + @Name + '%'";
        private string deleteSql = "DELETE FROM Hotel WHERE Hotel_No=@ID";
        private string updateSql = "Update Hotel SET Name=@Navn, Address=@Adresse WHERE Hotel_No=@ID";
        public bool CreateHotel(Hotel hotel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(insertSql, connection);
                    command.Parameters.AddWithValue("@ID", hotel.HotelNr);
                    command.Parameters.AddWithValue("@Navn", hotel.Navn);
                    command.Parameters.AddWithValue("@Adresse", hotel.Adresse);
                    command.Connection.Open();
                    int noOfRows = command.ExecuteNonQuery();
                    return noOfRows == 1;

                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                    throw sqlExp;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl: " + ex.Message);
                    throw ex;
                }
                finally
                {

                }
            }
            return false;
        }

        public Hotel DeleteHotel(int hotelNr)
        {

            Hotel hotel = GetHotelFromId(hotelNr);


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    SqlCommand commandDel = new SqlCommand(deleteSql, connection);
                    commandDel.Parameters.AddWithValue("@ID", hotelNr);

                    commandDel.Connection.Open();
                    int result = commandDel.ExecuteNonQuery();

                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl: " + ex.Message);
                }
                finally
                {

                }
            }
            return hotel;

        }

        public List<Hotel> GetAllHotel()
        {
            List<Hotel> hoteller = new List<Hotel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int hotelNr = reader.GetInt32("Hotel_No");
                        string hotelNavn = reader.GetString("Name");
                        string hotelAdr = reader.GetString("Address");
                        Hotel hotel = new Hotel(hotelNr, hotelNavn, hotelAdr);
                        hoteller.Add(hotel);
                    }
                    reader.Close();
                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl: " + ex.Message);
                }
                finally
                {

                }
            }
            return hoteller;
        }

        public Hotel GetHotelFromId(int hotelNr)
        {
            Hotel hotel = new Hotel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(getSqlID, connection);
                    command.Parameters.AddWithValue("@ID", hotelNr);

                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int hotelId = reader.GetInt32("Hotel_No");
                        string hotelNavn = reader.GetString("Name");
                        string hotelAdr = reader.GetString("Address");
                        hotel = new Hotel(hotelId, hotelNavn, hotelAdr);

                    }
                    reader.Close();
                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl: " + ex.Message);
                }
                finally
                {

                }
            }
            return hotel;
        }



        public List<Hotel> GetHotelsByName(string name)
        {
            List<Hotel> hoteller = new List<Hotel>();
            Hotel hotel = new Hotel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(getSqlByName, connection);
                    command.Parameters.AddWithValue("@Name", name);

                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int hotelId = reader.GetInt32("Hotel_No");
                        string hotelNavn = reader.GetString("Name");
                        string hotelAdr = reader.GetString("Address");
                        hotel = new Hotel(hotelId, hotelNavn, hotelAdr);
                        hoteller.Add(hotel);

                    }
                    reader.Close();
                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl: " + ex.Message);
                }
                finally
                {

                }
            }
            return hoteller;
        }

        public bool UpdateHotel(Hotel hotel, int hotelNr)
        {



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    SqlCommand command = new SqlCommand(updateSql, connection);
                    command.Parameters.AddWithValue("@ID", hotel.HotelNr);
                    command.Parameters.AddWithValue("@Navn", hotel.Navn);
                    command.Parameters.AddWithValue("@Adresse", hotel.Adresse);

                    command.Connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result == 1;
                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl: " + ex.Message);
                }
                finally
                {

                }
                return false;
            }
        }
        public List<Hotel> FilterHotels(string filterCriteria)
        {
            List<Hotel> filteredList = new List<Hotel>();
            foreach (var hotel in GetAllHotel())
            {
                if (hotel.Adresse.Contains(filterCriteria) || hotel.Navn.Contains(filterCriteria) || hotel.HotelNr.ToString().Contains(filterCriteria))
                {
                    filteredList.Add(hotel);
                }

            }

            return filteredList;
        }
    }
}
