using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemInformation
{
    public class SystemInfo
    {
        public string ComputerName { get; set; }
        public string UserName { get; set; }
        public string OSName { get; set; }
        public string OSVersion { get; set; }
        public string InstallDate { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public List<string> GPUs { get; set; } = new List<string>();
        public List<string> Disks { get; set; } = new List<string>();
        public string MAC_Ethernet { get; set; }
        public string MAC_WiFi { get; set; }
        public string BIOSMode { get; set; }
        public string SecureBoot { get; set; }
        public string TPMVersion { get; set; }

        // Yeni Özellikler
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string PCType { get; set; } // Laptop / Desktop
        public string DomainOrLocal { get; set; }
        public List<string> DiskTypes { get; set; } // Yeni eklendi 
    }
}
