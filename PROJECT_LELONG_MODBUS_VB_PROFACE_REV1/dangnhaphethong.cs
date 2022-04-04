using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    class dangnhaphethong
    {
        public bool loginhethong(string tendangnhap, string matkhau)
        {

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT tendangnhap,matkhau FROM quanlynguoidung WHERE tendangnhap='" + tendangnhap + "' AND matkhau='" + matkhau + "' ";
            SQLiteDataReader rd;
            rd = cmd.ExecuteReader();
            
           
            if (rd.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;

            }
          
        }
    }
}
