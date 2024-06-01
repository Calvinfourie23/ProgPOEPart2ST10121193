using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Agri_Energy_Connect
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string email = emailTxt.Value.ToString();
            string pass = passTxt.Value.ToString();

            DataAccess ds = new DataAccess();

            (string authType, int farmerID) = ds.ValidateUser(email, pass);

            if (authType == "0")
            {
                Response.Redirect($"FarmerPage.aspx?FarmerID={farmerID}");
            }
            if (authType == "1")
            {
                Response.Redirect("EmployeePage.aspx");
            }
            else
            {
                errorLbl.Text = "Invalid email or password.";
                emailTxt.Value = null;
                passTxt.Value = null;
            }
        }
    }
}