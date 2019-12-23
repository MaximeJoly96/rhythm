using System.Collections.Generic;
using Zenyth.Game;
using UnityEngine;

namespace Zenyth.Models
{
    public class ProjectilesPattern : MonoBehaviour
    {
        private readonly GameController _gameController;

        [SerializeField]
        private ProjectileBehaviour _projectileBehaviour;
        [SerializeField]
        private List<Projectile> _projectiles;

        public List<Projectile> Projectiles
        {
            get { return _projectiles; }
        }

        public ProjectileBehaviour ProjectileBehaviour { get { return _projectileBehaviour; } }
    }
}

