using System;

namespace Common.Utility
{
    [Serializable]
    public struct Optional<T>
    {
        public bool enabled;
        public T value;
    }
}
