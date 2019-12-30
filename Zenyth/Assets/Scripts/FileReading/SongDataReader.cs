using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Globalization;
using Zenyth.Models;

namespace Zenyth.FileReading
{
    public static class SongDataReader
    {
        public static List<TimeStamp> ReadTimeStampsForSong(Song song)
        {
            string[] lines = File.ReadAllLines(Application.streamingAssetsPath + "/SongData/" + song.Key + ".songdata");
            List<TimeStamp> timeStamps = new List<TimeStamp>();

            foreach (string line in lines)
            {
                string[] tempLine = line.Split(' ');
                timeStamps.Add(new TimeStamp(float.Parse(tempLine[0], CultureInfo.InvariantCulture), tempLine[1]));
            }

            return timeStamps;
        }
    }
}
