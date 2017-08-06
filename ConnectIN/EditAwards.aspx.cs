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
    public partial class EditAwards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Session["AID"].ToString();
            int A_id = Int32.Parse(a);


            if (!IsPostBack)
            {


                String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection com = new SqlConnection(cs))
                {
                    com.Open();

                    string str4 = "Select * from ViewAwards where AwardsID=" + A_id;
                    SqlCommand cmd = new SqlCommand(str4, com);
                    //-------------------------------------------------------------------------------------------------------------------------------------

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    txttitle.Text = reader["Award_occupation"].ToString();
                    txtDate.Text = reader["Award_date"].ToString();
                    txtDescription.Text = reader["Award_Description"].ToString();

                    reader.Close();

                }
            }
        }
        protected void Awardbtn_edit_Click(object sender, EventArgs e)
        {

            string a = Session["AID"].ToString();
            int A_id = Int32.Parse(a);

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {

                SqlCommand cmd2 = new SqlCommand("editAward", com);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd2.Parameters.AddWithValue("@AID", A_id);
                cmd2.Parameters.AddWithValue("@Atitle",txttitle.Text);
                cmd2.Parameters.AddWithValue("@ADate", txtDate.Text);
                cmd2.Parameters.AddWithValue("@ADescription", txtDescription.Text);

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