using UnityEngine;

namespace EventSystem.Scripts.MonoBehaviours
{
    /// <summary>
    /// Helper class to register and unregister events easily
    /// </summary>
    public abstract class EventHandledMonoBehaviour : MonoBehaviour
    {
        protected abstract void SubscribeEvents();
        protected abstract void UnSubscribeEvents();

        public virtual void OnEnable()
        {
            SubscribeEvents();
        }

        public virtual void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}
