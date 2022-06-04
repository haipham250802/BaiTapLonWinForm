using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace BTL
{
    internal class MainData
    {
        SqlDataAdapter SA;
        SqlCommand SC;

        public MainData() { }
        public DataTable HienThiTatCaSanPham()
        {
            DataTable DT = new DataTable();
            string sql = "select * from SanPham ";
            using (SqlConnection sqlConnection = Connection.Getconnect())
            {
                sqlConnection.Open();
                SA = new SqlDataAdapter(sql, sqlConnection);
                SA.Fill(DT);
                sqlConnection.Close();
            }
            return DT;
        }
        public DataTable HienThiGiaSanPham(string TSP)
        {
            DataTable DT = new DataTable();
            string sql = "select GiaSanPham,MaSanPham from SanPham where TenSanPham=N'" + TSP + "'";
                string a  =" a()";
            using (SqlConnection sqlConnection = Connection.Getconnect())
            {
                sqlConnection.Open();
                SA = new SqlDataAdapter(sql, sqlConnection);
                SA.Fill(DT);
                sqlConnection.Close();
            }
            return DT;


        }
        public bool ThemSanPham(SanPham sp)
        {
            SqlConnection sqlConnection = Connection.Getconnect();
            string sql = "insert into SanPham values(@MaSanPham,@TenSanPham,@GiaSanPham)";
            try
            {
                sqlConnection.Open();
                SC = new SqlCommand(sql, sqlConnection);
                SC.Parameters.Add("@MaSanPham", SqlDbType.VarChar).Value = sp.MaSanPham;
                SC.Parameters.Add("@TenSanPham", SqlDbType.NVarChar).Value = sp.TenSanPham;
                SC.Parameters.Add("@GiaSanPham", SqlDbType.Float).Value = sp.GiaSanPham;
                SC.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool SuaSanPham (SanPham sp)
        {
            SqlConnection sqlConnection = Connection.Getconnect();
            string sql = "Update SanPham set TenSanPham = @TenSanPham , MaSanPham = @MaSanPham , GiaSanPham = @GiaSanPham where MaSanPham = @MaSanPham";
            try
            {
                sqlConnection.Open();
                SC = new SqlCommand(sql, sqlConnection);
                SC.Parameters.Add("@MaSanPham", SqlDbType.VarChar).Value = sp.MaSanPham;
                SC.Parameters.Add("@TenSanPham", SqlDbType.NVarChar).Value = sp.TenSanPham;
                SC.Parameters.Add("GiaSanPham", SqlDbType.Float).Value = sp.GiaSanPham;
                SC.ExecuteNonQuery();
            }catch(Exception e)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool XoaSanPham(string masp)
        {
            SqlConnection sqlConnection = Connection.Getconnect();
            string sql = "delete from SanPham where MaSanPham = @MaSanPham";
            try
            {
                sqlConnection.Open();
                SC = new SqlCommand(sql, sqlConnection);
                SC.Parameters.Add("@MaSanPham", SqlDbType.VarChar).Value = masp;
                SC.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }    
    }
}

