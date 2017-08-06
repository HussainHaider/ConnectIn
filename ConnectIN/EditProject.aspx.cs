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
    public partial class EditProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Session["PID"].ToString();
            int P_id = Int32.Parse(a);


            if (!IsPostBack)
            {


                String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection com = new SqlConnection(cs))
                {
                    com.Open();

                    string str = "Select * from ViewProjects where ProjectID=" + P_id;
                    SqlCommand cmd = new SqlCommand(str, com);
                    //-------------------------------------------------------------------------------------------------------------------------------------

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    txtname.Text = reader["Proj_name"].ToString();

                    txtDescription.Text = reader["Proj_Description"].ToString();

                    reader.Close();

                }
            }

        }

        protected void projectbtn_edit_Click(object sender, EventArgs e)
        {

            string a = Session["PID"].ToString();
            int P_id = Int32.Parse(a);

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {

                SqlCommand cmd2 = new SqlCommand("editProject", com);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd2.Parameters.AddWithValue("@PID", P_id);
                cmd2.Parameters.AddWithValue("@Pname", txtname.Text);
                cmd2.Parameters.AddWithValue("@PDescription", txtDescription.Text);

                //Execution
                com.Open();
                cmd2.ExecuteNonQuery();
                Response.Redirect("Profile.aspx");
            }

        }
        protected void search_Click1(object sender, ImageClickEventArgs e)
        {
            string abc = Session["ID"].ToString();

            Session["CID"] = abc;

            Session["txt"] = Search_txt.Text;
            Response.Redirect("Search.aspx?ID" + abc);
        }
    }
}