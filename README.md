# SpotifyNowPlaying
Get currently played Spotify song name by using C# console app / Get processes by name method
![preview](https://raw.githubusercontent.com/maciekkoks/SpotifyNowPlaying/main/app-preview.png)
```cs
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace SpotifyNowPlaying
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SpotifyNowPlaying Author: github.com/maciekkoks");
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
                else
                {
                    Console.WriteLine("[" + DateTime.Now.ToString("h:mm:ss") + "] " + proc.MainWindowTitle);
                }

                Thread.Sleep(1000);

            }
        }

    }
}
```
