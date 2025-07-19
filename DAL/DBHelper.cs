using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace FlightBookingSystem.DAL
{
    public class DbHelper : IDisposable
    {
        protected string connectionString = "Server=Anas_Dell;Database=Re7la;Trusted_Connection=True;TrustServerCertificate=true;";
        protected SqlConnection connection;

        public DbHelper()
        {
            connection = new SqlConnection(connectionString);
        }

        protected void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        protected void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public void Dispose()
        {
            CloseConnection();
            connection?.Dispose();
        }
    }
}