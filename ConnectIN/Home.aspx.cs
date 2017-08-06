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
using System.IO;

namespace ConnectIN
{
    public partial class Home : System.Web.UI.Page
    {
        
        private static readonly string connString =
       System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void like_click(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
        int user_id = Int32.Parse(a);

        int uid = user_id;

            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("Home.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "L";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);

                int pid = Convert.ToInt32(lastDigits);
                int counter;
                using (SqlConnection con = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("check_likes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramName = new SqlParameter()
                    {
                        ParameterName = "@uid",
                        Value = uid
                    };
                    cmd.Parameters.Add(paramName);
                    SqlParameter paramSize = new SqlParameter()
                    {
                        ParameterName = "@pid",
                        Value = pid
                    };
                    cmd.Parameters.Add(paramSize);

                    SqlParameter paramNewId = new SqlParameter()
                    {
                        ParameterName = "@output",
                        Value = -1,
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramNewId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    counter = Convert.ToInt32(cmd.Parameters["@output"].Value);
                }
                if (counter == 0)
                {
                    SqlConnection con2 = new SqlConnection(connString);
                    con2.Open(); // open sql Connection
                    //     SqlCommand cmd;

                    SqlCommand cmd2;
                    cmd2 = new SqlCommand("insert into Likes values('" + pid + "','" + uid + "')", con2);
                    SqlDataReader rdr2 = cmd2.ExecuteReader();
                    Response.Redirect("Home.aspx?do" + lastDigits);
                }
                else
                {
                    Response.Redirect("Home.aspx?do" + "already");
                }
            }
        }
        protected void comment_click(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);

            int uid = user_id;

            ImageButton clickedButton = sender as ImageButton;
            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("Home.aspx?nothing");
                return;
            }
            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "C";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);

