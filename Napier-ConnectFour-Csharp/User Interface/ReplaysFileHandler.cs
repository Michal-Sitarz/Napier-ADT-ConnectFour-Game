using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Napier_ConnectFour_Csharp
{
    public static class ReplaysFileHandler
    {

        public static void Load()
        {
            if (File.Exists("replays.json"))
            {
                try
                {
                    var json = File.ReadAllText("replays.json");
                    var replays = JsonSerializer.Deserialize<List<GameRecord>>(json);
                    if (replays != null)
                    {
                        Program.ReplaysList = replays;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured while trying to load the file with Replays from local drive.\nMore details: '{ex.Message}'");
                }
            }
        }

        public static void Save()
        { 
            try
            {
                var json = JsonSerializer.Serialize(Program.ReplaysList);
                File.WriteAllText("replays.json", json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while trying to save a file with Replays on local drive.\nMore details: '{ex.Message}'");
            }
        }
    }
}
