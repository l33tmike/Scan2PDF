using System;
using System.IO;
using Microsoft.Win32;

namespace Scan2PDF
{
    public static class Settings
    {
        private const string REG_LOC = @"SOFTWARE\Scan2PDF";
        private const string JPEG_COMPRESSION_KEY_NAME = "JpegCompression";
        private const uint DEFAULT_JPEG_COMPRESSION = 95;
        private const string PDF_SAVE_LOC_KEY_NAME = "SaveLoc";
        private const string DEFAULT_PDF_SAVE_LOC = @"\\marge\data";

        public static uint JpegCompression
        {
            get
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(REG_LOC);
                if (regKey == null)
                {
                    Console.WriteLine("No registry key found for JPEG Compression - return default of " + DEFAULT_JPEG_COMPRESSION);
                    return DEFAULT_JPEG_COMPRESSION;
                }
                
                try
                {
                    uint val = uint.Parse(regKey.GetValue(JPEG_COMPRESSION_KEY_NAME).ToString());
                    Console.WriteLine(String.Format("Read JPEG Compression value of {0} from registry", val));
                    regKey.Close();
                    if (val > 100)
                    {
                        Console.WriteLine("Unfortunately, the value read is greater than 100 and therefore illegal. Returning default value of " + DEFAULT_JPEG_COMPRESSION);
                        return DEFAULT_JPEG_COMPRESSION;
                    }
                    return val;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception thrown when attempting to read JPEG compression value: " + ex + 
                                        "\r\n\r\n Returning default value of " + DEFAULT_JPEG_COMPRESSION);
                    regKey.Close();
                    return DEFAULT_JPEG_COMPRESSION;
                }
            }
            set
            {
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey(REG_LOC); // Open or create the subkey
                if (regKey == null)
                {
                    Console.WriteLine("Failed to write new value to registry!");
                    return;
                }
                regKey.SetValue(JPEG_COMPRESSION_KEY_NAME, value);
                regKey.Close();
            }
        }

        public static string SaveLocation
        {
            get
            {

                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(REG_LOC);
                if (regKey == null)
                {
                    Console.WriteLine("No registry key found for PDF save location - return default of " + DEFAULT_PDF_SAVE_LOC);
                    return DEFAULT_PDF_SAVE_LOC;
                }

                try
                {
                    string val = regKey.GetValue(PDF_SAVE_LOC_KEY_NAME).ToString();
                    Console.WriteLine(String.Format("Read PDF save location of {0} from registry", val));
                    regKey.Close();
                    if (Directory.Exists(val) == false)
                    {
                        Console.WriteLine("Unfortunately that directory doesn't exist! Returning default value of " + DEFAULT_PDF_SAVE_LOC);
                        return DEFAULT_PDF_SAVE_LOC;
                    }
                    return val;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception thrown when attempting to read PDF svae location: " + ex +
                                        "\r\n\r\n Returning default value of " + DEFAULT_PDF_SAVE_LOC);
                    regKey.Close();
                    return DEFAULT_PDF_SAVE_LOC;
                }
            }
            set
            {
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey(REG_LOC);
                if (regKey == null)
                {
                    Console.WriteLine("Failed to write new value to registry!");
                    return;
                }
                regKey.SetValue(PDF_SAVE_LOC_KEY_NAME, value);
                regKey.Close();
            }
        }
    }
}
