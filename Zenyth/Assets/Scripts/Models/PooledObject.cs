using UnityEngine;
using System;

namespace Zenyth.Models
{
    public abstract class PooledObject : MonoBehaviour
    {
        private readonly DateTime _createdAt = DateTime.Now;

        public DateTime CreatedAt
        {
            get { return _createdAt; }
        }

        public abstract void CleanUp();
    }
}
