using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Globalization;

public static class SongDataReader
{
    public static List<float> ReadTimeStampsForSong(Song song)
    {
        string[] lines = File.ReadAllLines(Application.streamingAssetsPath + "/SongData/" + song.Key + ".songdata");
        List<float> timeStamps = new List<float>();

        foreach(string line in lines)
        {
            timeStamps.Add(float.Parse(line, CultureInfo.InvariantCulture));
        }

        return timeStamps;
    }
}
