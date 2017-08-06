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
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //int user_id = 37;
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {
                com.Open();

                //Qyery for getting count of notifications
                SqlCommand cmd3 = new SqlCommand("notification_count", com);
                cmd3.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd3.Parameters.AddWithValue("@userid", user_id);

                SqlParameter outPutParameter1 = new SqlParameter();
                outPutParameter1.ParameterName = "@count";//outuput parameter of the count_no_of_jobs
                outPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter1.Direction = System.Data.ParameterDirection.Output;
                cmd3.Parameters.Add(outPutParameter1);
                //Execution
                cmd3.ExecuteNonQuery();
                string c = outPutParameter1.Value.ToString();
                int count_notifications = Convert.ToInt32(c);

                //printing notifications
                string str = "Select * from view_notification where UserTo=" + user_id;
              str = str + " Order by timest desc";
                SqlCommand cmd4 = new SqlCommand(str, com);
                SqlDataReader reader = cmd4.ExecuteReader();


                for (int i = 0; i < count_notifications; i++)
                {
                    reader.Read();
                    String user = reader["UserBy"].ToString();
                    int userid = Convert.ToInt32(user);
                    //Qyery for getting name of user using id

                    SqlCommand cmd2 = new SqlCommand("user_get_name", com);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd2.Parameters.AddWithValue("@userid", userid);

                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@name";//outuput parameter of the count_no_of_jobs
                    outPutParameter.SqlDbType = System.Data.SqlDbType.VarChar;
                    outPutParameter.Size = 50;
                    outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd2.Parameters.Add(outPutParameter);
                    //Execution
                    cmd2.ExecuteNonQuery();
                    string n = outPutParameter.Value.ToString();


                    Label lbl1 = new Label();
                    lbl1.Font.Size = 18;
                    lbl1.Font.Bold = true;
                    lbl1.Text = n;
                    notification_panel.Controls.Add(lbl1);


                    Label lbl2 = new Label();
                    lbl2.Font.Size = 18;
                    lbl2.Text = reader["Notifications_text"].ToString() + "<br/>";
                    notification_panel.Controls.Add(lbl2);
                }
                reader.Close();
                com.Close();
            }

        }

        protected void add_job_Click(object sender, EventArgs e)
        {
            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {
                com.Open();

                //-------------------------------------------------------------------------------------------------------------------------------------
                //Qyery for Adding a new job
                SqlCommand cmd2 = new SqlCommand("job_add", com);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd2.Parameters.AddWithValue("@job_name", name.Text);
                cmd2.Parameters.AddWithValue("@company_name", company.Text);
                cmd2.Parameters.AddWithValue("@company_description", description.Text);
                //Execution
                cmd2.ExecuteNonQuery();


                //-------------------------------------------------------------------------------------------------------------------------------------
                //Qyery for getting job id
                SqlCommand cmd3 = new SqlCommand("job_get_jobid", com);
                cmd3.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd3.Parameters.AddWithValue("@job_name", name.Text);
                cmd3.Parameters.AddWithValue("@company_name", company.Text);
                cmd3.Parameters.AddWithValue("@company_description", description.Text);

                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@job_id";//outuput parameter of the job id
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd3.Parameters.Add(outPutParameter);
                //Execution
                cmd3.ExecuteNonQuery();
                string n = outPutParameter.Value.ToString();
                int job_id = Convert.ToInt32(n);

                //-------------------------------------------------------------------------------------------------------------------------------------
                //Qyery for adding a skill in a job 
                SqlCommand cmd4 = new SqlCommand("skills_add_job_skills", com);
                cmd4.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd4.Parameters.AddWithValue("@job_id", job_id);
                cmd4.Parameters.AddWithValue("@skill_name", skill1.Text);

                //Execution
                cmd4.ExecuteNonQuery();

                //-------------------------------------------------------------------------------------------------------------------------------------
                //Qyery for adding a skill in a job 
                SqlCommand cmd5 = new SqlCommand("skills_add_job_skills", com);
                cmd5.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd5.Parameters.AddWithValue("@job_id", job_id);
                cmd5.Parameters.AddWithValue("@skill_name", skill2.Text);

                //Execution
                cmd5.ExecuteNonQuery();
                com.Close();
            }
        }
    }
}