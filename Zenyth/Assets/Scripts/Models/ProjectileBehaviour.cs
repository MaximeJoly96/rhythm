using UnityEngine;
using System.Collections;
using Zenyth.Trajectories;
using Zenyth.Game;

namespace Zenyth.Models
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        public Projectile Projectile { get; set; }

        private void Start()
        {
            StartCoroutine(FollowTrajectory());
        }

        private IEnumerator FollowTrajectory()
        {
            foreach (Segment seg in Projectile.Trajectory.Segments)
            {
                for (int j = 0; j < seg.Positions.Length - 1; j++)
                {
                    int i = 0;
                    while (i <= 50)
                    {
                        transform.position = Vector2.Lerp(seg.Positions[j], seg.Positions[j + 1], i / 100.0f);
                        i++;
                        yield return new WaitForEndOfFrame();
                    }
                }
            }
        }
    }
}
