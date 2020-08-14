using UnityEngine;

namespace Pump.Core
{
    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        protected static T instance;
        private static object lockObject = new object();

        public static T Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = (T)FindObjectOfType(typeof(T));

                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            return instance;
                        }
                    }

                    return instance;
                }
            }
        }

        public void OnDestroy()
        {
            instance = null;
        }
    }
}
