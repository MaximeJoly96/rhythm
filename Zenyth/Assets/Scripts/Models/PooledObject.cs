using System;

namespace Zenyth.Models
{
    public abstract class PooledObject
    {
        private readonly DateTime _createdAt = DateTime.Now;

        public DateTime CreatedAt
        {
            get { return _createdAt; }
        }

        public abstract void CleanUp();
    }
}
