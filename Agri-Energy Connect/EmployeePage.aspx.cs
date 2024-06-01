using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agri_Energy_Connect
{
    public partial class EmployeePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }

        protected void AddFarmerButton_Click(object sender, EventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            InsertFarmer(firstName, lastName, email, password);

            ClearFarmerFields();

            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void FilterButton_Click(object sender, EventArgs e)
        {
            BindProducts();
        }

        private void InsertFarmer(string firstName, string lastName, string email, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AgriEnergyConnectDb"].ConnectionString;
            string query = "INSERT INTO farmer (FirstName, LastName, Email, Password, AuthType) VALUES (@FirstName, @LastName, @Email, @Password, 0)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void ClearFarmerFields()
        {
            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
        }

        private void BindProducts()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AgriEnergyConnectDb"].ConnectionString;
            string query = "SELECT ProductName, Category, ProductionDate FROM product";

            if (!string.IsNullOrEmpty(StartDateTextBox.Text) && !string.IsNullOrEmpty(EndDateTextBox.Text))
            {
                query += $" WHERE ProductionDate BETWEEN '{StartDateTextBox.Text}' AND '{EndDateTextBox.Text}'";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                ProductGridView.DataSource = dataTable;
                ProductGridView.DataBind();
            }
        }
    }
}