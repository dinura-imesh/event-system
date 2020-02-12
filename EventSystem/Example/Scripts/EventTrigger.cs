using EventSystem.Example.Scripts.Events;
using EventSystem.Scripts.Managers;
using UnityEngine;

namespace EventSystem.Example.Scripts
{
    public class EventTrigger : MonoBehaviour
    {
        public void FireEvent(int id)
        {
            Color color = Color.clear;
            switch (id)
            {
                case 0:
                    color = Color.blue;
                    break;
                case 1:
                    color = Color.green;
                    break;
                case 2:
                    color = Color.black;
                    break;
                case 3:
                    color = Color.grey;
                    break;
                case 4:
                    color = Color.red;
                    break;
            }

            ColorChangeEvent colorChangeEvent = new ColorChangeEvent(color);
            EventManager.Fire(colorChangeEvent);
        }
    }
}