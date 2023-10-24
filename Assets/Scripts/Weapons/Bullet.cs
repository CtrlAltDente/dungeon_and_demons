using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 50f;

        private void Start()
        {
            StartCoroutine(SelfKiller());
        }

        private void Update()
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }

        private IEnumerator SelfKiller()
        {
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }
    }
}