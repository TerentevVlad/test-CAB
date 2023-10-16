namespace Db
{
    public class DBAdapterCached<T> where T : new()
    {
        private T _data;
        public DBAdapterCached()
        {
          
        }
        
        public T Get(string key)
        {
            if (_data == null)
            {
                return DataStorageService.GetData<T>(key);
            }

            return _data;
        }

        public void Set(string key, T value)
        {
            DataStorageService.SetData(key, value);
            _data = value;
        }
    }
}