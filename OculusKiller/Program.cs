using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OculusKiller
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                string steamVrId = "250820";
                RegistryKey steamVrKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App " + steamVrId);

                if (steamVrKey != null)
                {
                    string installLocation = steamVrKey.GetValue("InstallLocation").ToString();
                    string vrStartupPath = Path.Combine(installLocation, @"bin\win64\vrstartup.exe");

                    if (File.Exists(vrStartupPath))
                    {
                        Process vrStartupProcess = Process.Start(vrStartupPath);
                        vrStartupProcess.WaitForExit();
                    }
                    else Process.Start("steam://run/" + steamVrId);
                }
                else Process.Start("steam://run/" + steamVrId);
            }
            catch (Exception e)
            {
                MessageBox.Show($"An exception occured while attempting to find and launch SteamVR!\n\nMessage: {e}");
            }
        }
    }
}
