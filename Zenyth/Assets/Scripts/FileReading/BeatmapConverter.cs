using System.IO;

namespace Zenyth.FileReading
{
    public static class BeatmapConverter
    {
        public static void ConvertBeatmap(string path)
        {
            string[] lines = File.ReadAllLines(path);

            int i = 0;
            while (i < lines.Length && lines[i] != "[HitObjects]")
            {
                i++;
            }

            // here we start reading
            i++;

            using (StreamWriter sr = new StreamWriter("C:\\Users\\Maxah\\song.songdata"))
            {
                while (i < lines.Length)
                {
                    string[] line = lines[i].Split(',');
                    sr.WriteLine(line[2].Insert(line[2].Length - 3, "."));
                    i++;
                }
            }
        }
    }
}
