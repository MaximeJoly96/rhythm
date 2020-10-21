using UnityEngine;
using System.Collections;
using Zenyth.Models;

namespace Zenyth.Game
{
    public class PatternManager : MonoBehaviour
    {
        [SerializeField]
        private ProjectilesPattern[] _patterns;

        public ProjectilesPattern GetPattern(string name)
        {
            for(int i = 0; i < _patterns.Length; i++)
            {
                if (_patterns[i].name.Contains(name))
                    return _patterns[i];
            }

            return null;
        }

    }
}

