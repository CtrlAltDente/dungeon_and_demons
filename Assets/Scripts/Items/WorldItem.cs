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

        public ItemVisual ItemVisual;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        { 
            if(ItemInfo.Type != ItemType.None)
            {
                ItemVisual = Instantiate(_itemsContainer.Find(container => container.ContainerItemsType == ItemInfo.Type).Items[ItemInfo.ItemIndex], transform.position, Quaternion.identity, transform);
                _meshCollider.sharedMesh = ItemVisual.MeshFilter.sharedMesh;
            }
        }
    }
}