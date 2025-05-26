using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL.Button_form
{
    public interface IQuanLyMenuDal
    {
        DataTable dboloadDM(char maDM);
        DataTable load_menu();
        bool ThemMon(int id, string name, int gia, string maDanhMuc);
        bool SuaMenu(int id, string name, int gia, string maDanhMuc);
        bool XoaMenu(int id);
        bool CheckIdExists(int id);
        DataTable GetDanhMuc();
        DataTable dboSearch(string name);
        DataTable searchs_tt(string name);
    }

    public class Quan_ly_menu:Main_SQL, IQuanLyMenuDal
    {

        public Quan_ly_menu()
        {
            conn = new SqlConnection(@"Data Source=KURUMI\KURUMI;Initial Catalog=Quan_ly_Quan_nuoc;Persist Security Info=True;User ID=sa;Password=Tokisakikurumi1@");
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
            cmd.CommandText = "select * from menu where list_ID = " + $"'DM0{MaDM}'";
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
                dr["ID_dish"] = id;
                dr["dish_name"] = name;
                dr["price"] = gia;
                dr["list_ID"] = maDanhMuc;
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
        public bool XoaMenu(int id)
        {
            try
            {
                KetNoi();
                dt = new DataTable();
                cmd = new SqlCommand();
                cmd.CommandText = $"delete from menu where ID_dish = {id}";
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
            string query = $"SELECT COUNT(*) FROM menu WHERE ID_dish =  {id}"; 
            cmd = new SqlCommand(query, conn);
            int i = (int)cmd.ExecuteScalar();
            NgatKn();
            return i > 0;
        }

        public DataTable GetDanhMuc()
        {
            DataTable dt = dboload("list_dish");
            DataRow newRow = dt.NewRow();
            newRow["list_ID"] = DBNull.Value;
            newRow["list_name"] = "Chọn danh mục";
            dt.Rows.InsertAt(newRow, 0);

            return dt;
        }

        public DataTable searchs_tt(string name)
        {
            return dboSearch(name);
        }
    }
}
