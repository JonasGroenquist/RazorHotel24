using Microsoft.AspNetCore.DataProtection;

namespace RazorHotel24.Services
{
    public abstract class Connection
    {
        //protected String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDbtest2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected String connectionString = Secret.ConnectionString;
    }
}
