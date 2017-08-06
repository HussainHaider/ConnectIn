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
    public partial class SearchProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Session["CID"].ToString();
            int user_id = Int32.Parse(a);

            string b = Session["ID"].ToString();
            int C_id = Int32.Parse(b);
//            int user_id = 16;

            if (!IsPostBack)
            {
                Disconnect.Visible = false;
            }

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {
                com.Open();

                SqlCommand cmd25 = new SqlCommand("check_Request", com);
                cmd25.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd25.Parameters.AddWithValue("@User1_ID", C_id);
                cmd25.Parameters.AddWithValue("@User2_ID", user_id);


                SqlParameter outPutParameter11 = new SqlParameter();
                outPutParameter11.ParameterName = "@ch";//outuput parameter of the count_no_of_s...
                outPutParameter11.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter11.Direction = System.Data.ParameterDirection.Output;
                cmd25.Parameters.Add(outPutParameter11);
                //Execution
                cmd25.ExecuteNonQuery();

                string num2 = outPutParameter11.Value.ToString();
                int check2_ = Convert.ToInt32(num2);
                if (check2_ > 0)
                {
                    Send_requestbtn.Text = "Request is on Pending";
                }



                SqlCommand cmd24 = new SqlCommand("check_Connection", com);
                cmd24.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd24.Parameters.AddWithValue("@User1_ID", user_id);
                cmd24.Parameters.AddWithValue("@User2_ID", C_id);


                SqlParameter outPutParameter10 = new SqlParameter();
                outPutParameter10.ParameterName = "@ch";//outuput parameter of the count_no_of_s...
                outPutParameter10.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter10.Direction = System.Data.ParameterDirection.Output;
                cmd24.Parameters.Add(outPutParameter10);
                //Execution
                cmd24.ExecuteNonQuery();

                string num1 = outPutParameter10.Value.ToString();
                int check1_ = Convert.ToInt32(num1);

                if (check1_ > 0 && check2_==0)
                {
                    Send_requestbtn.Visible = false;
                    Disconnect.Visible = true;
                }
                else
                {

                }











                string str = "Select * from ViewProjects where UserID=" + user_id;
                SqlCommand cmd = new SqlCommand(str, com);
                //-------------------------------------------------------------------------------------------------------------------------------------
                //2nd Qyery for Count the number of Projects of the UserS
                //SqlCommand cmd2 = new SqlCommand("countProjects", com);
                //cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                ////Add the input parameters to the command object
                //cmd2.Parameters.AddWithValue("@ID", user_id);

                //SqlParameter outPutParameter = new SqlParameter();
                //outPutParameter.ParameterName = "@countfor";//outuput parameter of the count_no_of_Projects...
                //outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                //outPutParameter.Direction = System.Data.ParameterDirection.Output;
                //cmd2.Parameters.Add(outPutParameter);
                ////Execution
                //cmd2.ExecuteNonQuery();
                //string n = outPutParameter.Value.ToString();
                //int count_projects = Convert.ToInt32(n);

                DAL_meaages objMyDal = new DAL_meaages();

                int count_projects = 0;

                count_projects = objMyDal.countprojects(user_id);

                //-------------------------------------------------------------------------------------------------------------------------------------



                //3th Qyery  to get the User (Stored Procedure) image
                SqlCommand cmd3 = new SqlCommand("GetImageById", com);
                cmd3.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = user_id //change the parameter here....
                    //                    Value = Request.QueryString["Id"]
                };

                cmd3.Parameters.Add(paramId);
                if (cmd3.ExecuteScalar() != DBNull.Value)
                {
                    byte[] bytes = (byte[])cmd3.ExecuteScalar();
                    string strBase64 = Convert.ToBase64String(bytes);
                    Image1.ImageUrl = "data:Image/png;base64," + strBase64;
                }
                //-------------------------------------------------------------------------------------------------------------------------------------



                //4th Qyery  to get the User (Stored Procedure) first_name and last_name....
                SqlCommand cmd4 = new SqlCommand("GetUserName", com);

                cmd4.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd4.Parameters.AddWithValue("@ID", user_id);

                //firstouputparameter(first name)
                SqlParameter outPutParameter1 = new SqlParameter();
                outPutParameter1.ParameterName = "@Fname";//outuput parameter to get the first name of the user...
                outPutParameter1.SqlDbType = System.Data.SqlDbType.VarChar;
                outPutParameter1.Size = 50;
                outPutParameter1.Direction = System.Data.ParameterDirection.Output;
                cmd4.Parameters.Add(outPutParameter1);

                //Secondouputparameter(Last name)
                SqlParameter outPutParameter2 = new SqlParameter();
                outPutParameter2.ParameterName = "@Lname";//outuput parameter to get the Last name of the user...
                outPutParameter2.SqlDbType = System.Data.SqlDbType.VarChar;
                outPutParameter2.Size = 50;
                outPutParameter2.Direction = System.Data.ParameterDirection.Output;
                cmd4.Parameters.Add(outPutParameter2);

                //Execution
                cmd4.ExecuteNonQuery();

                string Firstname = outPutParameter1.Value.ToString();
                string Lastname = outPutParameter2.Value.ToString();

                //doing
                Label lbl2 = new Label();
                lbl2.Font.Size = 20;
                lbl2.Font.Bold = true;
                lbl2.Text = Firstname + "&nbsp" + Lastname;
                label2.Controls.Add(lbl2);

                //-------------------------------------------------------------------------------------------------------------------------------------
                //6th Qyery for Count the number of Language of the User
                //SqlCommand cmd6 = new SqlCommand("countLanguages", com);
                //cmd6.CommandType = System.Data.CommandType.StoredProcedure;

                ////Add the input parameters to the command object
                //cmd6.Parameters.AddWithValue("@ID", user_id);

                //SqlParameter outPutParameter3 = new SqlParameter();
                //outPutParameter3.ParameterName = "@countfor";//outuput parameter of the count_no_of_Projects...
                //outPutParameter3.SqlDbType = System.Data.SqlDbType.Int;
                //outPutParameter3.Direction = System.Data.ParameterDirection.Output;
                //cmd6.Parameters.Add(outPutParameter3);
                ////Execution
                //cmd6.ExecuteNonQuery();

                //string n1 = outPutParameter3.Value.ToString();
                //int count_Language = Convert.ToInt32(n1);

                int count_Language = 0;

                count_Language = objMyDal.countLanguages(user_id);



                //-------------------------------------------------------------------------------------------------------------------------------------
                //5th Qyery Display the languages of the users
                string str1 = "Select * from ViewLanguages where UserID=" + user_id;
                SqlCommand cmd5 = new SqlCommand(str1, com);
                SqlDataReader reader1 = cmd5.ExecuteReader();


                string LID = null;

