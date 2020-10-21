using UnityEngine;
using System.Collections;

namespace Zenyth.Game
{
    public class SyncedAnimation : MonoBehaviour
    {
        //The animator controller attached to this GameObjec
        [SerializeField]
        private Animator _animator;

        //Records the animation state or animation that the Animator is currently in
        [SerializeField]
        private AnimatorStateInfo _animatorStateInfo;

        //Used to address the current state within the Animator using the Play() function
        [SerializeField]
        private int _currentState;

        private void Start()
        {
            //Load the animator attached to this object
            _animator = GetComponent<Animator>();

            //Get the info about the current animator state
            _animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);

            //Convert the current state name to an integer hash for identification
            _currentState = _animatorStateInfo.fullPathHash;
        }

        private void Update()
        {
            //Start playing the current animation from wherever the current conductor loop is
            _animator.Play("BackAndForth", -1, (Conductor.instance.LoopPositionInAnalog));
        }
    }
}
