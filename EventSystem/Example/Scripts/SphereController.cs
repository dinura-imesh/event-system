using EventSystem.Example.Scripts.Events;
using EventSystem.Scripts.Managers;
using EventSystem.Scripts.MonoBehaviours;
using UnityEngine;

namespace EventSystem.Example.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    public class SphereController : EventHandledMonoBehaviour
    {

        private MeshRenderer _meshRenderer;

        public override void OnEnable()
        {
            SubscribeEvents();
            _meshRenderer = GetComponent<MeshRenderer>();
        }
    
        protected override void SubscribeEvents()
        {
            EventManager.AddListener<ColorChangeEvent>(HandleOnColorChangeEvent);
        }

    

        protected override void UnSubscribeEvents()
        {
            EventManager.RemoveListener<ColorChangeEvent>(HandleOnColorChangeEvent);
        }
    
        private void HandleOnColorChangeEvent(ColorChangeEvent colorChangeEvent)
        {
            _meshRenderer.material.color = colorChangeEvent.Color;
        }
    }
}
