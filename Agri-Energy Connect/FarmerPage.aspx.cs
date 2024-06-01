using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agri_Energy_Connect
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["FarmerID"] != null)
                {
                    int farmerId;
                    if (int.TryParse(Request.QueryString["FarmerID"], out farmerId))
                    {
                        BindGridView(farmerId);
                        
                        Label1.Text = farmerId.ToString();
                    }
                }
            }
        }

        protected void BindGridView(int farmerId)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["AgriEnergyConnectDb"].ConnectionString;

            // Corrected the query syntax and used parameterization
            string query = "SELECT ProductID, ProductName, Category, ProductionDate FROM product WHERE FarmerID = @FarmerID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                // Add parameter to the SqlCommand
                cmd.Parameters.AddWithValue("@FarmerID", farmerId);

                DataTable dt = new DataTable();

                connection.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                connection.Close();

                if (dt.Rows.Count > 0)
                {
                    FarmerProductView.DataSource = dt;
                    FarmerProductView.DataBind();
                }
            }
        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            string productName = ProductNameTextBox.Text;
            string category = CategoryTextBox.Text;
            string productionDate = ProductionDateTextBox.Text;
            string farmId = Label1.Text;

            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(productionDate))
            {
                ErrorMessageLabel.Text = "All fields are required.";
                ErrorMessageLabel.Visible = true;
                return;
            }

            if (!DateTime.TryParse(productionDate, out _))
            {
                ErrorMessageLabel.Text = "Invalid production date format. Please use YYYY-MM-DD.";
                ErrorMessageLabel.Visible = true;
                return;
            }

            string connectionString = WebConfigurationManager.ConnectionStrings["AgriEnergyConnectDb"].ConnectionString;
            string query = "INSERT INTO product (FarmerID, ProductName, Category, ProductionDate) VALUES (@FarmerID, @ProductName, @Category, @ProductionDate)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@FarmerID", farmId.ToString());
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@ProductionDate", productionDate);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    ErrorMessageLabel.Text = "Product added successfully.";
                    ErrorMessageLabel.ForeColor = System.Drawing.Color.Green;
                    ErrorMessageLabel.Visible = true;
                }
                catch (Exception ex)
                {
                    ErrorMessageLabel.Text = "An error occurred while adding the product. " + ex.Message;
                    ErrorMessageLabel.Visible = true;
                }
            }

            
            ProductNameTextBox.Text = "";
            CategoryTextBox.Text = "";
            ProductionDateTextBox.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }

    }
}