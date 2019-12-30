namespace Zenyth.Models
{
    public class TimeStamp
    {
        private readonly float _time;
        private readonly string _pattern;

        public float Time { get { return _time; } }
        public string Pattern { get { return _pattern; } }

        public TimeStamp(float time, string pattern)
        {
            _time = time;
            _pattern = pattern;
        }
    }
}
