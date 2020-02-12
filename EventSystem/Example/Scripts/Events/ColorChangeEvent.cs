using UnityEngine;

namespace EventSystem.Example.Scripts.Events
{
    public class ColorChangeEvent
    {
        public Color Color;

        public ColorChangeEvent(Color color)
        {
            Color = color;
        }
    }
}
