using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO_DA;
namespace DAL
{
    public abstract class Main_SQL
    {
        protected string chuoikn = @"Data Source=KURUMI\KURUMI;Initial Catalog=Quan_ly_Quan_nuoc;Persist Security Info=True;User ID=sa;Password=Tokisakikurumi1@";
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataAdapter adapter;
        protected DataTable dt;
        public Main_SQL()
        {
            conn = new SqlConnection(chuoikn);
        }
        DTO dto = new DTO();

        //
        protected void KetNoi()
        {
            conn = new SqlConnection(chuoikn); // Thay bằng chuỗi kết nối của bạn
            conn.Open();
        }

        protected void NgatKn()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
        //
        //LOAD DATAGIRD VIEW
        public DataTable dboload(string query)
        {
            dt = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandText = "select * from " + query;
            cmd.Connection = conn;
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            return dt;
        }
        //SEARCH
        public DataTable dboSearch(string name)
        {
            dt = new DataTable();
            string query = $"SELECT * FROM menu WHERE dish_name LIKE N'%{name}%'";
            cmd = new SqlCommand(query, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
