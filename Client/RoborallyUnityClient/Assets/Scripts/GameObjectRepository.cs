using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    using System.Runtime.CompilerServices;

    using UnityEngine;

    public static class GameObjectRepository
    {
        private static Dictionary<GameObject, object> repository = new Dictionary<GameObject, object>();

        public static void Register(GameObject key, object value)
        {
            repository.Add(key, value);
        }

        public static void Remove(GameObject key)
        {
            repository.Remove(key);
        }

        public static T Get<T>(GameObject key) where T : class
        {
            var result = repository[key];
            return result as T;
        }
    }
}
