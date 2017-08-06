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
using System;
using System.Globalization;
using System.Threading;
using System.Text;
using ConnectIN.DAL;
namespace ConnectIN
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);
            //int user_id = 16;

            if (!IsPostBack)
            {

                //addprojects
                label_addproject_title.Visible = false;
                label_addproject_Description.Visible = false;
                addprojectext_title.Visible = false;
                addprojectext_Description.Visible = false;
                addprojectbtn.Visible = false;

                //addLanguage
                label_add_Language.Visible = false;
                add_Language_text.Visible = false;
                add_Languagebtn.Visible = false;

                //addawards
                label_addaward_occupation.Visible = false;
                addaward_occupation.Visible = false;
                label_addaward_Date.Visible = false;
                addaward_Date.Visible = false;
                label_addaward_Description.Visible = false;
                addaward_Description.Visible = false;
                add_awardbtn.Visible = false;

                //addSkill
                label_add_skill.Visible = false;
                add_skill_text.Visible = false;
                add_skillbtn.Visible = false;

                //addEducation
                label_addEducation_Description.Visible = false;
                label_addEducation_EDate.Visible = false;
                label_addEducation_Field.Visible = false;
                label_addEducation_school.Visible = false;
                label_addEducation_SDate.Visible = false;
                addEducation_Description.Visible = false;
                addEducationbtn.Visible = false;
                //            SDate_ImageButton.Visible = false;
                //            EDate_ImageButton.Visible = false;
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                addEducation_EDate.Visible = false;
                addEducation_Field.Visible = false;
                addEducation_school.Visible = false;
                addEducation_SDate.Visible = false;


                //addExperience
                label_addExperience_company.Visible = false;
                addExperience_company.Visible = false;
                label_addExperience_title.Visible = false;
                addExperience_title.Visible = false;
                label_addExperience_Sdate.Visible = false;
                addExperience_Sdate.Visible = false;
                Calendar3.Visible = false;
                label_addExperience_Edate.Visible = false;
                addExperience_Edate.Visible = false;
                Calendar4.Visible = false;
                label_addExperience_type.Visible = false;
                addExperience_type.Visible = false;
                label_addExperience_Description.Visible = false;
                addExperience_Description.Visible = false;
                addExperiencebtn.Visible = false;

            }

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com = new SqlConnection(cs))
            {
                com.Open();
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
//                    Response.Write(strBase64);
                    Image1.ImageUrl = "data:Image/png;base64," + strBase64;
                }
                else
                {
                    Image1.ImageUrl = "assets/img/user.png";
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

               // DAL_meaages objMyDal = new DAL_meaages();

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


                    ImageButton button_D_Language = new ImageButton();
                    button_D_Language.Width = 45;
                    button_D_Language.Height = 45;
                    //button_D_Language.BackColor = System.Drawing.Color.Red;
                    button_D_Language.Font.Bold = true;
                    //button_D_Language.ForeColor = System.Drawing.Color.White;
                    button_D_Language.ID = "button_D_Language" + LID;
                    button_D_Language.ImageUrl = "assets/img/trash.png";
                    //button_D_Language.Text = "Delete";
                    button_D_Language.Click += new ImageClickEventHandler(button_D_Language_Click);


                    if (i / 4 != 0)
                    {
                        lbl3.Text = lbl3.Text + "<br/><br/><br/>";
                    }
                    panelLanguages.Controls.Add(lbl3);
                    panelLanguages.Controls.Add(button_D_Language);
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

                // DAL_meaages objMyDal = new DAL_meaages();

                int count_Experience = 0;

                count_Experience = objMyDal.countExperience(user_id);

 //               label3.Text = "Count is :" + count_Experience;



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


                int count_skills = 0;

                count_skills = objMyDal.countskills_(user_id);

   //             label6.Text = "Count is :" + count_skills;




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
                int count_Education = 0;

                count_Education = objMyDal.countEducation(user_id);

  //              label4.Text = "Count is :" + count_Education;




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
                int count_Honors = 0;

                count_Honors = objMyDal.countHonors(user_id);


 //               label8.Text = "Count is :" + count_Honors;





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


                    ImageButton button_E_Education = new ImageButton();
                    button_E_Education.Width = 45;
                    button_E_Education.Height = 45;
                    //button_E_Education.BackColor = System.Drawing.Color.YellowGreen;
                    button_E_Education.Font.Bold = true;
                    //button_E_Education.ForeColor = System.Drawing.Color.Black;
                    button_E_Education.ID = "button_E_Education" + EID;
                    //button_E_Education.Text = "Edit";
                    button_E_Education.ImageUrl = "assets/img/edit.png";
                    button_E_Education.Attributes.CssStyle.Add("float", "right");
                    panelEducation.Controls.Add(button_E_Education);
                    button_E_Education.Click += new ImageClickEventHandler(button_E_Education_Click);



                    ImageButton button_D_Education = new ImageButton();
                    button_D_Education.Width = 45;
                    button_D_Education.Height = 45;
                    //button_D_Education.BackColor = System.Drawing.Color.Red;
                    button_D_Education.Font.Bold = true;
                    //button_D_Education.ForeColor = System.Drawing.Color.White;
                    button_D_Education.ID = "button_D_Education" + EID;
                    //button_D_Education.Text = "Delete";
                    button_D_Education.ImageUrl = "assets/img/trash.png";
                    button_D_Education.Attributes.CssStyle.Add("float", "right");
                    panelEducation.Controls.Add(button_D_Education);
                    button_D_Education.Click += new ImageClickEventHandler(button_D_Education_Click);


                    Label lbl5 = new Label();
                    lbl5.Font.Size = 15;
                    lbl5.Text = "<br/>"+reader2["title"].ToString() + "<br/>";
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

                    ImageButton button_E_Award = new ImageButton();
                    button_E_Award.Width = 45;
                    button_E_Award.Height = 45;
                    //button_E_Award.BackColor = System.Drawing.Color.YellowGreen;
                    button_E_Award.Font.Bold = true;
                    //button_E_Award.ForeColor = System.Drawing.Color.Black;
                    button_E_Award.ID = "button_E_Award" + AID;
                    button_E_Award.ImageUrl = "assets/img/edit.png";
                    button_E_Award.Attributes.CssStyle.Add("float", "right");
                    //button_E_Award.Text = "Edit";
                    panelHonors.Controls.Add(button_E_Award);
                    button_E_Award.Click += new ImageClickEventHandler(button_E_Award_Click);


                    ImageButton button_D_Award = new ImageButton();
                    button_D_Award.Width = 45;
                    button_D_Award.Height = 45;
                    //button_D_Award.BackColor = System.Drawing.Color.Red;
                    button_D_Award.Font.Bold = true;
                    button_D_Award.ImageUrl = "assets/img/trash.png";
                    button_D_Award.Attributes.CssStyle.Add("float", "right");
                    //button_D_Award.ForeColor = System.Drawing.Color.White;
                    button_D_Award.ID = "button_D_Award" + AID;
                    //button_D_Award.Text = "Delete";
                    panelHonors.Controls.Add(button_D_Award);
                    button_D_Award.Click += new ImageClickEventHandler(button_D_Award_Click);

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


                    ImageButton button_E_Experience = new ImageButton();
                    button_E_Experience.Width = 45;
                    button_E_Experience.Height = 45;
                    //button_E_Experience.BackColor = System.Drawing.Color.YellowGreen;
                    button_E_Experience.Font.Bold = true;
                    //button_E_Experience.ForeColor = System.Drawing.Color.Black;
                    button_E_Experience.ID = "button_E_Experience" + Exp_ID;
                    //button_E_Experience.Text = "Edit";
                    button_E_Experience.ImageUrl = "assets/img/edit.png";
                    button_E_Experience.Attributes.CssStyle.Add("float", "right");
                    panelExperience.Controls.Add(button_E_Experience);
                    button_E_Experience.Click += new ImageClickEventHandler(button_E_Experience_Click);



                    ImageButton button_D_Experience = new ImageButton();
                    button_D_Experience.Width = 45;
                    button_D_Experience.Height = 45;
                    //button_D_Experience.BackColor = System.Drawing.Color.Red;
                    button_D_Experience.Font.Bold = true;
                    //button_D_Experience.ForeColor = System.Drawing.Color.White;
                    button_D_Experience.ID = "button_D_Experience" + Exp_ID;
                    //button_D_Experience.Text = "Delete";
                    button_D_Experience.ImageUrl = "assets/img/trash.png";
                    button_D_Experience.Attributes.CssStyle.Add("float", "right");
                    panelExperience.Controls.Add(button_D_Experience);
                    button_D_Experience.Click += new ImageClickEventHandler(button_D_Experience_Click);

                    Label lbl14 = new Label();
                    lbl14.Font.Size = 14;
                    lbl14.Text = "<br/>"+reader5["Exp_Institute"].ToString() + "<br/>";
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
                    if(getuserby!=null)
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
                        if (reader8["DP"]!= DBNull.Value)
                        {

                            byte[] imagem = (byte[])(reader8["DP"]);
                            string base64String = Convert.ToBase64String(imagem);
                            img1.ImageUrl = "data:Image/png;base64," + base64String;
                        }
                        else
                        {
                            img1.ImageUrl = "assets/img/user.png";
                        }
                        panelSkills.Controls.Add(img1);

                    }


                    //vector ya list bano.....
                    //Button buttonendorse = new Button();
                    //buttonendorse.ID = "button_endorse" + getid;
                    //buttonendorse.Text = "Endorse";

                    //panelSkills.Controls.Add(buttonendorse);
                    //buttonendorse.Click += new EventHandler(buttonendorse_Click);

                    //Button button_D_Skill = new Button();
                    //button_D_Skill.Width = 65;
                    //button_D_Skill.Height = 30;
                    //button_D_Skill.BackColor = System.Drawing.Color.Red;
                    //button_D_Skill.Font.Bold = true;
                    //button_D_Skill.ForeColor = System.Drawing.Color.White;
                    //button_D_Skill.ID = "button_D_Skill" + getid;
                    //button_D_Skill.Text = "Delete";
                    //panelSkills.Controls.Add(button_D_Skill);
                    //button_D_Skill.Click += new EventHandler(button_D_Skill_Click);





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

                    ImageButton button_E_project = new ImageButton();
                    button_E_project.Width = 45;
                    button_E_project.Height = 45;
                    //button_E_project.BackColor = System.Drawing.Color.YellowGreen;
                    button_E_project.Font.Bold = true;
                    //button_E_project.ForeColor = System.Drawing.Color.Black;
                    button_E_project.ID = "button_E_project" + Pid;
                    button_E_project.ImageUrl = "assets/img/edit.png";
                    button_E_project.Attributes.CssStyle.Add("float", "right");

