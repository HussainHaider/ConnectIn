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
using System.Web.UI.WebControls;

namespace ConnectIN
{
    public partial class notification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                str=str+" Order by timest desc";
                SqlCommand cmd4 = new SqlCommand(str, com);
                SqlDataReader reader = cmd4.ExecuteReader();

                for (int i = 0; i < count_notifications; i++)
                {
                    reader.Read();

                    string user = reader["UserBy"].ToString();
                    int _id = Convert.ToInt32(user);
                    

                    //Qyery for getting name of user using id
                    SqlCommand cmd2 = new SqlCommand("user_get_name", com);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd2.Parameters.AddWithValue("@userid", _id);

                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@name";//outuput parameter of the count_no_of_jobs
                    outPutParameter.SqlDbType = System.Data.SqlDbType.VarChar;
                    outPutParameter.Size = 50;
                    outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd2.Parameters.Add(outPutParameter);
                    //Execution
                    cmd2.ExecuteNonQuery();
                    string name = outPutParameter.Value.ToString();

                    Label lbl1 = new Label();
                    lbl1.Font.Size = 18;
                    lbl1.Font.Bold = true;
                    lbl1.Text = "<br/>"+name+" ";
                    notification_user.Controls.Add(lbl1);


                    Label lbl2 = new Label();
                    lbl2.Font.Size = 18;
                    lbl2.Text = reader["Notifications_text"].ToString();
                    notification_user.Controls.Add(lbl2);


                    string check = reader["Notifications_text"].ToString();
                    int len = check.Length;
                    string L = "wanted to connect with you";
                    int last = L.Length;

                    int num = len - last;
                    string lastDigits = "ababab";
                    if(num>=0)
                        lastDigits = check.Substring((check.Length - num), num);
                    if(lastDigits=="")
                    {
                        Button button_notify = new Button();
                        button_notify.ID = "Approve" + _id;
                        button_notify.Text = "Approve";
                        button_notify.Width = 65;
                        button_notify.Height = 30;
                        button_notify.BackColor = System.Drawing.Color.Aqua;
                        button_notify.Font.Bold = true;
                        button_notify.ForeColor = System.Drawing.Color.Black;
                        notification_user.Controls.Add(button_notify);
                        button_notify.Click += new EventHandler(button_notify_Click);
                    }


                }
            }
        }
        protected void button_notify_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("notification.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "Approve";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);
                int C_id = Int32.Parse(lastDigits);


                string a = Session["ID"].ToString();
                int user_id = Int32.Parse(a);

                   String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                    using (SqlConnection com1 = new SqlConnection(cs))
                    {
                        com1.Open();

                        //-------------------------------------------------------------------------------------------------------------------------------------
                        //Qyery for Count the number of jobs of the UserS
                        SqlCommand cmd2 = new SqlCommand("approverequest", com1);
                        cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                        //Add the input parameters to the command object
                        cmd2.Parameters.AddWithValue("@ID1", user_id);
                        cmd2.Parameters.AddWithValue("@ID2", C_id);
                        cmd2.ExecuteNonQuery();





                        SqlCommand cmd3 = new SqlCommand("approverequest", com1);
                        cmd3.CommandType = System.Data.CommandType.StoredProcedure;

                        //Add the input parameters to the command object
                        cmd3.Parameters.AddWithValue("@ID1", C_id);
                        cmd3.Parameters.AddWithValue("@ID2", user_id);
                        cmd3.ExecuteNonQuery();
                    }




                Response.Redirect("notification.aspx?do" + lastDigits);
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