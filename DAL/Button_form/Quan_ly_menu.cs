using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL.Button_form
{
    public class Quan_ly_menu:Main_SQL
    {
        public Quan_ly_menu()
        {
            conn = new SqlConnection(chuoikn);
        }
        public DataTable load_menu()
        {
            dt = dboload("menu");
            return dt;
        }
        public DataTable dboloadDM(char MaDM)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from menu where madanhmuc = " + $"'DM0{MaDM}'";
            cmd.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            return dt;
        }

        public bool ThemMon(int id, string name, int gia, string maDanhMuc)
        {
            try
            {
                KetNoi();
                DataTable them = dboload("menu");
                DataRow dr = them.NewRow();
                dr["id"] = id;
                dr["ten"] = name;
                dr["gia"] = gia;
                dr["maDanhMuc"] = maDanhMuc;
                them.Rows.Add(dr);

                SqlCommandBuilder bd = new SqlCommandBuilder(adapter);
                adapter.Update(them);
                NgatKn();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                NgatKn();
            }
        }

        //SỬA MÓN TRONG MENU
        public bool SuaMenu(int id, string name, int gia, string maDanhMuc)
        {
            try
            {
                KetNoi();
                DataTable sua = dboload("menu");
                for (int i = 0; i < dt.Rows.Count; i++) //Lặp qua từng dòng dữ liệu trong dt
                {
                    if (dt.Rows[i][0].ToString() == id.ToString())
                    {
                        dt.Rows[i][1] = name;
                        dt.Rows[i][2] = gia;
                        dt.Rows[i][3] = maDanhMuc;
                    }
                }
                SqlCommandBuilder bd = new SqlCommandBuilder(adapter);
                adapter.Update(sua);
                NgatKn();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //

        // XÓA MÓN TRONG MENU
        public bool XoaMenu(string name_table, int id)
        {
            try
            {
                KetNoi();
                dt = new DataTable();
                cmd = new SqlCommand();
                cmd.CommandText = $"delete from {name_table} where id = {id}";
                cmd.Connection = conn;
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                NgatKn();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckIdExists(int id)
        {
            KetNoi();
            string query = $"SELECT COUNT(*) FROM menu WHERE id =  {id}"; 
            cmd = new SqlCommand(query, conn);
            int i = (int)cmd.ExecuteScalar();
            NgatKn();
            return i > 0;
        }

        public DataTable GetDanhMuc()
        {
            DataTable dt = dboload("danhmuc");
            DataRow newRow = dt.NewRow();
            newRow["madanhmuc"] = DBNull.Value;
            newRow["tendanhmuc"] = "Chọn danh mục";
            dt.Rows.InsertAt(newRow, 0);

            return dt;
        }
    }
}
