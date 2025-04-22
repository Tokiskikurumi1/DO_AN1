using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class Login: Main_SQL
    {
        public Login() { }
        public int kiem_tra(string username, string password)
        {
            try
            {
                KetNoi();
                string query = "SELECT role_ID FROM UserDN WHERE nameuser = @username AND pass = @password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    // Thực thi câu lệnh và kiểm tra xem có kết quả trả về hay không.
                    var result = cmd.ExecuteScalar();
                    if(result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
