using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ConnectIN.DAL
{
    public class DAL_meaages
    {
        private static readonly string connString =
System.Configuration.ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public int countmessage(int U1,int U2)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
//            SqlCommand cmd;
            try
            {
                SqlCommand cmd8 = new SqlCommand("countMessages", con);
                cmd8.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd8.Parameters.AddWithValue("@userid1", U1);
                cmd8.Parameters.AddWithValue("@userid2", U2);

                SqlParameter outPutParameter7 = new SqlParameter();
                outPutParameter7.ParameterName = "@count";//outuput parameter of the count_no_of_messages...
                outPutParameter7.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter7.Direction = System.Data.ParameterDirection.Output;
                cmd8.Parameters.Add(outPutParameter7);
                //Execution
                cmd8.ExecuteNonQuery();

                string n5 = outPutParameter7.Value.ToString();
                int count_messages = Convert.ToInt32(n5);

                Found = count_messages;

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        public void sendmessage(string text,int U1, int U2)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //            SqlCommand cmd;
            try
            {

                SqlCommand cmd4 = new SqlCommand("enterMessage", con);
                cmd4.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd4.Parameters.AddWithValue("@text",text);
                cmd4.Parameters.AddWithValue("@userby", U1);
                cmd4.Parameters.AddWithValue("@userto", U2);
                //Execution
                cmd4.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
        }


        public int countconnection(int U1)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //            SqlCommand cmd;
            try
            {
                SqlCommand cmd9 = new SqlCommand("countConnection", con);
                cmd9.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd9.Parameters.AddWithValue("@userid", U1);

                SqlParameter outPutParameter6 = new SqlParameter();
                outPutParameter6.ParameterName = "@count";//outuput parameter of the count_no_of_s...
                outPutParameter6.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter6.Direction = System.Data.ParameterDirection.Output;
                cmd9.Parameters.Add(outPutParameter6);
                //Execution
                cmd9.ExecuteNonQuery();

                string n4 = outPutParameter6.Value.ToString();
                int count_connection = Convert.ToInt32(n4);

                Found = count_connection;

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        public int countprojects(int U1)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //            SqlCommand cmd;
            try
            {
                SqlCommand cmd2 = new SqlCommand("countProjects", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd2.Parameters.AddWithValue("@ID", U1);

                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@countfor";//outuput parameter of the count_no_of_Projects...
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd2.Parameters.Add(outPutParameter);
                //Execution
                cmd2.ExecuteNonQuery();
                string n = outPutParameter.Value.ToString();
                int count_projects = Convert.ToInt32(n);
                Found = count_projects;

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        public int countLanguages(int U1)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //            SqlCommand cmd;
            try
            {

                SqlCommand cmd6 = new SqlCommand("countLanguages", con);
                cmd6.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd6.Parameters.AddWithValue("@ID", U1);

                SqlParameter outPutParameter3 = new SqlParameter();
                outPutParameter3.ParameterName = "@countfor";//outuput parameter of the count_no_of_Projects...
                outPutParameter3.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter3.Direction = System.Data.ParameterDirection.Output;
                cmd6.Parameters.Add(outPutParameter3);
                //Execution
                cmd6.ExecuteNonQuery();

                string n1 = outPutParameter3.Value.ToString();
                int count_Language = Convert.ToInt32(n1);
                Found = count_Language;

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }

        public int countExperience(int U1)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //            SqlCommand cmd;
            try
            {
                SqlCommand cmd7 = new SqlCommand("countExperience", con);
                cmd7.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd7.Parameters.AddWithValue("@ID", U1);

                SqlParameter outPutParameter4 = new SqlParameter();
                outPutParameter4.ParameterName = "@countfor";//outuput parameter of the count_no_of_Experience...
                outPutParameter4.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter4.Direction = System.Data.ParameterDirection.Output;
                cmd7.Parameters.Add(outPutParameter4);
                //Execution
                cmd7.ExecuteNonQuery();

                string n2 = outPutParameter4.Value.ToString();
                int count_Experience = Convert.ToInt32(n2);


                Found = count_Experience;

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }

        public int countskills_(int U1)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //            SqlCommand cmd;
            try
            {
                SqlCommand cmd8 = new SqlCommand("countskills", con);
                cmd8.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd8.Parameters.AddWithValue("@ID", U1);

                SqlParameter outPutParameter5 = new SqlParameter();
                outPutParameter5.ParameterName = "@countfor";//outuput parameter of the count_no_of_s...
                outPutParameter5.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter5.Direction = System.Data.ParameterDirection.Output;
                cmd8.Parameters.Add(outPutParameter5);
                //Execution
                cmd8.ExecuteNonQuery();

                string n3 = outPutParameter5.Value.ToString();
                int count_skills = Convert.ToInt32(n3);

                Found = count_skills;

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }

        public int countEducation(int U1)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //            SqlCommand cmd;
            try
            {
                SqlCommand cmd9 = new SqlCommand("countEducation", con);
                cmd9.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd9.Parameters.AddWithValue("@ID", U1);

                SqlParameter outPutParameter6 = new SqlParameter();
                outPutParameter6.ParameterName = "@countfor";//outuput parameter of the count_no_of_s...
                outPutParameter6.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter6.Direction = System.Data.ParameterDirection.Output;
                cmd9.Parameters.Add(outPutParameter6);
                //Execution
                cmd9.ExecuteNonQuery();

                string n4 = outPutParameter6.Value.ToString();
                int count_Education = Convert.ToInt32(n4);

                Found = count_Education;

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }

        public int countHonors(int U1)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //            SqlCommand cmd;
            try
            {
                SqlCommand cmd10 = new SqlCommand("countHonors", con);
                cmd10.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd10.Parameters.AddWithValue("@ID", U1);

                SqlParameter outPutParameter7 = new SqlParameter();
                outPutParameter7.ParameterName = "@countfor";//outuput parameter of the count_no_of_s...
                outPutParameter7.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter7.Direction = System.Data.ParameterDirection.Output;
                cmd10.Parameters.Add(outPutParameter7);
                //Execution
                cmd10.ExecuteNonQuery();

                string n5 = outPutParameter7.Value.ToString();
                int count_Honors = Convert.ToInt32(n5);
                Found = count_Honors;

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }
    }
}