//                label7.Text = "Count is :" + count_Language;
                for (int i = 0; i < count_Language; i++)
                {

                    reader1.Read();


                    Label lbl3 = new Label();
                    lbl3.Font.Size = 20;
                    lbl3.Attributes.CssStyle.Add("margin-left", "20px");
                    lbl3.Text = reader1["Language"].ToString();

                    LID = reader1["LanguageID"].ToString();


                    if (i / 4 != 0)
                    {
                        lbl3.Text = lbl3.Text + "<br/><br/><br/>";
                    }
                    panelLanguages.Controls.Add(lbl3);
                }
                reader1.Close();

                //-------------------------------------------------------------------------------------------------------------------------------------
                //7th Qyery for Count the number of Experience of the User
                //SqlCommand cmd7 = new SqlCommand("countExperience", com);
                //cmd7.CommandType = System.Data.CommandType.StoredProcedure;

                ////Add the input parameters to the command object
                //cmd7.Parameters.AddWithValue("@ID", user_id);

                //SqlParameter outPutParameter4 = new SqlParameter();
                //outPutParameter4.ParameterName = "@countfor";//outuput parameter of the count_no_of_Experience...
                //outPutParameter4.SqlDbType = System.Data.SqlDbType.Int;
                //outPutParameter4.Direction = System.Data.ParameterDirection.Output;
                //cmd7.Parameters.Add(outPutParameter4);
                ////Execution
                //cmd7.ExecuteNonQuery();

                //string n2 = outPutParameter4.Value.ToString();
                //int count_Experience = Convert.ToInt32(n2);
                //label3.Text = "Count is :" + count_Experience;

                int count_Experience = 0;

                count_Experience = objMyDal.countExperience(user_id);

               // label3.Text = "Count is :" + count_Experience;
                


                //-------------------------------------------------------------------------------------------------------------------------------------
                //8th Qyery for Count the number of Skill of the User
                //SqlCommand cmd8 = new SqlCommand("countskills", com);
                //cmd8.CommandType = System.Data.CommandType.StoredProcedure;

                ////Add the input parameters to the command object
                //cmd8.Parameters.AddWithValue("@ID", user_id);

                //SqlParameter outPutParameter5 = new SqlParameter();
                //outPutParameter5.ParameterName = "@countfor";//outuput parameter of the count_no_of_s...
                //outPutParameter5.SqlDbType = System.Data.SqlDbType.Int;
                //outPutParameter5.Direction = System.Data.ParameterDirection.Output;
                //cmd8.Parameters.Add(outPutParameter5);
                ////Execution
                //cmd8.ExecuteNonQuery();

                //string n3 = outPutParameter5.Value.ToString();
                //int count_skills = Convert.ToInt32(n3);
                //label6.Text = "Count is :" + count_skills;

                int count_skills = 0;

                count_skills = objMyDal.countskills_(user_id);

            //    label6.Text = "Count is :" + count_skills;





                //-------------------------------------------------------------------------------------------------------------------------------------
                //9th Qyery for Count the number of Education of the User
                //SqlCommand cmd9 = new SqlCommand("countEducation", com);
                //cmd9.CommandType = System.Data.CommandType.StoredProcedure;

                ////Add the input parameters to the command object
                //cmd9.Parameters.AddWithValue("@ID", user_id);

                //SqlParameter outPutParameter6 = new SqlParameter();
                //outPutParameter6.ParameterName = "@countfor";//outuput parameter of the count_no_of_s...
                //outPutParameter6.SqlDbType = System.Data.SqlDbType.Int;
                //outPutParameter6.Direction = System.Data.ParameterDirection.Output;
                //cmd9.Parameters.Add(outPutParameter6);
                ////Execution
                //cmd9.ExecuteNonQuery();

                //string n4 = outPutParameter6.Value.ToString();
                //int count_Education = Convert.ToInt32(n4);
                //label4.Text = "Count is :" + count_Education;

                int count_Education = 0;

                count_Education = objMyDal.countEducation(user_id);

           //     label4.Text = "Count is :" + count_Education;




                //-------------------------------------------------------------------------------------------------------------------------------------
                //10th Qyery for Count the number of Awards of the User
                //SqlCommand cmd10 = new SqlCommand("countHonors", com);
                //cmd10.CommandType = System.Data.CommandType.StoredProcedure;

                ////Add the input parameters to the command object
                //cmd10.Parameters.AddWithValue("@ID", user_id);

                //SqlParameter outPutParameter7 = new SqlParameter();
                //outPutParameter7.ParameterName = "@countfor";//outuput parameter of the count_no_of_s...
                //outPutParameter7.SqlDbType = System.Data.SqlDbType.Int;
                //outPutParameter7.Direction = System.Data.ParameterDirection.Output;
                //cmd10.Parameters.Add(outPutParameter7);
                ////Execution
                //cmd10.ExecuteNonQuery();

                //string n5 = outPutParameter7.Value.ToString();
                //int count_Honors = Convert.ToInt32(n5);
                //label8.Text = "Count is :" + count_Honors;

                int count_Honors = 0;

                count_Honors = objMyDal.countHonors(user_id);


           //     label8.Text = "Count is :" + count_Honors;






                //-------------------------------------------------------------------------------------------------------------------------------------
                //15th Qyery Display the Education of the users
                string str2 = "Select * from ViewEducation where UserID=" + user_id;
                SqlCommand cmd15 = new SqlCommand(str2, com);
                SqlDataReader reader2 = cmd15.ExecuteReader();


                for (int i = 0; i < count_Education; i++)
                {

                    reader2.Read();


                    string EID = reader2["EducationID"].ToString();

                    Label lbl4 = new Label();
                    lbl4.Font.Size = 20;
                    lbl4.Font.Bold = true;
                    lbl4.Text = reader2["Edu_Institute"].ToString();
                    panelEducation.Controls.Add(lbl4);



                    Label lbl5 = new Label();
                    lbl5.Font.Size = 15;
                    lbl5.Text = "<br/>" + reader2["title"].ToString() + "<br/>";
                    panelEducation.Controls.Add(lbl5);


                    Label lbl6 = new Label();
                    lbl6.Font.Size = 15;
                    lbl6.Text = reader2["Edu_Starting_date"].ToString() + "<br/>";
                    panelEducation.Controls.Add(lbl6);

                    Label lbl7 = new Label();
                    lbl7.Font.Size = 15;
                    lbl7.Text = reader2["Edu_Ending_date"].ToString() + "<br/>";
                    panelEducation.Controls.Add(lbl7);


                    Label lbl8 = new Label();
                    lbl8.Font.Size = 12;
                    lbl8.Text = reader2["Edu_Description"].ToString() + "<br/>";
                    panelEducation.Controls.Add(lbl8);

                }
                reader2.Close();
                //-------------------------------------------------------------------------------------------------------------------------------------
                //16th Qyery Display the Summary of the users
                string str3 = "Select * from Users where UserID=" + user_id;
                SqlCommand cmd16 = new SqlCommand(str3, com);
                SqlDataReader reader3 = cmd16.ExecuteReader();
                reader3.Read();

                Label lbl9 = new Label();
                lbl9.Font.Size = 15;
                lbl9.Text = reader3["Summary"].ToString() + "<br/>";
                panelSummary.Controls.Add(lbl9);
                reader3.Close();
                //-------------------------------------------------------------------------------------------------------------------------------------
                //14th Qyery Display the Awards of the users
                string str4 = "Select * from ViewAwards where UserID=" + user_id;
                SqlCommand cmd14 = new SqlCommand(str4, com);
                SqlDataReader reader4 = cmd14.ExecuteReader();


                for (int i = 0; i < count_Honors; i++)
                {

                    reader4.Read();

                    string AID = reader4["AwardsID"].ToString();

                    Label lbl10 = new Label();
                    lbl10.Font.Size = 18;
                    lbl10.Font.Bold = true;
                    lbl10.Text = reader4["Award_occupation"].ToString();
                    panelHonors.Controls.Add(lbl10);

                    Label lbl11 = new Label();
                    lbl11.Font.Size = 14;
                    lbl11.Text = "<br/>" + reader4["Award_date"].ToString() + "<br/>";
                    panelHonors.Controls.Add(lbl11);


                    Label lbl12 = new Label();
                    lbl12.Font.Size = 14;
                    lbl12.Text = reader4["Award_Description"].ToString() + "<br/>";
                    panelHonors.Controls.Add(lbl12);


                }
                reader4.Close();
                //-------------------------------------------------------------------------------------------------------------------------------------
                //18th Qyery Display the Experience of the users
                string str5 = "Select * from ViewExperience where UserID=" + user_id;
                SqlCommand cmd18 = new SqlCommand(str5, com);
                SqlDataReader reader5 = cmd18.ExecuteReader();


                for (int i = 0; i < count_Experience; i++)
                {

                    reader5.Read();

                    string Exp_ID = reader5["ExpID"].ToString();

                    Label lbl13 = new Label();
                    lbl13.Font.Size = 18;
                    lbl13.Font.Bold = true;
                    lbl13.Text = reader5["title"].ToString();
                    panelExperience.Controls.Add(lbl13);


                    Label lbl14 = new Label();
                    lbl14.Font.Size = 14;
                    lbl14.Text = "<br/>" + reader5["Exp_Institute"].ToString() + "<br/>";
                    panelExperience.Controls.Add(lbl14);


                    Label lbl15 = new Label();
                    lbl15.Font.Size = 14;
                    lbl15.Text = reader5["Exp_Starting_date"].ToString() + "<br/>";
                    panelExperience.Controls.Add(lbl15);

                    Label lbl16 = new Label();
                    lbl16.Font.Size = 14;
                    lbl16.Text = reader5["Exp_Ending_date"].ToString() + "<br/>";
                    panelExperience.Controls.Add(lbl16);

                    Label lbl17 = new Label();
                    lbl17.Font.Size = 14;
                    lbl17.Text = "Type:" + reader5["type_"].ToString() + "<br/>";
                    panelExperience.Controls.Add(lbl17);


                    Label lbl18 = new Label();
                    lbl18.Font.Size = 14;
                    lbl18.Text = reader5["Proj_Description"].ToString() + "<br/>";
                    panelExperience.Controls.Add(lbl18);


                }
                reader5.Close();
                //-------------------------------------------------------------------------------------------------------------------------------------
                //19th Qyery Display the Skills of the users


                //SqlCommand cmd20 = new SqlCommand("GetImageByskill", com);
                //cmd20.CommandType = CommandType.StoredProcedure;


                string getid = null;
                string getuserby = null;
                string endros_count = null;

                string str6 = "Select * from ViewSkills where UserID=" + user_id;
                SqlCommand cmd19 = new SqlCommand(str6, com);
                SqlDataReader reader6 = cmd19.ExecuteReader();


                string str7 = "Select * from ViewEndorsed where UserTo=" + user_id;
                SqlCommand cmd21 = new SqlCommand(str7, com);
                SqlDataReader reader7 = cmd21.ExecuteReader();





                for (int i = 0; i < count_skills; i++)
                {
                    Label newLine = new Label();
                    Label newLine1 = new Label();

                    reader6.Read();
                    reader7.Read();
                    Label lbl19 = new Label();
                    lbl19.Font.Size = 14;
                    lbl19.Text = reader6["Skill_name"].ToString();
                    endros_count = reader6["Endorse_count"].ToString();
                    int count_Endorsed = Int32.Parse(endros_count);
                    panelSkills.Controls.Add(lbl19);

                    getid = reader6["SkillsID"].ToString();
                    if (count_Endorsed != 0)
                        getuserby = reader7["UserBy"].ToString();
                    int x = Int32.Parse(getid);
                    int y = 0;
                    if (getuserby != null)
                        y = Int32.Parse(getuserby);


                    newLine1.Text = "______________________________________________";
                    panelSkills.Controls.Add(newLine1);

                    //SqlCommand cmd22 = new SqlCommand("countEndorsed", com);
                    //cmd22.CommandType = System.Data.CommandType.StoredProcedure;
                    ////Add the input parameters to the command object
                    //cmd22.Parameters.AddWithValue("@Sid", getid);
                    //SqlParameter outPutParameter8 = new SqlParameter();
                    //outPutParameter8.ParameterName = "@countfor";//outuput parameter of the count_no_of_s...
                    //outPutParameter8.SqlDbType = System.Data.SqlDbType.Int;
                    //outPutParameter8.Direction = System.Data.ParameterDirection.Output;
                    //cmd22.Parameters.Add(outPutParameter8);
                    ////Execution
                    //cmd22.ExecuteNonQuery();
                    //string n6 = outPutParameter8.Value.ToString();
                    //int count_Endorsed = Convert.ToInt32(n6);

                    string str8 = "Select * from ViewEndrosedimage where UserTo=" + user_id + "and SkillID=" + x;
                    SqlCommand cmd22 = new SqlCommand(str8, com);
                    SqlDataReader reader8 = cmd22.ExecuteReader();


                    for (int j = 0; j < count_Endorsed; j++)
                    {
                        Image img1 = new Image();
                        img1.Height = 50;
                        img1.Width = 50;
                        img1.CssClass = "img-thumbnail";


                        reader8.Read();

                        if (reader8["DP"] != DBNull.Value)
                        {
                            byte[] imagem = (byte[])(reader8["DP"]);
                            string base64String = Convert.ToBase64String(imagem);
                            img1.ImageUrl = "data:Image/png;base64," + base64String;
                        }
                        panelSkills.Controls.Add(img1);

                    }


                    SqlCommand cmd23 = new SqlCommand("check_Connection", com);
                    cmd23.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd23.Parameters.AddWithValue("@User1_ID", user_id);
                    cmd23.Parameters.AddWithValue("@User2_ID", C_id);


                    SqlParameter outPutParameter9 = new SqlParameter();
                    outPutParameter9.ParameterName = "@ch";//outuput parameter of the count_no_of_s...
                    outPutParameter9.SqlDbType = System.Data.SqlDbType.Int;
                    outPutParameter9.Direction = System.Data.ParameterDirection.Output;
                    cmd23.Parameters.Add(outPutParameter9);
                    //Execution
                    cmd23.ExecuteNonQuery();

                    string num = outPutParameter9.Value.ToString();
                    int check_ = Convert.ToInt32(num);


                    if(check_>0)
                    {
                        //vector ya list bano.....
                        Button buttonendorse = new Button();
                        buttonendorse.ID = "button_endorse" + getid;
                        buttonendorse.Text = "Endorse";
                        buttonendorse.Width = 65;
                        buttonendorse.Height = 30;
                        buttonendorse.BackColor = System.Drawing.Color.Aqua;
                        buttonendorse.Font.Bold = true;
                        buttonendorse.ForeColor = System.Drawing.Color.Black;
                        panelSkills.Controls.Add(buttonendorse);
                        buttonendorse.Click += new EventHandler(buttonendorse_Click);

                    }

                    newLine.Text = "<br/>";
                    panelSkills.Controls.Add(newLine);
                    reader8.Close();

                }
                reader6.Close();
                reader7.Close();

                //-------------------------------------------------------------------------------------------------------------------------------------
                //Projects record.................
                SqlDataReader reader = cmd.ExecuteReader();
