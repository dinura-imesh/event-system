using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem.Scripts.Managers
{
    public class EventManager
    {
        private static EventManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EventManager();;
                return _instance;
            }
        }

        private static EventManager _instance;


        private readonly Dictionary<Type,List<dynamic>> _actionDic = new Dictionary<Type, List<dynamic>>();

        /// <summary>
        /// Register a method to an event.
        /// </summary>
        /// <param name="action">Method to register</param>
        /// <typeparam name="T">Event type</typeparam>
        public static void AddListener<T>(Action<T> action)
        {
            if (Instance._actionDic.ContainsKey(typeof(T)))
            {
                Instance._actionDic[typeof(T)].Add(action);
            }
            else
            {
                List<dynamic> actionList = new List<dynamic> {action};
                Instance._actionDic.Add(typeof(T),actionList);
            }
        }

        /// <summary>
        /// Removes a registered method
        /// </summary>
        /// <param name="action">Method to unregister</param>
        /// <typeparam name="T">Event type</typeparam>
        public static void RemoveListener<T>(Action<T> action)
        {
            if (Instance._actionDic.ContainsKey(typeof(T)))
            {
                if (Instance._actionDic[typeof(T)].Contains(action))
                {
                    Instance._actionDic[typeof(T)].Remove(action);
                }
                else
                {
                    Debug.LogWarning("Method does not exist");
                }
            }
            else
            {
                Debug.LogWarning("Key does not exist");
            }
        }

        /// <summary>
        /// Fires the given event
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        public static void Fire<T>(T obj)
        {
            if (Instance._actionDic.ContainsKey(typeof(T)))
            {
                foreach (var ob in Instance._actionDic[typeof(T)])
                {
                    if (ob is Action<T> action)
                    {
                        action.Invoke(obj);
                    }
                    else
                    {
                        Debug.LogError("Missing method. Use RemoveListener to unregister the methods");
                    }
                }
            }
        }
    }
}
