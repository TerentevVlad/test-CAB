using UnityEngine;

namespace Db
{
    public class DataStorageService
    {
        public static T GetData<T>(string key) where T : new()
        {
            var fromJson = JsonUtility.FromJson<T>(PlayerPrefs.GetString(key, JsonUtility.ToJson(new T())));
            return fromJson;
        }
        
        public static void SetData<T>(string key, T value)
        {
            var json = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }
        
    }
}