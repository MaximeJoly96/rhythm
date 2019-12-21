using System.Collections.Generic;

namespace Zenyth.Tools
{
    public abstract class ObjectPool<T>
    {
        private readonly List<T> _available = new List<T>();
        private readonly List<T> _inUse = new List<T>();

        public T GetObject()
        {
            lock (_available)
            {
                if (_available.Count != 0)
                {
                    T obj = _available[0];
                    _inUse.Add(obj);
                    _available.RemoveAt(0);
                    return obj;
                }
                else
                {
                    T obj = Instantiate();
                    _inUse.Add(obj);
                    return obj;
                }
            }
        }

        public void ReleaseObject(T obj)
        {
            CleanUp(obj);

            lock (_available)
            {
                _available.Add(obj);
                _inUse.Remove(obj);
            }
        }

        protected abstract void CleanUp(T obj);

        protected abstract T Instantiate();
    }
}

