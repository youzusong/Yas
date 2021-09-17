using System;
using System.Collections.Generic;

namespace Yas.Core
{
    public class Singleton
    {
        static Singleton()
        {
            Store = new Dictionary<Type, object>();
        }


        public static IDictionary<Type, object> Store { get; }
    }

    public class Singleton<T> : Singleton
    {
        private static T instance;

        public static T Instance
        {
            get => instance;
            set
            {
                instance = value;
                Store[typeof(T)] = value;
            }
        }
    }

    public class SingletonList<T> : Singleton<IList<T>>
    {
        static SingletonList()
        {
            Singleton<IList<T>>.Instance = new List<T>();
        }

        public static new IList<T> Instance => Singleton<IList<T>>.Instance;
    }

    public class SingletonDictionary<TKey, TValue> : Singleton<IDictionary<TKey, TValue>>
    {
        static SingletonDictionary()
        {
            Singleton<Dictionary<TKey, TValue>>.Instance = new Dictionary<TKey, TValue>();
        }

        public static new IDictionary<TKey, TValue> Instance => Singleton<Dictionary<TKey, TValue>>.Instance;
    }
}

