# SpotifyNowPlaying
Get currently played Spotify song name by using C# console app / Get processes by name method
![preview](https://raw.githubusercontent.com/maciekkoks/SpotifyNowPlaying/main/app-preview.png)
# Ads skipping
![memory](https://raw.githubusercontent.com/maciekkoks/SpotifyBlockAds/main/ads-skip.png)
# Memory Usage
![memory](https://raw.githubusercontent.com/maciekkoks/SpotifyBlockAds/main/memory-usage.png)

# Main C# Code
```cs
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;

namespace SpotifyNowPlaying
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);
        static void Main(string[] args)
        {
            Console.Title = "Spotify Ads skip Author: github.com/maciekkoks" ;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Spotify Ads Skip + Now Playing Author: github.com/maciekkoks");
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
                    Thread.Sleep(5000);

                }
                if (proc != null)
                {
                    Console.WriteLine("[" + DateTime.Now.ToString("h:mm:ss") + "] " + proc.MainWindowTitle);
                    Console.Title = "Spotify Ads Skip + Now Playing - " + proc.MainWindowTitle;
                }
                if (proc.MainWindowTitle == "Advertisement") //ads skip
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
                }
                Thread.Sleep(1000);
            
            }
        }

    }
}
```
