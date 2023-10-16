using System;
using Db;

namespace Game
{
    [Serializable]
    public class ScoreData
    {
        public float Record;

        public ScoreData()
        {
            Record = 0;
        }
    }
    public class ScoreController
    {
        public event Action<float> OnChangeValue;

        private DBAdapterCachedWithKey<ScoreData> _dbAdapter;

        public ScoreController()
        {
            _dbAdapter = new DBAdapterCachedWithKey<ScoreData>("PlayerScore");
        }

        private float _currentValue;

        public float GetValue() => _currentValue;

        public float GetRecordValue() => _dbAdapter.Get().Record;

        public void Reset()
        {
            SetValue(0);
        }

        public void AddScore(float value)
        {
            SetValue(_currentValue + value);
        }
        private void SetValue(float value)
        {
            _dbAdapter.ChangeValue(v =>
            {
                if (value > v.Record)
                    v.Record = value;
            });
            _currentValue = value;
            
            
            OnChangeValue?.Invoke(value);
        }
    }
}