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
    public partial class Sign_In : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error_text.Visible = false;
            error_image.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            int ID = 0;
            using (SqlConnection com = new SqlConnection(cs))
            {
                com.Open();
                if (string.IsNullOrWhiteSpace(email_text.Text) && string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    error_text.Visible = true;
                    error_image.Visible = false;
                }

                else
                {
                    //Qyery to Get the ID  of the UserS
                    SqlCommand cmd = new SqlCommand("GetID", com);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd.Parameters.AddWithValue("@email", email_text.Text);
                    cmd.Parameters.AddWithValue("@passsword", txtPassword.Text);

                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@ID";
                    outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outPutParameter);
                    //Execution
                    cmd.ExecuteNonQuery();
                    string n = outPutParameter.Value.ToString();
                    Session["ID"] = n;
                    if (n != String.Empty)
                    {
                        ID = Convert.ToInt32(n);
                    }
                }
               

            }
            if (ID != 0)
            {
                if (email_text.Text=="Admin@gmail.com")
                {
                    Response.Redirect("Admin.aspx" + "?do" + ID);
                }
                else
                    Response.Redirect("Home.aspx"+"?do"+ID);
            }
            else
            {
                error_text.Visible = true;
                error_image.Visible = true;
            }
        }
    }
}