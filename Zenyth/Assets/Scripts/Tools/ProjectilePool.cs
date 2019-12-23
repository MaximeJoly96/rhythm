using Zenyth.Models;
using UnityEngine;

namespace Zenyth.Tools
{
    public class ProjectilePool : ObjectPool<ProjectileBehaviour>
    {
        protected override void CleanUp(ProjectileBehaviour obj)
        {

        }

        protected override ProjectileBehaviour Instantiate()
        {
            ProjectileBehaviour beh = Object.Instantiate(Object.FindObjectOfType<ProjectilesPattern>().ProjectileBehaviour);
            return beh;
        }
    }
}

