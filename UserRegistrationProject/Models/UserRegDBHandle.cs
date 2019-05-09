using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace UserRegistrationProject.Models
{
    public class UserRegDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["UserRegConnection"].ConnectionString;
            
            con = new SqlConnection(constring);
        }


        // **************** ADD NEW User *********************
        public bool AddNewUser(UserDetail smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@Email", smodel.Email);
            cmd.Parameters.AddWithValue("@SecurePassword", smodel.SecurePassword);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<UserDetail> GetUserList()
        {
            connection();
            List<UserDetail> userList = new List<UserDetail>();

            SqlCommand cmd = new SqlCommand("GetUserList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                userList.Add(
                    new UserDetail
                    {
                        
                        Name = Convert.ToString(dr["Name"]),
                        Email = Convert.ToString(dr["Email"]),
   
                    });
            }
            return userList;
        }

    }
}