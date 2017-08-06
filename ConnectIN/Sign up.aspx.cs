using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Configuration;

namespace ConnectIN
{
    public partial class Sign_up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error_text.Visible = false;
            error_image.Visible = false;
        }

        protected void indb_Click(object sender, EventArgs e)
        {
            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection com5 = new SqlConnection(cs))
            {
                com5.Open();
                if (string.IsNullOrWhiteSpace(First_name.Text) || string.IsNullOrWhiteSpace(Last_name.Text) || string.IsNullOrWhiteSpace(email_text.Text) || string.IsNullOrWhiteSpace(password_text.Text))
                {
                    error_text.Visible = true;
                    error_image.Visible = true ;
                }
                else
                {
                    SqlCommand cmd19 = new SqlCommand("add_Users", com5);
                    cmd19.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd19.Parameters.AddWithValue("@Firstname", First_name.Text);
                    cmd19.Parameters.AddWithValue("@lastname", Last_name.Text);
                    cmd19.Parameters.AddWithValue("@email", email_text.Text);
                    cmd19.Parameters.AddWithValue("@password", password_text.Text);


                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@NewId";
                    outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd19.Parameters.Add(outPutParameter);


                    cmd19.ExecuteNonQuery();

                    string n = outPutParameter.Value.ToString();
                    Session["ID"] = n;
                    Response.Redirect("Home.aspx?do" + n);
                }

            }
        }
    }
}