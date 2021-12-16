using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace SpotifyNowPlaying
{
    class Program
    {
        [DllImport("user32.dll")]

        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);
        public static int a = 0;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Spotify AdBlocker + Now Playing");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Author: github.com/maciekkoks");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                var proc = Process.GetProcessesByName("Spotify").LastOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));
                if (proc == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Spotify is not running");
                    System.Diagnostics.Process.Start("Spotify.exe");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    continue;                     
                }
                if (proc.MainWindowTitle == "Advertisement" || proc.MainWindowTitle == "Spotify")
                {
                    foreach (var process in Process.GetProcessesByName("Spotify"))
                    {
                        process.Kill();
                    }
                    System.Diagnostics.Process.Start("Spotify.exe");
                    Thread.Sleep(2000);
                    keybd_event(0xB3, 0, 1, IntPtr.Zero);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Advertisement skipped");
                    a++;
                    Console.ResetColor();
                    while (proc.MainWindowTitle == "Spotify"){Thread.Sleep(1000);}
                }
                if (proc != null)
                {
                    if (proc.MainWindowTitle != "Spotify Free")
                    {
                        Console.Title = " Spotify AdBlocker - " + "Advertisements skipped: " + a + "                     " + proc.MainWindowTitle;
                        Console.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "]  " + proc.MainWindowTitle);
                    }
                    else
                    {
                        Console.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "]  " + "Spotify (Paused)");
                        Console.Title = " Spotify AdBlocker - " + "Advertisements skipped: " + a + "                     " + "Spotify (Paused)";
                    }
                    Thread.Sleep(1000);
                }
            }
        }
    }
}