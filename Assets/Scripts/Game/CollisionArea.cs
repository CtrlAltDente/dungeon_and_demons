using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClansWars.Game
{
    public class CollisionArea : MonoBehaviour
    {
        public UnityEvent<Collider> OnTriggerEnterEvent;

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterEvent?.Invoke(other);
        }
    }
}