                int pid = Convert.ToInt32(lastDigits);
                String ss = pid.ToString();
                ss = "Comment" + ss;
                TextBox tb = p1.FindControl(ss) as TextBox;
                String res = tb.Text;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                SqlCommand cmd2;
                if (res != "")
                {
                    cmd2 = new SqlCommand("insert into Comment values('" + res + "','" + pid + "','" + uid + "')", con);
                    SqlDataReader rdr2 = cmd2.ExecuteReader();
                    Response.Redirect("Home.aspx?do" + lastDigits);
                }
                else
                {

                }
            }
        }
        protected void share_click(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);

            int uid = user_id;

            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("Home.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "S";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);

                int pid = Convert.ToInt32(lastDigits);
                SqlConnection con = new SqlConnection(connString);
                con.Open(); // open sql Connection
                //     SqlCommand cmd;
                SqlCommand cmd2;
                cmd2 = new SqlCommand("insert into Shares values('" + pid + "','" + uid + "')", con);
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                Response.Redirect("Home.aspx?do" + lastDigits);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);

            int uid = user_id;

            SqlConnection con = new SqlConnection(connString);
            con.Open(); // open sql Connection
            //     SqlCommand cmd;
            SqlCommand cmd2, cmd;
            List<SqlCommand> commands = new List<SqlCommand>();
            List<SqlDataReader> readers = new List<SqlDataReader>();
            cmd = new SqlCommand("select count(*) from Post  where Post.UserID in (select Connection.Userwith from Connection where Connection.User_='" + uid + "') or Post.UserID='" + uid + "'", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            int postcount = 0;
            while (rdr.Read())
            {
                postcount = rdr.GetInt32(0);
            }
            cmd2 = new SqlCommand("select Users.UserID,Users.First_name,Users.Last_name,Post.Post_text,Post.Post_DP as DP,Post.Like_count,Post.Comment_count,Post.Share_count,Post.timest,Post.PostID,Users.DP as udp from Post inner join Users on Users.UserID=Post.UserID where Post.UserID in(select Connection.Userwith from Connection where Connection.User_='" + uid + "') or Post.UserID='" + uid + "' order by Post.timest desc", con);
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                Image img1 = new Image();
                img1.Height = 250;
                img1.Width = 300;
                img1.CssClass = "img-thumbnail";
                Image img2 = new Image();
                img2.Height = 60;
                img2.Width = 60;
                img2.CssClass = "img-thumbnail";
                img2.ImageUrl = "~/assets/img/user.png";
                if (rdr2["udp"] != DBNull.Value)
                {

                    byte[] imagem = (byte[])(rdr2["udp"]);
                    string base64String = Convert.ToBase64String(imagem);
                    img2.ImageUrl = "data:Image/jpg;base64," + base64String;
                    p1.Controls.Add(img2);
                    Label blank = new Label();
                    blank.Text = "  ";
                    p1.Controls.Add(blank);

                }
                else
                {
                    p1.Controls.Add(img2);
                    Label blank = new Label();
                    blank.Text = "  ";
                    p1.Controls.Add(blank);

                }

                int id = rdr2.GetInt32(0);
                String name = rdr2.GetString(1).ToString();
                name = name + " " + rdr2.GetString(2);
                int pid = rdr2.GetInt32(9);
                Label lbl = new Label();
                lbl.Text = name + "<br>" + "<br>";
                lbl.Font.Bold = true;
                lbl.Font.Size = 20;
                //lbl.BackColor = System.Drawing.Color.Black;
                //lbl.ForeColor = System.Drawing.Color.Violet;
                //lbl.TabIndex++;
                this.p1.Controls.Add(lbl);
                Label lbl2 = new Label();
                lbl2.Text = rdr2.GetString(3).ToString() + "<br>" + "<br>";
                lbl2.Font.Size = 16;
                lbl2.BackColor = System.Drawing.Color.White;
                lbl2.ForeColor = System.Drawing.Color.Black;
                lbl2.Font.Bold = true;
                this.p1.Controls.Add(lbl2);
                if (rdr2["DP"] != DBNull.Value)
                {

                    byte[] imagem = (byte[])(rdr2["DP"]);
                    string base64String = Convert.ToBase64String(imagem);
                    img1.ImageUrl = "data:Image/jpg;base64," + base64String;
                    p1.Controls.Add(img1);
                    Label blank = new Label();
                    blank.Text = "<br>";
                    p1.Controls.Add(blank);
                }
                Label lbl3 = new Label();
                Label ll1 = new Label();
                Label ll2 = new Label();
                Label ll3 = new Label();
                Label ll4 = new Label();
                Label ll5 = new Label();
                Label ll6 = new Label();
                lbl3.Text = "Likes ";
                lbl3.Font.Size = 14;
                lbl3.ForeColor = System.Drawing.Color.Red;
                ll1.Text = rdr2.GetInt32(5).ToString();
                ll1.Font.Size = 16;
                ll1.Font.Bold = true;
                ll2.Text = " Comments ";
                ll2.Font.Size = 14;
                ll2.ForeColor = System.Drawing.Color.Green;
                ll3.Text = rdr2.GetInt32(6).ToString();
                ll3.Font.Size = 16;
                ll3.Font.Bold = true;
                ll4.Text = " Shares ";
                ll4.Font.Size = 14;
                ll4.ForeColor = System.Drawing.Color.Blue;
                ll5.Text = rdr2.GetInt32(7).ToString();
                ll5.Font.Size = 16;
                ll5.Font.Bold = true;
                ll6.Text = "<br><br>";
                this.p1.Controls.Add(lbl3);
                this.p1.Controls.Add(ll1);
                this.p1.Controls.Add(ll2);
                this.p1.Controls.Add(ll3);
                this.p1.Controls.Add(ll4);
                this.p1.Controls.Add(ll5);
                this.p1.Controls.Add(ll6);
                SqlCommand cc = new SqlCommand("select Comment.comment_text,Users.DP as udp from Comment inner join Users on Users.UserID=Comment.UserBy where PostID='" + pid + "'", con);
                SqlDataReader rr = cc.ExecuteReader();
                while (rr.Read())
                {
                    Image img3 = new Image();
                    img3.Height = 40;
                    img3.Width = 40;
                    img3.CssClass = "img-thumbnail";
                    img3.ImageUrl = "~/assets/img/user.png";
                    if (rr["udp"] != DBNull.Value)
                    {

                        byte[] imagem = (byte[])(rr["udp"]);
                        string base64String = Convert.ToBase64String(imagem);
                        img3.ImageUrl = "data:Image/jpg;base64," + base64String;
                        p1.Controls.Add(img3);
                        Label shpace = new Label();
                        shpace.Text = "  ";
                        p1.Controls.Add(shpace);
                        Label showcomm = new Label();
                        //showcomm.ID = "sc" + pid.ToString();
                        showcomm.Font.Size = 13;
                        showcomm.Font.Bold = true;
                        showcomm.ForeColor = System.Drawing.Color.Black;
                        showcomm.BackColor = System.Drawing.Color.Yellow;
                        showcomm.Text = rr.GetString(0).ToString() + "<br>";
                        p1.Controls.Add(showcomm);
                    }
                    else
                    {
                        p1.Controls.Add(img3);
                        Label shpace = new Label();
                        shpace.Text = "  ";
                        p1.Controls.Add(shpace);
                        Label showcomm = new Label();
                        //showcomm.ID = "sc" + pid.ToString();
                        showcomm.Font.Size = 13;
                        showcomm.Font.Bold = true;
                        showcomm.ForeColor = System.Drawing.Color.Black;
                        showcomm.BackColor = System.Drawing.Color.Yellow;
                        showcomm.Text = rr.GetString(0).ToString() + "<br>";
                        p1.Controls.Add(showcomm);
                    }
                }
                rr.Close();
                Label abc = new Label();
                abc.Text = "<br>";
                p1.Controls.Add(abc);
                ImageButton bb = new ImageButton();
                bb.Width = 30;
                bb.Height = 25;
                bb.ImageUrl = "~/assets/img/like-2.png";
                bb.BackColor = System.Drawing.Color.Red;
                // bb.Text = "Like";
                String lid = "L" + pid.ToString();
                bb.ID = lid;
                bb.Click += new ImageClickEventHandler(like_click);
                this.p1.Controls.Add(bb);
                TextBox comment = new TextBox();
                lid = "Comment" + pid.ToString();
                comment.ID = lid;
                comment.Height = 30;
                comment.ForeColor = System.Drawing.Color.Purple;
                this.p1.Controls.Add(comment);
                //    comment.Visible = false;
                ImageButton bb1 = new ImageButton();
                bb1.TabIndex = bb.TabIndex;
                //  bb1.Text = "Comment";
                bb1.ImageUrl = "~/assets/img/edit.png";
                bb1.Width = 30;
                bb1.Height = 25;
                bb1.ForeColor = System.Drawing.Color.Yellow;
                lid = "C" + pid.ToString();
                bb1.ID = lid;
                bb1.Click += new ImageClickEventHandler(comment_click);
                this.p1.Controls.Add(bb1);
                ImageButton bb2 = new ImageButton();
                //   bb2.Text = "Share";
                bb2.Width = 30;
                bb2.Height = 25;
                //  bb.BackColor = System.Drawing.Color.LightBlue;
                bb2.ImageUrl = "~/assets/img/share.png";
                bb2.TabIndex = bb.TabIndex;
                lid = "S" + pid.ToString();
                bb2.ID = lid;
                bb2.Click += new ImageClickEventHandler(share_click);
                this.p1.Controls.Add(bb2);
                Label lbl4 = new Label();
                lbl4.Text = "<br>";
                this.p1.Controls.Add(lbl4);

                Label newlines = new Label();
                newlines.Text = "<hr/>";
                p1.Controls.Add(newlines);

            }
            if (!IsPostBack)
            {
                addimg.Visible = false;
                postcontent.Visible = false;
                confirm.Visible = false;
                postcontent.Text = "";
                this.FileUpload1.Visible = false;
            }

        }
        protected void post_Click(object sender, EventArgs e)
        {
            addimg.Visible = true;
            postcontent.Visible = true;
            confirm.Visible = true;
        }
        protected void confirm_Click(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);

            int uid = user_id;

            HttpPostedFile postedFile = FileUpload1.PostedFile;
            Byte[] bytes = null;
            if (FileUpload1.HasFile == true)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                int fileSize = postedFile.ContentLength;


                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                    || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    bytes = binaryReader.ReadBytes((int)stream.Length);
                    using (SqlConnection con = new SqlConnection(connString))
                    {
                        SqlCommand cmd = new SqlCommand("spUploadImages", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramName = new SqlParameter()
                        {
                            ParameterName = "@uid",
                            Value = uid
                        };
                        cmd.Parameters.Add(paramName);
                        SqlParameter paramSize = new SqlParameter()
                        {
                            ParameterName = "@posttext",
                            Value = postcontent.Text
                        };
                        cmd.Parameters.Add(paramSize);

                        SqlParameter paramImageData = new SqlParameter()
                        {
                            ParameterName = "@ImageData",
                            Value = bytes
                        };
                        cmd.Parameters.Add(paramImageData);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";
                }

            }
            else
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    SqlCommand cmd2 = new SqlCommand("spUploadImagewithoutimage", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramName = new SqlParameter()
                    {
                        ParameterName = "@uid",
                        Value = uid
                    };
                    cmd2.Parameters.Add(paramName);
                    SqlParameter paramSize = new SqlParameter()
                    {
                        ParameterName = "@posttext",
                        Value = postcontent.Text
                    };
                    cmd2.Parameters.Add(paramSize);
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
            }

            Response.Redirect("Home.aspx");
        }
        protected void addimg_Click(object sender, EventArgs e)
        {
            FileUpload1.Visible = true;
        }
    }
}