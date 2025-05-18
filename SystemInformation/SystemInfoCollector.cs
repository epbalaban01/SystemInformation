using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SystemInformation
{
    public class SystemInfoCollector
    {
        public static async Task<SystemInfo> GetSystemInfoAsync()
        {
            return await Task.Run(() =>
            {
                var info = new SystemInfo();

                // Buraya senin mevcut sistem bilgisi toplama kodun gelecek
                info.ComputerName = Environment.MachineName;
                info.UserName = Environment.UserName;
                info.OSName = GetOSName();
                info.OSVersion = Environment.OSVersion.VersionString;
                info.InstallDate = GetInstallDate();
                info.CPU = GetCPU();
                info.RAM = GetRAM();

                info.GPUs = GetGPUs();
                info.Disks = GetDisks();

              

                info.MAC_Ethernet = GetMAC("Ethernet");
                info.MAC_WiFi = GetMAC("Wi-Fi");

                info.BIOSMode = GetBIOSMode();
                info.SecureBoot = GetSecureBootState();
                info.TPMVersion = GetTPMVersion();

                info.Manufacturer = GetManufacturer();
                info.Model = GetModel();
                info.SerialNumber = GetSerialNumber();
                info.PCType = GetPCType();
                info.DomainOrLocal = GetDomainOrLocal();

              


                return info;
            });
        }

        // Yeni methodlar:
        private static string GetManufacturer()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT Manufacturer FROM Win32_ComputerSystem"))
                {
                    foreach (var obj in searcher.Get())
                        return obj["Manufacturer"]?.ToString().Trim() ?? "Bilinmiyor";
                }
            }
            catch { }
            return "Bilinmiyor";
        }

        private static string GetModel()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT Model FROM Win32_ComputerSystem"))
                {
                    foreach (var obj in searcher.Get())
                        return obj["Model"]?.ToString().Trim() ?? "Bilinmiyor";
                }
            }
            catch { }
            return "Bilinmiyor";
        }

        private static string GetSerialNumber()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS"))
                {
                    foreach (var obj in searcher.Get())
                        return obj["SerialNumber"]?.ToString().Trim() ?? "Bilinmiyor";
                }
            }
            catch { }
            return "Bilinmiyor";
        }

        private static string GetPCType()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT PCSystemType FROM Win32_ComputerSystem"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        if (obj["PCSystemType"] != null)
                        {
                            int type = Convert.ToInt32(obj["PCSystemType"]);
                            switch (type)
                            {
                                case 1: return "Desktop";
                                case 2: return "Laptop";
                                case 3: return "Workstation";
                                case 4: return "Enterprise Server";
                                case 5: return "SOHO Server";
                                case 6: return "Appliance PC";
                                case 7: return "Performance Server";
                                default: return "Bilinmiyor";
                            }
                        }
                    }
                }
            }
            catch { }
            return "Bilinmiyor";
        }

        private static string GetDomainOrLocal()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT DomainRole FROM Win32_ComputerSystem"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        if (obj["DomainRole"] != null)
                        {
                            int role = Convert.ToInt32(obj["DomainRole"]);
                            // 0 = Standalone Workstation, 1 = Member Workstation, 2 = Standalone Server, 3 = Member Server, 4 = Backup Domain Controller, 5 = Primary Domain Controller
                            if (role == 0 || role == 2)
                                return "Local";
                            else
                                return "Domain";
                        }
                    }
                }
            }
            catch { }
            return "Bilinmiyor";
        }


        private static string GetOSName()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        return obj["Caption"]?.ToString().Trim();
                    }
                }
            }
            catch { }
            return Environment.OSVersion.ToString();
        }


        private static string GetInstallDate()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT InstallDate FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string raw = obj["InstallDate"]?.ToString();
                        if (!string.IsNullOrEmpty(raw))
                        {
                            var date = ManagementDateTimeConverter.ToDateTime(raw);
                            return date.ToString("dd.MM.yyyy HH:mm");
                        }
                    }
                }
            }
            catch { }
            return "Bilinmiyor";
        }


        private static string GetCPU()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("select Name from Win32_Processor"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        return obj["Name"]?.ToString().Trim();
                    }
                }
            }
            catch { }
            return "Bilinmiyor";
        }


        private static string GetRAM()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory"))
                {
                    long total = 0;
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        if (obj["Capacity"] != null)
                            total += Convert.ToInt64(obj["Capacity"]);
                    }
                    return $"{(total / (1024 * 1024 * 1024))} GB";
                }
            }
            catch { }
            return "Bilinmiyor";
        }


        private static List<string> GetGPUs()
        {
            var gpus = new List<string>();
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_VideoController"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        var name = obj["Name"]?.ToString();
                        if (!string.IsNullOrEmpty(name))
                            gpus.Add(name);
                    }
                }
            }
            catch { }
            return gpus;
        }


        private static List<string> GetDisks()
        {
            var disks = new List<string>();
            var diskDict = new Dictionary<string, string>();

            // MSFT_PhysicalDisk kullanarak disk tipi al (daha güvenilir)
            try
            {
                var scope = new ManagementScope(@"\\.\ROOT\Microsoft\Windows\Storage");
                scope.Connect();

                var searcherPhysical = new ManagementObjectSearcher(scope, new ObjectQuery("SELECT FriendlyName, MediaType FROM MSFT_PhysicalDisk"));

                foreach (ManagementObject obj in searcherPhysical.Get())
                {
                    string name = obj["FriendlyName"]?.ToString() ?? "Unknown";
                    string mediaType = "Bilinmiyor";

                    if (obj["MediaType"] != null)
                    {
                        switch (Convert.ToInt16(obj["MediaType"]))
                        {
                            case 3:
                                mediaType = "HDD";
                                break;
                            case 4:
                                mediaType = "SSD";
                                break;
                            default:
                                mediaType = "Bilinmiyor";
                                break;
                        }
                    }

                    diskDict[name] = mediaType;
                }
            }
            catch
            {
                // Storage namespace erişilemezse diskDict boş kalır, fallback olur.
            }

            // Win32_DiskDrive ile disk modeli ve boyut al
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT Model, Size FROM Win32_DiskDrive"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string model = obj["Model"]?.ToString() ?? "Disk";
                        long size = obj["Size"] != null ? Convert.ToInt64(obj["Size"]) : 0;
                        double gb = size / (1000 * 1000 * 1000);

                        // MSFT_PhysicalDisk'ten eşleşen model varsa kullan
                        string diskType = "Bilinmiyor";
                        foreach (var entry in diskDict)
                        {
                            if (model.IndexOf(entry.Key, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                diskType = entry.Value;
                                break;
                            }
                        }

                        disks.Add($"{model} > {Math.Round(gb)} GB > ({diskType})");
                    }
                }
            }
            catch
            {
                // Hata yakalama isteğe bağlı
            }

            return disks;
        }



        private static string GetMAC(string interfaceType)
        {
            try
            {
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.NetworkInterfaceType.ToString().ToLower().Contains(interfaceType.ToLower()) &&
                        ni.OperationalStatus == OperationalStatus.Up)
                    {
                        return string.Join(":", ni.GetPhysicalAddress().GetAddressBytes().Select(b => b.ToString("X2")));
                    }
                }
            }
            catch { }
            return "Bilinmiyor";
        }


        private static string GetBIOSMode()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control"))
                {
                    if (key?.GetValue("PEFirmwareType") is int val)
                    {
                        return val == 1 ? "BIOS (Legacy)" : val == 2 ? "UEFI" : "Bilinmiyor";
                    }
                }
            }
            catch { }
            return "Bilinmiyor";
        }


        private static string GetSecureBootState()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\SecureBoot\State"))
                {
                    if (key?.GetValue("UEFISecureBootEnabled") is int enabled)
                        return enabled == 1 ? "Etkin" : "Devre Dışı";
                }
            }
            catch { }
            return "Bilinmiyor";
        }


        private static string GetTPMVersion()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher(@"root\CIMV2\Security\MicrosoftTpm", "SELECT SpecVersion FROM Win32_Tpm"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        return obj["SpecVersion"]?.ToString() ?? "Yok";
                    }
                }
            }
            catch { }
            return "Yok";
        }



    }
}
