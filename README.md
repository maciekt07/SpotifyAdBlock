# SpotifyNowPlaying
Get currently played Spotify song name by using C# console app / Get processes by name method
![previev](https://raw.githubusercontent.com/maciekkoks/SpotifyNowPlaying/main/previev1.png)
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
            Console.WriteLine("enter the delay in ms: ");
            int delay = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                var proc = Process.GetProcessesByName("Spotify").LastOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));
                if (proc == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Spotify is not running");
                }
                if (proc != null)
                {
                    Console.WriteLine(proc.MainWindowTitle);
                }
                Thread.Sleep(delay);
               
            }
        }

    }
}
```
