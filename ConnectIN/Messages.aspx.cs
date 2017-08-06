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
using System.Globalization;
using System.Threading;
using System.Text;
using ConnectIN.DAL;

namespace ConnectIN
{
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {
                com.Open();

                //SqlCommand cmd9 = new SqlCommand("countConnection", com);
                //cmd9.CommandType = System.Data.CommandType.StoredProcedure;

                ////Add the input parameters to the command object
                //cmd9.Parameters.AddWithValue("@userid", user_id);

                //SqlParameter outPutParameter6 = new SqlParameter();
                //outPutParameter6.ParameterName = "@count";//outuput parameter of the count_no_of_s...
                //outPutParameter6.SqlDbType = System.Data.SqlDbType.Int;
                //outPutParameter6.Direction = System.Data.ParameterDirection.Output;
                //cmd9.Parameters.Add(outPutParameter6);
                ////Execution
                //cmd9.ExecuteNonQuery();

                //string n4 = outPutParameter6.Value.ToString();
                //int count_connection = Convert.ToInt32(n4);
                DAL_meaages objMyDal = new DAL_meaages();

                int count_connection = 0;

                count_connection = objMyDal.countconnection(user_id);



                string str8 = "Select * from viewConnection where User_=" + user_id;
                SqlCommand cmd22 = new SqlCommand(str8, com);
                SqlDataReader reader = cmd22.ExecuteReader();



                for (int i = 0; i < count_connection; i++)
                {
                    reader.Read();


                    string _id = reader["UserID"].ToString();

                    ImageButton img1 = new ImageButton();
                    img1.Height = 100;
                    img1.Width = 100;
                    img1.CssClass = "img-thumbnail";

                    img1.ID = "image" + _id;
                    img1.Click += new ImageClickEventHandler(img1_Click);



                    if (reader["DP"] != DBNull.Value)
                    {
                        byte[] imagem = (byte[])(reader["DP"]);
                        string base64String = Convert.ToBase64String(imagem);
                        img1.ImageUrl = "data:Image/png;base64," + base64String;
                    }
                    else
                    {
                        img1.ImageUrl = "assets/img/user.png";
                    }
                    panel.Controls.Add(img1);
                    Label lbl = new Label();
                    lbl.Text = reader["First_name"].ToString() + " " + reader["Last_name"].ToString() + "<br/>" + "<br/>";
                    panel.Controls.Add(lbl);
                }

            }
        }

        //
        protected void img1_Click(object sender, EventArgs e)
        {

            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);



            int userid = 0;
            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect(Request.RawUrl);
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "image";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);
                userid = Convert.ToInt32(lastDigits);
                Session["messageti_ID"] = userid;
            }

            //messages start here

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com1 = new SqlConnection(cs))
            {
                com1.Open();


                //SqlCommand cmd8 = new SqlCommand("countMessages", com1);
                //cmd8.CommandType = System.Data.CommandType.StoredProcedure;

                ////Add the input parameters to the command object
                //cmd8.Parameters.AddWithValue("@userid1", user_id);
                //cmd8.Parameters.AddWithValue("@userid2", userid);

                //SqlParameter outPutParameter7 = new SqlParameter();
                //outPutParameter7.ParameterName = "@count";//outuput parameter of the count_no_of_messages...
                //outPutParameter7.SqlDbType = System.Data.SqlDbType.Int;
                //outPutParameter7.Direction = System.Data.ParameterDirection.Output;
                //cmd8.Parameters.Add(outPutParameter7);
                ////Execution
                //cmd8.ExecuteNonQuery();

                //string n5 = outPutParameter7.Value.ToString();
                //int count_messages = Convert.ToInt32(n5);

                DAL_meaages objMyDal = new DAL_meaages();

                int count_messages=0;

                count_messages = objMyDal.countmessage(user_id, userid);





                string str9 = "select * from viewMessages where (userBy=" + user_id + "and Userto=" + userid + ") or (userby=" + userid + "and userto=" + user_id + ")order by Messgae_date desc";
                SqlCommand cmd23 = new SqlCommand(str9, com1);
                SqlDataReader reeder = cmd23.ExecuteReader();



                for (int j = 0; j < count_messages; j++)
                {
                    reeder.Read();


                    Label lbl = new Label();
                    lbl.Text = reeder["msg_text"].ToString() + "<br/>" + "<br>";
                    lbl.CssClass = "floatRight";
                    string abc=reeder["userBy"].ToString();
                    int _id = Int32.Parse(abc);
                    if (_id == user_id)
                    {
                        lbl.BackColor = System.Drawing.Color.BlueViolet;
                       lbl.Attributes.CssStyle.Add("float", "right");
                    }
                    else
                    {
                        lbl.BackColor = System.Drawing.Color.OrangeRed;
                       lbl.Attributes.CssStyle.Add("float", "left");
                    }
                    lbl.Font.Bold = true;
                    lbl.ForeColor = System.Drawing.Color.White;
                    txt.Controls.Add(lbl);

                    Label lbl1 = new Label();
                    lbl1.Text = "<br/>" + "<br>";
                    txt.Controls.Add(lbl1);

                }
            }

        }

        protected void search_Click1(object sender, ImageClickEventArgs e)
        {
            Session["txt"] = Search_txt.Text;
            Response.Redirect("Search.aspx");
        }

        protected void messagebtn_Click(object sender, EventArgs e)
        {
            string a = Session["messageti_ID"].ToString();
            int user_id = Int32.Parse(a);

            string b = Session["ID"].ToString();
            int _id = Int32.Parse(b);

            DAL_meaages objMyDal = new DAL_meaages();
            objMyDal.sendmessage(txtmessage.Text, _id,user_id);


            //String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            //using (SqlConnection com = new SqlConnection(cs))
            //{

            //    com.Open();
            //    SqlCommand cmd4 = new SqlCommand("enterMessage", com);
            //    cmd4.CommandType = System.Data.CommandType.StoredProcedure;

            //    //Add the input parameters to the command object
            //    cmd4.Parameters.AddWithValue("@text", txtmessage.Text);
            //    cmd4.Parameters.AddWithValue("@userby", _id);
            //    cmd4.Parameters.AddWithValue("@userto", user_id);
            //    //Execution
            //    cmd4.ExecuteNonQuery();
            //}
            Response.Redirect("Messages.aspx");
        }
    }

}