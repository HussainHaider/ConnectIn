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

namespace ConnectIN
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string abc ="";
            if (!string.IsNullOrEmpty(Session["txt"] as string))
            {
                abc = Session["txt"].ToString();
            }
            //int user_id = Int32.Parse(a);

            if (!IsPostBack)
            {

            }

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {
                com.Open();






                SqlCommand cmd6 = new SqlCommand("countSearch", com);
                cmd6.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd6.Parameters.AddWithValue("@Fname", abc);
                cmd6.Parameters.AddWithValue("@Lname", abc);

                SqlParameter outPutParameter3 = new SqlParameter();
                outPutParameter3.ParameterName = "@countfor";//outuput parameter of the count_no_of_Projects...
                outPutParameter3.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter3.Direction = System.Data.ParameterDirection.Output;
                cmd6.Parameters.Add(outPutParameter3);
                //Execution
                cmd6.ExecuteNonQuery();

                string n1 = outPutParameter3.Value.ToString();
                int count_Search = Convert.ToInt32(n1);







                string str = "Select * from Users where First_name like '" + abc + "' OR Last_name like '" + abc + "'";
                SqlCommand cmd = new SqlCommand(str, com);

                SqlDataReader reader = cmd.ExecuteReader();


                for (int i = 0; i < count_Search; i++)
                {
                    reader.Read();

                    string _id = reader["UserID"].ToString();



                    Image img1 = new Image();
                    img1.Height = 50;
                    img1.Width = 50;
                    img1.ID = "img" + _id;
                    img1.CssClass = "img-thumbnail";

                    if (reader["DP"] != DBNull.Value)
                    {
                        byte[] imagem = (byte[])(reader["DP"]);
                        string base64String = Convert.ToBase64String(imagem);
                        img1.ImageUrl = "data:Image/png;base64," + base64String;
                    }
                    panelSearch.Controls.Add(img1);


                    LinkButton hyp = new LinkButton();
                    hyp.Text = reader["First_name"].ToString() + " " + reader["Last_name"].ToString() + "<br/>";
                    //hyp.NavigateUrl = "SearchProfile.aspx";
                    hyp.ID = "User_id" + _id;
                    hyp.Click += new EventHandler(User_id_click);

                    panelSearch.Controls.Add(hyp);

                }
                reader.Close();
            }
        }
        protected void User_id_click(object sender, EventArgs e)
        {
            LinkButton clickedButton = sender as LinkButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("Search.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "User_id";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);
                string abc = Session["ID"].ToString();//jo watch kr raha ha...
                Session["CID"] = lastDigits;



                String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection com1 = new SqlConnection(cs))
                {
                    com1.Open();
                    SqlCommand cmd = new SqlCommand("Search_User", com1);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd.Parameters.AddWithValue("@Userto", lastDigits);
                    cmd.Parameters.AddWithValue("@Userby", abc);
                    //Execution
                    cmd.ExecuteNonQuery();


                }
                Response.Redirect("SearchProfile.aspx?do" + lastDigits);
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