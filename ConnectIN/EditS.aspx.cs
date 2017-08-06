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
using System.IO;

namespace ConnectIN
{
    public partial class EditS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int _id = Int32.Parse(a);


            if (!IsPostBack)
            {
                lblMessage.Visible = false;

                String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection com = new SqlConnection(cs))
                {
                    com.Open();

                    string str = "Select * from Users where UserID=" + _id;
                    SqlCommand cmd = new SqlCommand(str, com);
                    //-------------------------------------------------------------------------------------------------------------------------------------

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    txtDescription.Text = reader["Summary"].ToString();

                    reader.Close();

                }
            }

        }

        protected void Summarybtn_edit_Click(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int _id = Int32.Parse(a);


            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {

                SqlCommand cmd2 = new SqlCommand("edit_summary", com);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd2.Parameters.AddWithValue("@id", _id);
                cmd2.Parameters.AddWithValue("@txt", txtDescription.Text);

                //Execution
                com.Open();
                cmd2.ExecuteNonQuery();

            }
            Response.Redirect("Profile.aspx");

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int _id = Int32.Parse(a);

            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);


                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spUploadImage", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //SqlParameter paramName = new SqlParameter()
                    //{
                    //    ParameterName = @"Name",
                    //    Value = filename
                    //};
                    //cmd.Parameters.Add(paramName);

                    //SqlParameter paramSize = new SqlParameter()
                    //{
                    //    ParameterName = "@Size",
                    //    Value = fileSize
                    //};
                    //cmd.Parameters.Add(paramSize);

                    SqlParameter paramImageData = new SqlParameter()
                    {
                        ParameterName = "@ImageData",
                        Value = bytes
                    };
                    cmd.Parameters.Add(paramImageData);

                    SqlParameter paramNewId = new SqlParameter()
                    {
                        ParameterName = "@NewId",
                        Value = _id,
                    };
                    cmd.Parameters.Add(paramNewId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Upload Successful";
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";
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