using System;

namespace Db
{
    public class DBAdapterCachedWithKey<T> : DBAdapterCached<T> where T : new()
    {
        private readonly string _key;

        public DBAdapterCachedWithKey(string key) : base()
        {
            _key = key;
        }
        
        public T Get()
        {
            return Get(_key);
        }

        public void Set(T value)
        {
            Set(_key, value);
        }

        public void ChangeValue(Action<T> changer)
        {
            var data = Get();
            changer?.Invoke(data);
            Set(data);
        }
    }
}