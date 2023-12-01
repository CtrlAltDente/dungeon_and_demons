using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class ItemWorldObject : MonoBehaviour
    {
        public ItemsContainer[] ItemsContainers;

        public ItemType ItemType;
        public int ItemIndex;

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

            ItemsContainer itemsContainer = GetItemsContainerByType();
            
            if (itemsContainer != null)
            {
                InstantiateItemModel(itemsContainer);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private ItemsContainer GetItemsContainerByType()
        {
            foreach (var item in ItemsContainers)
            {
                if (item.ContainerItemsType == ItemType)
                {
                    return item;
                }
            }

            return null;
        }

        private void InstantiateItemModel(ItemsContainer itemsContainer)
        {
            Item item = itemsContainer.Items[ItemIndex];
            Instantiate(item.Model.Model, transform.position, Quaternion.identity, transform);
            _meshCollider.sharedMesh = item.Model.Mesh;
        }
    }
}