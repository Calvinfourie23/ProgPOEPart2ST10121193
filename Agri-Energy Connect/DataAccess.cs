using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Agri_Energy_Connect
{
    public class DataAccess
    {
        private string connectionString;
        private string farmerId;

        public DataAccess()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["AgriEnergyConnectDb"].ConnectionString;
        }

        public (string authType, int farmerID) ValidateUser(string email, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string authQuery = @"
            SELECT 'farmer' AS UserType, AuthType, FarmerID
            FROM farmer 
            WHERE Email = @Email AND Password = @Password 
            UNION 
            SELECT 'employee' AS UserType, AuthType, NULL AS FarmerID
            FROM employee 
            WHERE Email = @Email AND Password = @Password";

                SqlCommand authCmd = new SqlCommand(authQuery, conn);
                authCmd.Parameters.AddWithValue("@Email", email);
                authCmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                SqlDataReader reader = authCmd.ExecuteReader();

                string authType = null;
                int farmerID = -1;

                if (reader.Read())
                {
                    authType = reader["AuthType"].ToString();
                    if (reader["UserType"].ToString() == "farmer" && reader["FarmerID"] != DBNull.Value)
                    {
                        farmerID = Convert.ToInt32(reader["FarmerID"]);
                    }
                }

                reader.Close();
                conn.Close();

                return (authType, farmerID);
            }
        }

    }
}