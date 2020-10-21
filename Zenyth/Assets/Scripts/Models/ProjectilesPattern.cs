using System.Collections.Generic;
using Zenyth.Game;
using UnityEngine;

namespace Zenyth.Models
{
    public class ProjectilesPattern : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                Destroy(this.gameObject);
        }
    }
}

