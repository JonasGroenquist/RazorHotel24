using Microsoft.Data.SqlClient;
using RazorHotel24.Interfaces;
using RazorHotel24.Models;
using System.Data;

namespace RazorHotel24.Services
{
    public class RoomService : Connection, IRoomService
    {
        private string queryString = "SELECT * FROM Room WHERE Room.Hotel_No=@ID";
        private string insertSql = "INSERT INTO Room VALUES(@RoomNo, @HotelNo, @Type, @Price)";
        private string getSqlID = "SELECT * FROM Room WHERE Hotel_No=@HotelNo AND Room_No=@RoomNo";
        private string deleteSql = "DELETE FROM Room WHERE Hotel_No=@HotelNo AND Room_No=@RoomNo";
        private string updateSql = "Update Room SET Price=@Pris, Types=@Type WHERE Hotel_No=@HotelNo AND Room_No=@RoomNo";
        private int hotelNr;

        public bool CreateRoom(int hotelNr, Room room)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(insertSql, connection);
                    command.Parameters.AddWithValue("@RoomNo", room.RoomNr);
                    command.Parameters.AddWithValue("@HotelNo", hotelNr);
                    command.Parameters.AddWithValue("@Type", room.Types);
                    command.Parameters.AddWithValue("@Price", room.Pris);
                    command.Connection.Open();
                    int noOfRows = command.ExecuteNonQuery();
                    return noOfRows == 1;

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
            return false;
        }

        public Room DeleteRoom(int roomNr, int hotelNr)
        {
            Room room = GetRoomFromId(roomNr, hotelNr);


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    SqlCommand commandDel = new SqlCommand(deleteSql, connection);
                    commandDel.Parameters.AddWithValue("@HotelNo", hotelNr);
                    commandDel.Parameters.AddWithValue("@RoomNo", roomNr);

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
            return room;
        }

        public List<Room> GetAllRoom(int hotelNr)
        {
            List<Room> rooms = new List<Room>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@ID", hotelNr);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int roomNr = reader.GetInt32("Room_No");

                        char roomType = reader.GetString("Types")[0];
                        double roomPris = reader.GetDouble("Price");
                        Room room = new Room(roomNr, roomType, roomPris, hotelNr);
                        rooms.Add(room);
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
            return rooms;
        }

        public Room GetRoomFromId(int roomNr, int hotelNr)
        {
            Room room = new Room();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(getSqlID, connection);
                    command.Parameters.AddWithValue("@HotelNo", hotelNr);
                    command.Parameters.AddWithValue("@RoomNo", roomNr);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        roomNr = reader.GetInt32("Room_No");

                        char roomType = reader.GetString("Types")[0];
                        double roomPris = reader.GetDouble("Price");
                        room = new Room(roomNr, roomType, roomPris, hotelNr);

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
            return room;
        }

        public bool UpdateRoom(Room room, int roomNr, int hotelNr)
        {



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    SqlCommand command = new SqlCommand(updateSql, connection);
                    command.Parameters.AddWithValue("@HotelNo", hotelNr);
                    command.Parameters.AddWithValue("@RoomNo", roomNr);
                    command.Parameters.AddWithValue("@Pris", room.Pris);
                    command.Parameters.AddWithValue("@Type", room.Types);

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
        public List<Room> FilterRooms(string filterCriteria)
        {
            List<Room> filteredList = new List<Room>();
            foreach (var room in GetAllRoom(hotelNr))
            {
                if (room.Pris.ToString().Contains(filterCriteria) || room.Types.ToString().Contains(filterCriteria))
                {
                    filteredList.Add(room);
                }

            }

            return filteredList;
        }
    }
}
