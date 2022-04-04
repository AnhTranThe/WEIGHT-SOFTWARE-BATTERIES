using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    public class Program
    {
      //  public static HardDrive hd = new HardDrive();
        public static string hdd_serial;
        public static string disk_serial;
        public static string macAdd;
        public static string macAddresses = string.Empty;
        public static string sMacAddress = string.Empty;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
       public static void Main()
        {

            // GetMACAddress();
            // GetMacAddress();
          

            /*
             if ((sMacAddress == "503EAA15AF58") || (macAddresses == "E0D55E15EB45"))                
             {

             }
             else
             {
                 return;
             }
             
             */
             /*
             if (ValidHD() == true)
            {

            }
             else
            {
                return;
            }
            */
             
             if (Priorprocess() != null)
          {
                MessageBox.Show("Ứng dụng đang được chạy!");
               return;
            }
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_dangnhaphethong());
        }
        public static Process Priorprocess()
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) && (p.MainModule.FileName == curr.MainModule.FileName))
                {
                    return p;
                }
                
            }
            return null;
        }
        public static string GetSerialNumber(string partition)
        {
            return GetHDDSerial(GetModelFromPartition(partition));
        }
        public static bool ValidHD()
        {

            hdd_serial = GetSerialNumber(@"C:");//
            if (hdd_serial == "171406A00F04")//         Z6EEV0FM
             {                                      
                 return true;
             }
             else
             {
                 return false;
             }
             
        }

        public static void GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
         
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
         

        }
        public static string GetMacAddress()
        {

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
               
                if (nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet) continue;
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }

            }

            return macAddresses;



        }
       
    

        internal class Hardisk
        {
            public string DeviceID { get; set; }
            public string Model { get; set; }
            public string Type { get; set; }
            public string SerialNumber { get; set; }
        }
   
        public static string GetHDDSerial(string Model)
        {
            string HDDSerial = "";
            List<Hardisk> hdList = new List<Hardisk>();
            ManagementObjectSearcher search = new ManagementObjectSearcher("Select * From Win32_DiskDrive");
            foreach (var mHD in search.Get())
            {
                Hardisk HD = new Hardisk();
                HD.DeviceID = mHD["DeviceID"].ToString();
                HD.Model = mHD["Model"].ToString();
                HD.Type = mHD["InterfaceType"].ToString();
                if (HD.Type.ToUpper() != "USB")
                    HD.SerialNumber = mHD["SerialNumber"].ToString();
                hdList.Add(HD);
            }


            foreach (var hdd in hdList)
            {
                if (hdd.Model == Model)
                    HDDSerial = hdd.SerialNumber;
            }
            return HDDSerial;
        }
        public static string GetModelFromPartition(string partition)
        {
            string model = "";
            if (partition.Length != 2)
            {
                return "";
            }
            else
            {
                try
                {
                    using (var par = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_LogicalDisk.DeviceID='" +
                        partition + "'} WHERE ResultClass=Win32_DiskPartition"))
                    {
                        foreach (var p in par.Get())
                        {
                            using (var drive = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + p["DeviceID"]
                                + "'} WHERE ResultClass=Win32_DiskDrive"))
                            {
                                foreach (var _drive in drive.Get())
                                {
                                    model = (string)_drive["Model"];
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "<unknown>";
                }
            }
            return model;
        }

    
    }
  
}
