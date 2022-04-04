using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    class ketnoisql
    {
   
       // public static string str = Properties.Settings.Default.LELONG_databaseConnectionString;
       // public static string str = @"Data Source=E:\QATECH\PROJECT\2020\LE LONG PROJECT - SQL - datagridview\PROJECT_LELONG_MODBUS_VB_PROFACE_REV1\LELONG database.sdf";
       // public static string str = @"Data Source = LELONG database.sdf;Persist Security Info=False";
        
        
        //public static string str = @"Data Source=" + System.Windows.Forms.Application.StartupPath + @"\LELONG database.sdf;Persist Security Info=False";
        public static string str = @"Data Source=" + Application.StartupPath + @"\LELONG Database.db;Version=3;Compress=True;Journal Mode=Off;";
    }
}
