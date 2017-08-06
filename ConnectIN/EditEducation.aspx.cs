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
    public partial class EditEducation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Session["EduID"].ToString();
            int E_id = Int32.Parse(a);


            if (!IsPostBack)
            {


                String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection com = new SqlConnection(cs))
                {
                    com.Open();

                    string str = "Select * from ViewEducation where EducationID=" + E_id;
                    SqlCommand cmd = new SqlCommand(str, com);
                    //-------------------------------------------------------------------------------------------------------------------------------------

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    txtInstitution.Text = reader["Edu_Institute"].ToString();
                    txtname.Text = reader["title"].ToString();
                    Education_SDate.Text = reader["Edu_Starting_date"].ToString(); ;
                    Education_EDate.Text = reader["Edu_Ending_date"].ToString(); ;
                    txtDescription.Text = reader["Edu_Description"].ToString();
                    reader.Close();
                }
            }
        }

        protected void Educationbtn_edit_Click(object sender, EventArgs e)
        {
            string a = Session["EduID"].ToString();
            int E_id = Int32.Parse(a);

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {

                SqlCommand cmd2 = new SqlCommand("editEducation", com);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd2.Parameters.AddWithValue("@EID", E_id);
                cmd2.Parameters.AddWithValue("@EInstitue", txtInstitution.Text);
                cmd2.Parameters.AddWithValue("@Etitle", txtname.Text);
                cmd2.Parameters.AddWithValue("@E_SDate", Education_SDate.Text);
                cmd2.Parameters.AddWithValue("@E_EDate", Education_EDate.Text);
                cmd2.Parameters.AddWithValue("@EDescription", txtDescription.Text);

                //Execution
                com.Open();
                cmd2.ExecuteNonQuery();
                Response.Redirect("Profile.aspx");
            }


        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            Education_SDate.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
            Calendar1.Visible = false;
        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            Education_EDate.Text = Calendar2.SelectedDate.ToString("MM/dd/yyyy");
            Calendar2.Visible = false;
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