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
    public partial class job : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);
            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {
                com.Open();

                //-------------------------------------------------------------------------------------------------------------------------------------
                //Qyery for Count the number of jobs of the UserS
                SqlCommand cmd2 = new SqlCommand("jobs_count", com);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd2.Parameters.AddWithValue("@userid", user_id);

                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@count";//outuput parameter of the count_no_of_jobs
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd2.Parameters.Add(outPutParameter);
                //Execution
                cmd2.ExecuteNonQuery();
                string n = outPutParameter.Value.ToString();
                int count_jobs = Convert.ToInt32(n);
                //-------------------------------------------------------------------------------------------------------------------------------------

                string str5 = "Select * from user_jobs where UserID=" + user_id;
                SqlCommand cmd18 = new SqlCommand(str5, com);
                SqlDataReader reader5 = cmd18.ExecuteReader();


                for (int i = 0; i < count_jobs; i++)
                {

                    reader5.Read();
                    Label lbl13 = new Label();
                    lbl13.Font.Size = 18;
                    lbl13.Font.Bold = true;
                    lbl13.Text = reader5["Name"].ToString() + "<br/>";
                    paneljob.Controls.Add(lbl13);


                    Label lbl14 = new Label();
                    lbl14.Font.Size = 18;
                    lbl14.Font.Bold = true;
                    lbl14.Text = reader5["Organization"].ToString() + "<br/>";
                    paneljob.Controls.Add(lbl14);


                    Label lbl15 = new Label();
                    lbl15.Font.Size = 14;
                    lbl15.Text = reader5["description"].ToString() + "<br/>" + "<br/>";
                    paneljob.Controls.Add(lbl15);

                }
                reader5.Close();
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