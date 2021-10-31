# SpotifyNowPlaying
Get currently played Spotify song name using C# console app / Get proces by name method
![previev](https://raw.githubusercontent.com/maciekkoks/SpotifyNowPlaying/main/previev.png)
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
            while (true)
            {
                var proc = Process.GetProcessesByName("Spotify").LastOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));
                if (proc == null)
                {
                    Console.WriteLine("Spotify is not running");
                }
                else
                {
                    Console.WriteLine(proc.MainWindowTitle);
                }
                Thread.Sleep(5000);
            }

        }

    }
}
```
