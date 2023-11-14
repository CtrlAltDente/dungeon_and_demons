using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonAndDemons.Game
{
    public class CollisionArea : MonoBehaviour
    {
        public UnityEvent<Collider> OnTriggerEnterEvent;

        [SerializeField]
        private Collider _collider;

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterEvent?.Invoke(other);
        }

        public void EnableCollider()
        {
            _collider.enabled = true;
            StartCoroutine(DisableCollider());
        }

        private IEnumerator DisableCollider()
        {
            yield return new WaitForSeconds(0.1f);
            _collider.enabled = false;
        }
    }
}