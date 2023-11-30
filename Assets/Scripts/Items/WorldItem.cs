using DungeonAndDemons.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class WorldItem : MonoBehaviour
    {
        public ItemInfo ItemInfo;

        [SerializeField]
        private List<ItemsContainer> _itemsContainer;

        [SerializeField]
        private MeshCollider _meshCollider;
        [SerializeField]
        private Rigidbody _rigidbody;

        public ItemVisual ItemVisual;

        private void Start()
        {
            Initialize(false);
        }

        public void Initialize(bool isKinematic)
        { 
            if(_meshCollider.sharedMesh == null)
            {
                _rigidbody.isKinematic = isKinematic;
                
                ItemVisual = Instantiate(_itemsContainer.Find(container => container.ContainerItemsType == ItemInfo.Type).Items[ItemInfo.ItemIndex], transform.position, Quaternion.identity, transform);
                _meshCollider.sharedMesh = ItemVisual.MeshFilter.sharedMesh;
            }
        }
    }
}