//                    button_E_project.Text = "Edit";
                    button_E_project.Click += new ImageClickEventHandler(this.button_E_project_Click);
                    panelproject.Controls.Add(button_E_project);


                    //button_E_project.Click += new System.EventHandler(button_E_project_Click);





                    ImageButton button_D_project = new ImageButton();
                    button_D_project.Width = 45;
                    button_D_project.Height = 45;
                    //button_D_project.BackColor = System.Drawing.Color.Red;
                    button_D_project.Font.Bold = true;
                    //button_D_project.ForeColor = System.Drawing.Color.White;
                    button_D_project.ID = "button_D_project" + Pid;
                    button_D_project.ImageUrl = "assets/img/trash.png";
                    button_D_project.Attributes.CssStyle.Add("float", "right");
                    //button_D_project.Text = "Delete";
                    button_D_project.Click += new ImageClickEventHandler(button_D_project_Click);
                    panelproject.Controls.Add(button_D_project);


                    Label lbl = new Label();
                    lbl.Font.Size = 12;
                    lbl.Text = "<br/>" + reader["Proj_Description"].ToString() + "<br/>" + "<br/>" + "<br/>";
                    panelproject.Controls.Add(lbl);
                }
                reader.Close();
            }
        }
        protected void button_E_Experience_Click(object sender, EventArgs e)
        {
            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("EditExperience.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "button_E_Experience";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);

                Session["ExpID"] = lastDigits;
                Response.Redirect("EditExperience.aspx?do" + lastDigits);
            }

        }

        protected void button_D_Experience_Click(object sender, EventArgs e)
        {
            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("Profile.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "button_D_Experience";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);

                String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection com7 = new SqlConnection(cs))
                {

                    SqlCommand cmd2 = new SqlCommand("delete_Experience", com7);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd2.Parameters.AddWithValue("@id", lastDigits);

                    //Execution
                    com7.Open();
                    cmd2.ExecuteNonQuery();

                }

                Response.Redirect("Profile.aspx?do" + lastDigits);

            }

        }
        protected void button_E_Education_Click(object sender, EventArgs e)
        {
            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("EditEducation.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "button_E_Education";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);

                Session["EduID"] = lastDigits;
                Response.Redirect("EditEducation.aspx?do" + lastDigits);
            }

        }
        protected void button_D_Education_Click(object sender, EventArgs e)
        {
            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("Profile.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "button_D_Education";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);


                String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection com7 = new SqlConnection(cs))
                {

                    SqlCommand cmd2 = new SqlCommand("delete_Education", com7);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd2.Parameters.AddWithValue("@id", lastDigits);

                    //Execution
                    com7.Open();
                    cmd2.ExecuteNonQuery();

                }

                Response.Redirect("Profile.aspx?do" + lastDigits);
            }

        }



        protected void button_D_Skill_Click(object sender, EventArgs e)
        {
            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("Profile.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "button_D_Skill";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);


                Response.Redirect("Profile.aspx?do" + lastDigits);
            }

        }
        protected void button_D_Language_Click(object sender, EventArgs e)
        {
            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("Profile.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "button_D_Language";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);


                String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection com7 = new SqlConnection(cs))
                {

                    SqlCommand cmd2 = new SqlCommand("delete_Language", com7);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd2.Parameters.AddWithValue("@id", lastDigits);

                    //Execution
                    com7.Open();
                    cmd2.ExecuteNonQuery();

                }

                Response.Redirect("Profile.aspx?do" + lastDigits);
            }

        }

        //protected void buttonendorse_Click(object sender, EventArgs e)
        //{
        //    Button clickedButton = sender as Button;

        //    if (clickedButton == null) // just to be on the safe side
        //    {
        //        Response.Redirect("Profile.aspx?nothing");
        //        return;
        //    }

        //    if (clickedButton.ID != null)
        //    {
        //        string id = clickedButton.ID;
        //        int len = id.Length;
        //        string L = "button_endorse";
        //        int last = L.Length;

        //        int com = len - last;
        //        string lastDigits = id.Substring((id.Length - com), com);
        //        Response.Redirect("Profile.aspx?do" + lastDigits);


        //    }

        //}

        protected void button_E_project_Click(object sender, EventArgs e)
        {
//            ImageClickEventArgs e2 = (ImageClickEventArgs)e;
            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("EditProject.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "button_E_project";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);

                Session["PID"] = lastDigits;
                Response.Redirect("EditProject.aspx?do" + lastDigits);

            }
        }
        protected void button_D_project_Click(object sender, EventArgs e)
        {
            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("Profile.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "button_D_project";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);

                String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection com7 = new SqlConnection(cs))
                {

                    SqlCommand cmd2 = new SqlCommand("delete_Project", com7);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd2.Parameters.AddWithValue("@id", lastDigits);

                    //Execution
                    com7.Open();
                    cmd2.ExecuteNonQuery();

                }

                Response.Redirect("Profile.aspx?do" + lastDigits);
            }
        }

        protected void button_E_Award_Click(object sender, EventArgs e)
        {
            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("EditAwards.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "button_E_Award";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);

                Session["AID"] = lastDigits;
                Response.Redirect("EditAwards.aspx?do" + lastDigits);


            }
        }

        protected void button_D_Award_Click(object sender, EventArgs e)
        {
            ImageButton clickedButton = sender as ImageButton;

            if (clickedButton == null) // just to be on the safe side
            {
                Response.Redirect("Profile.aspx?nothing");
                return;
            }

            if (clickedButton.ID != null)
            {
                string id = clickedButton.ID;
                int len = id.Length;
                string L = "button_D_Award";
                int last = L.Length;

                int com = len - last;
                string lastDigits = id.Substring((id.Length - com), com);

                String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection com7 = new SqlConnection(cs))
                {

                    SqlCommand cmd2 = new SqlCommand("delete_Award", com7);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    //Add the input parameters to the command object
                    cmd2.Parameters.AddWithValue("@id", lastDigits);

                    //Execution
                    com7.Open();
                    cmd2.ExecuteNonQuery();

                }

                Response.Redirect("Profile.aspx?do" + lastDigits);

            }
        }

        protected void addproject_Click(object sender, EventArgs e)
        {
            label_addproject_title.Font.Size = 15;
            label_addproject_title.Font.Bold = true;

            label_addproject_Description.Font.Size = 15;
            label_addproject_Description.Font.Bold = true;

            label_addproject_title.Visible = true;
            label_addproject_Description.Visible = true;
            addprojectext_title.Visible = true;
            addprojectext_Description.Visible = true;
            addprojectbtn.Visible = true;
        }

        protected void addprojectbtn_Click(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com2 = new SqlConnection(cs))
            {
                SqlCommand cmd12 = new SqlCommand("add_projects", com2);
                cmd12.CommandType = System.Data.CommandType.StoredProcedure;

                cmd12.Parameters.AddWithValue("@project_name", addprojectext_title.Text);
                cmd12.Parameters.AddWithValue("@project_description", addprojectext_Description.Text);
                cmd12.Parameters.AddWithValue("@Userid", user_id);

                com2.Open();
                cmd12.ExecuteNonQuery();

            }
            Response.Redirect(Request.RawUrl);
        }

        protected void add_Language_Click(object sender, EventArgs e)
        {
            label_add_Language.Font.Size = 15;
            label_add_Language.Font.Bold = true;

            label_add_Language.Visible = true;
            add_Language_text.Visible = true;
            add_Languagebtn.Visible = true;
        }

        protected void add_Languagebtn_Click(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com1 = new SqlConnection(cs))
            {
                SqlCommand cmd11 = new SqlCommand("add_Languages", com1);
                cmd11.CommandType = System.Data.CommandType.StoredProcedure;

                cmd11.Parameters.AddWithValue("@Userid", user_id);
                cmd11.Parameters.AddWithValue("@Language", add_Language_text.Text);

                com1.Open();
                cmd11.ExecuteNonQuery();

            }
            Response.Redirect(Request.RawUrl);
        }
        protected void addExperience_Click(object sender, EventArgs e)
        {
            label_addExperience_company.Font.Size = 15;
            label_addExperience_company.Font.Bold = true;
            label_addExperience_company.Visible = true;
            addExperience_company.Visible = true;

            label_addExperience_title.Font.Size = 15;
            label_addExperience_title.Font.Bold = true;
            label_addExperience_title.Visible = true;
            addExperience_title.Visible = true;

            label_addExperience_Sdate.Font.Size = 15;
            label_addExperience_Sdate.Font.Bold = true;
            label_addExperience_Sdate.Visible = true;
            addExperience_Sdate.Visible = true;
            Calendar3.Visible = true;


            label_addExperience_Edate.Font.Size = 15;
            label_addExperience_Edate.Font.Bold = true;
            label_addExperience_Edate.Visible = true;
            addExperience_Edate.Visible = true;
            Calendar4.Visible = true;


            label_addExperience_type.Font.Size = 15;
            label_addExperience_type.Font.Bold = true;
            label_addExperience_type.Visible = true;
            addExperience_type.Visible = true;

            label_addExperience_Description.Font.Size = 15;
            label_addExperience_Description.Font.Bold = true;
            label_addExperience_Description.Visible = true;
            addExperience_Description.Visible = true;
            addExperiencebtn.Visible = true;
        }
        protected void addExperiencebtn_Click(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com5 = new SqlConnection(cs))
            {
                SqlCommand cmd19 = new SqlCommand("add_Experience", com5);
                cmd19.CommandType = System.Data.CommandType.StoredProcedure;

                cmd19.Parameters.AddWithValue("@Userid ", user_id);
                cmd19.Parameters.AddWithValue("@ExpInstitute", addExperience_company.Text);
                cmd19.Parameters.AddWithValue("@ExpStarting_date", addExperience_Sdate.Text);
                cmd19.Parameters.AddWithValue("@ExpEnding_date", addExperience_Edate.Text);
                cmd19.Parameters.AddWithValue("@Exptitle", addExperience_title.Text);
                cmd19.Parameters.AddWithValue("@ExpDescription", addExperience_Description.Text);
                cmd19.Parameters.AddWithValue("@Exptype_", addExperience_type.Text);

                com5.Open();
                cmd19.ExecuteNonQuery();

            }
            Response.Redirect(Request.RawUrl);
        }
        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {

            addExperience_Sdate.Text = Calendar3.SelectedDate.ToString("MM/dd/yyyy");
            Calendar3.Visible = false;
        }
        protected void Calendar4_SelectionChanged(object sender, EventArgs e)
        {
            addExperience_Edate.Text = Calendar4.SelectedDate.ToString("MM/dd/yyyy");
            Calendar4.Visible = false;
        }




        protected void add_award_Click(object sender, EventArgs e)
        {
            label_addaward_occupation.Font.Size = 15;
            label_addaward_occupation.Font.Bold = true;

            label_addaward_occupation.Visible = true;
            addaward_occupation.Visible = true;

            label_addaward_Date.Font.Size = 15;
            label_addaward_Date.Font.Bold = true;

            label_addaward_Date.Visible = true;
            addaward_Date.Visible = true;

            label_addaward_Description.Font.Size = 15;
            label_addaward_Description.Font.Bold = true;

            label_addaward_Description.Visible = true;
            addaward_Description.Visible = true;
            add_awardbtn.Visible = true;
        }

        protected void add_awardbtn_Click(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);
            //            int user_id = 16;

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com4 = new SqlConnection(cs))
            {
                SqlCommand cmd17 = new SqlCommand("add_Award", com4);
                cmd17.CommandType = System.Data.CommandType.StoredProcedure;

                cmd17.Parameters.AddWithValue("@Userid", user_id);
                cmd17.Parameters.AddWithValue("@Award_title", addaward_occupation.Text);
                cmd17.Parameters.AddWithValue("@Award_date", addaward_Date.Text);
                cmd17.Parameters.AddWithValue("@Award_Description", addaward_Description.Text);

                com4.Open();
                cmd17.ExecuteNonQuery();

            }
            Response.Redirect(Request.RawUrl);
        }


        protected void addEducation_Click(object sender, EventArgs e)
        {
            label_addEducation_Description.Font.Size = 15;
            label_addEducation_Description.Font.Bold = true;

            label_addEducation_Description.Visible = true;

            label_addEducation_EDate.Font.Size = 15;
            label_addEducation_EDate.Font.Bold = true;

            label_addEducation_EDate.Visible = true;

            label_addEducation_Field.Font.Size = 15;
            label_addEducation_Field.Font.Bold = true;

            label_addEducation_Field.Visible = true;

            label_addEducation_school.Font.Size = 15;
            label_addEducation_school.Font.Bold = true;
            label_addEducation_school.Visible = true;

            label_addEducation_SDate.Font.Size = 15;
            label_addEducation_SDate.Font.Bold = true;

            label_addEducation_SDate.Visible = true;


            addEducation_Description.Visible = true;
            addEducationbtn.Visible = true;
            Calendar1.Visible = true;
            Calendar2.Visible = true;
            addEducation_EDate.Visible = true;
            addEducation_Field.Visible = true;
            addEducation_school.Visible = true;
            addEducation_SDate.Visible = true;
        }

        protected void addEducationbtn_Click(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);
            //            int user_id = 16;

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com3 = new SqlConnection(cs))
            {
                SqlCommand cmd13 = new SqlCommand("add_Education", com3);
                cmd13.CommandType = System.Data.CommandType.StoredProcedure;

                cmd13.Parameters.AddWithValue("@Userid", user_id);
                cmd13.Parameters.AddWithValue("@Edu_school", addEducation_school.Text);
                cmd13.Parameters.AddWithValue("@Edu_SDate", addEducation_SDate.Text);
                cmd13.Parameters.AddWithValue("@Edu_EDate", addEducation_EDate.Text);
                cmd13.Parameters.AddWithValue("@Edu_title", addEducation_Field.Text);
                cmd13.Parameters.AddWithValue("@Edu_description ", addEducation_Description.Text);


                com3.Open();
                cmd13.ExecuteNonQuery();

            }
            Response.Redirect(Request.RawUrl);
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            addEducation_SDate.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
            Calendar1.Visible = false;
        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            addEducation_EDate.Text = Calendar2.SelectedDate.ToString("MM/dd/yyyy");
            Calendar2.Visible = false;
        }



        protected void add_skill_Click(object sender, EventArgs e)
        {
            label_add_skill.Font.Size = 15;
            label_add_skill.Font.Bold = true;

            label_add_skill.Visible = true;
            add_skill_text.Visible = true;
            add_skillbtn.Visible = true;
        }

        protected void add_skillbtn_Click(object sender, EventArgs e)
        {
            string a = Session["ID"].ToString();
            int user_id = Int32.Parse(a);
            //            int user_id = 16;

            String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection com6 = new SqlConnection(cs))
            {
                SqlCommand cmd23 = new SqlCommand("add_Skill", com6);
                cmd23.CommandType = System.Data.CommandType.StoredProcedure;

                cmd23.Parameters.AddWithValue("@Userid", user_id);
                cmd23.Parameters.AddWithValue("@Skill_title", add_skill_text.Text);


                com6.Open();
                cmd23.ExecuteNonQuery();

            }
            Response.Redirect(Request.RawUrl);
        }

        protected void Edit_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("EditS.aspx");
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