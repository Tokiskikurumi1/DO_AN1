using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
namespace DAL.Button_form
{
    public class Quan_ly_nhan_vien: Main_SQL
    {
        public Quan_ly_nhan_vien()
        {

        }
        public DataTable load_NV()
        {
            return dboload("UserDN");
        }

        public DataTable lay_Roles()
        {
            DataTable dt = dboload("Roles");
            DataRow newRow = dt.NewRow();
            newRow["role_ID"] = DBNull.Value;
            newRow["role_name"] = "Chọn chức vụ";
            dt.Rows.InsertAt(newRow, 0);

            return dt;
        }

        public bool add_NV(int id, string ten, DateTime ngaysinh, string so_dt, string ca_lam, string tai_khoan, string mat_khau, string chuc_vu)
        {
            try
            {
                KetNoi();
                dt = dboload("UserDN");
                DataRow dr = dt.NewRow();
                dr["ID_user"] = id;
                dr["full_name"] = ten;
                dr["date_of_birth"] = ngaysinh;
                dr["phone_number"] = so_dt;
                dr["shifts"] = ca_lam;
                dr["nameuser"] = tai_khoan;
                dr["pass"] = mat_khau;
                dr["role_ID"] = chuc_vu;
                dt.Rows.Add(dr);

                SqlCommandBuilder bd = new SqlCommandBuilder(adapter);
                adapter.Update(dt);
                NgatKn();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                NgatKn();
            }
        }

        public bool Sua_nv(int id, string ten, DateTime ngaysinh, string so_dt, string ca_lam, string tai_khoan, string mat_khau, string chuc_vu)
        {
            try
            {
                KetNoi();
                DataTable sua = dboload("UserDN");
                for (int i = 0; i < dt.Rows.Count; i++) //Lặp qua từng dòng dữ liệu trong dt
                {
                    if (dt.Rows[i][0].ToString() == id.ToString())
                    {
                        dt.Rows[i][1] = ten;
                        dt.Rows[i][2] = ngaysinh;
                        dt.Rows[i][3] = so_dt;
                        dt.Rows[i][4] = ca_lam;
                        dt.Rows[i][5] = tai_khoan;
                        dt.Rows[i][6] = mat_khau;
                        dt.Rows[i][7] = chuc_vu;
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
        
        public bool Xoa_NV(int id)
        {
            try
            {
                KetNoi();
                dt = new DataTable();
                cmd = new SqlCommand();
                cmd.CommandText = $"delete from UserDN where ID_user = {id}";
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
        //TÌM KIẾM
        public DataTable Tim_kiem(string name)
        {
            dt = new DataTable();
            string query = $"SELECT * FROM UserDN WHERE full_name LIKE N'%{name}%'";
            cmd = new SqlCommand(query, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public virtual bool kiemtra_ID(int id)
        {
            KetNoi();
            string query = $"SELECT COUNT(*) FROM UserDN WHERE ID_user =  {id}"; // Giả sử cột là "id"
            cmd = new SqlCommand(query, conn);
            int i = (int)cmd.ExecuteScalar();
            NgatKn();
            return i > 0;
        }
    }
}
