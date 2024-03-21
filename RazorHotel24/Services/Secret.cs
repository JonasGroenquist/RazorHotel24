using Microsoft.IdentityModel.Protocols;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace RazorHotel24.Services
{
    public static class Secret
    {
        //private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDbtest2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private static string _connectionString = @"Data Source=mssql11.unoeuro.com;Initial Catalog=jonasgr_dk_db_mydb;User ID=jonasgr_dk;Password=gaBpGDfyzcF4m9reRAnx;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public static string ConnectionString
        {
            get { return _connectionString; }
        }
    }
}
