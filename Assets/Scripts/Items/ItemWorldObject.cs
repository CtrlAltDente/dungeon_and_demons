using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class ItemWorldObject : MonoBehaviour
    {
        public Item ItemReference;

        public bool InitializeAtStart = false;

        public bool IsKinematic
        {
            get
            {
                return _rigidbody.isKinematic;
            }
            set
            {
                _rigidbody.isKinematic = value;
            }
        }

        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private MeshCollider _meshCollider;

        private void Start()
        {
            if (InitializeAtStart)
            {
                InitializeOnWorld(false);
            }
        }

        public void InitializeOnWorld(bool isKinematic)
        {
            IsKinematic = isKinematic;

            Instantiate(ItemReference.Model, transform.position, Quaternion.identity, transform);
            _meshCollider.sharedMesh = ItemReference.Model.Mesh;
        }
    }
}