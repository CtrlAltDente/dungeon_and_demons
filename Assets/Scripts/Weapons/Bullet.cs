using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Weapons
{
    public class Bullet : NetworkBehaviour
    {
        [SerializeField]
        private float _speed = 50f;

        private void Start()
        {
            try
            {
                if (NetworkManager.Singleton.IsHost)
                {
                    GetComponent<NetworkObject>().Spawn();
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            finally
            {
                StartCoroutine(SelfKiller());
            }
        }

        private void Update()
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }

        private IEnumerator SelfKiller()
        {
            yield return new WaitForSeconds(5f);

            try
            {
                if (NetworkManager.Singleton.IsHost)
                {
                    GetComponent<NetworkObject>().Despawn();
                    Destroy(gameObject);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                Destroy(gameObject);
            }
        }
    }
}