//                labels1.Text = "Count is :" + count_projects;


                for (int i = 0; i < count_projects; i++)
                {
                    reader.Read();
                    string Pid = reader["ProjectID"].ToString();

                    Label lbl1 = new Label();
                    lbl1.Font.Size = 20;
                    lbl1.Font.Bold = true;
                    lbl1.Text = reader["Proj_name"].ToString();
                    panelproject.Controls.Add(lbl1);

                    Label lbl = new Label();
                    lbl.Font.Size = 12;
                    lbl.Text = "<br/>" + reader["Proj_Description"].ToString() + "<br/>" + "<br/>" + "<br/>";
                    panelproject.Controls.Add(lbl);
                }
                reader.Close();
            }
        }


        protected void buttonendorse_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("SearchProfile.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "button_endorse";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);
                string abc = Session["ID"].ToString();//jo watch kr raha ha...

                string a = Session["CID"].ToString();
                int U_id = Int32.Parse(a);

            string b = Session["ID"].ToString();
            int C_id = Int32.Parse(b);


            int count_endorse = 0;


                String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection com1 = new SqlConnection(cs))
                {
                    com1.Open();

                    //// Qyery to get Endorse Count  of the Skill
                    //SqlCommand cmd2 = new SqlCommand("get_Endorsecount", com1);
                    //cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    ////Add the input parameters to the command object
                    //cmd2.Parameters.AddWithValue("@ID",lastDigits);

                    //SqlParameter outPutParameter = new SqlParameter();
                    //outPutParameter.ParameterName = "@countfor";//outuput parameter of the count_no_of_Projects...
                    //outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                    //outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    //cmd2.Parameters.Add(outPutParameter);
                    ////Execution
                    //cmd2.ExecuteNonQuery();
                    //string n = outPutParameter.Value.ToString();
                    //count_endorse = Convert.ToInt32(n);




                    //count_endorse++;

                    //SqlCommand cmd3 = new SqlCommand("set_Endorsecount", com1);
                    //cmd3.CommandType = System.Data.CommandType.StoredProcedure;

                    ////Add the input parameters to the command object
                    //cmd3.Parameters.AddWithValue("@ID",lastDigits);
                    //cmd3.Parameters.AddWithValue("@count", count_endorse);
                    ////Execution
                    //cmd3.ExecuteNonQuery();
                    SqlCommand cmd5 = new SqlCommand("check_Endorsement", com1);
                    cmd5.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd5.Parameters.AddWithValue("@Userby_ID", b);
                    cmd5.Parameters.AddWithValue("@Userto_ID", a);
                    cmd5.Parameters.AddWithValue("@skillID", lastDigits);
                    //Execution
                    cmd5.ExecuteNonQuery();






                    SqlCommand cmd4 = new SqlCommand("set_Endorsement", com1);
                    cmd4.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd4.Parameters.AddWithValue("@Userby_ID", b);
                    cmd4.Parameters.AddWithValue("@Userto_ID", a);
                    cmd4.Parameters.AddWithValue("@skillID", lastDigits);
                    //Execution
                    cmd4.ExecuteNonQuery();





                }
                Response.Redirect("SearchProfile.aspx?do" + count_endorse);


            }

        }
        protected void search_Click1(object sender, ImageClickEventArgs e)
        {
            string abc = Session["ID"].ToString();

            Session["CID"] = abc;

            Session["txt"] = Search_txt.Text;
            Response.Redirect("Search.aspx?ID" + abc);
        }

        protected void Send_requestbtn_Click(object sender, EventArgs e)
        {

            string a = Session["CID"].ToString();
            int user_id = Int32.Parse(a);

            string b = Session["ID"].ToString();
            int C_id = Int32.Parse(b);
            
            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {

                com.Open();
                SqlCommand cmd4 = new SqlCommand("add_request", com);
                cmd4.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd4.Parameters.AddWithValue("@User1_ID ", C_id);
                cmd4.Parameters.AddWithValue("@User2_ID ", user_id);
                //Execution
                cmd4.ExecuteNonQuery();
            }
            Response.Redirect("SearchProfile.aspx");
        }

        protected void Disconnect_Click(object sender, EventArgs e)
        {

            string a = Session["CID"].ToString();
            int user_id = Int32.Parse(a);

            string b = Session["ID"].ToString();
            int C_id = Int32.Parse(b);

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {

                com.Open();
                SqlCommand cmd4 = new SqlCommand("delete_Connection", com);
                cmd4.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd4.Parameters.AddWithValue("@User1_ID ", C_id);
                cmd4.Parameters.AddWithValue("@User2_ID ", user_id);
                //Execution
                cmd4.ExecuteNonQuery();
            }
            Response.Redirect("SearchProfile.aspx");
        }


    }
}