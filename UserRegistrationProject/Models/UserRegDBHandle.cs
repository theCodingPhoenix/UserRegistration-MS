using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace UserRegistrationProject.Models
{
    public class UserRegDBHandle
    {
        private SqlConnection sqlCon;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["UserRegConnection"].ConnectionString;

            sqlCon = new SqlConnection(constring);
        }


        // **************** ADD NEW User *********************
        public bool AddNewUser(UserDetail smodel)
        {
            connection();
            SqlCommand sqlQuery = new SqlCommand("AddNewUser", sqlCon);
            sqlQuery.CommandType = CommandType.StoredProcedure;

            sqlQuery.Parameters.AddWithValue("@Name", smodel.Name);
            sqlQuery.Parameters.AddWithValue("@Email", smodel.Email);

            // create salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // create hash
            var pbkdf2 = new Rfc2898DeriveBytes(smodel.SecurePassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // combine the salt and hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // convert to base64
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            sqlQuery.Parameters.AddWithValue("@SecurePassword", savedPasswordHash);

            // open the db connection
            sqlCon.Open();

            // execute the query
            int i = sqlQuery.ExecuteNonQuery();

            

            // close the db connection
            sqlCon.Close();

            // if data has been inserted, return true else return false
            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}