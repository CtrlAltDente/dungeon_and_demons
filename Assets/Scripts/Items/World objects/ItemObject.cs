using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Player;
using DungeonAndDemons.ScriptableObjects;
using DungeonAndDemons.ScriptableObjects.Containers;
using DungeonAndDemons.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DungeonAndDemons.Items
{
    public class ItemObject : MonoBehaviour
    {
        public virtual SlotType Type => _item.Type;

        public bool IsInitializeAtStart = true;

        [SerializeField]
        private ItemModelsContainer[] _modelContainers;

        [SerializeField]
        private Item _item;

        [SerializeField]
        private MeshFilter _meshFilter;
        [SerializeField]
        private MeshRenderer _meshRenderer;

        [SerializeField]
        private MeshCollider _meshCollider;

        [SerializeField]
        private ItemUI _itemUI;

        public bool IsKinematic
        {
            get
            {
                return GetComponent<Rigidbody>().isKinematic;
            }
            set
            {
                GetComponent<Rigidbody>().isKinematic = value;
            }
        }

        public Item Item
        {
            set
            {
                _item = value;
                _itemUI.SetDescription(this);
            }
            get
            {
                return _item;
            }
        }

        private void Start()
        {
            if (IsInitializeAtStart)
            {
                InitializeAtStart();
            }

            _itemUI.SetDescription(this);
        }

        public void Initialize()
        {
            ItemModel itemModel = GetModelContainer(Item.Type).Items[Item.ModelIndex];

            if (itemModel != null)
            {
                SetItemData(
                    itemModel.Mesh,
                    itemModel.Model.GetComponent<MeshRenderer>().sharedMaterials,
                    itemModel.PositionOffset,
                    itemModel.RotationOffset
                    );
            }
            else
            {
                SetItemData(null, null, Vector3.zero, Vector3.zero);
            }
        }

        public void SetActiveUI(bool isActive)
        {
            _itemUI.gameObject.SetActive(isActive);
        }

        private void InitializeAtStart()
        {
            ItemModel itemModel = GetModelContainer(Item.Type).Items[Item.ModelIndex];

            if (itemModel != null)
            {
                SetItemData(
                        itemModel.Mesh,
                        itemModel.Model.GetComponent<MeshRenderer>().sharedMaterials,
                        transform.position + itemModel.PositionOffset,
                        transform.rotation.eulerAngles + itemModel.RotationOffset
                        );
            }
        }

        private void SetItemData(Mesh mesh, Material[] materials, Vector3 positionOffset, Vector3 rotationOffset)
        {
            _meshFilter.mesh = mesh;
            if (materials != null)
                _meshRenderer.materials = materials;

            _meshCollider.sharedMesh = mesh;

            transform.localPosition = positionOffset;
            transform.localRotation = Quaternion.Euler(rotationOffset);
        }

        private ItemModelsContainer GetModelContainer(SlotType itemType)
        {
            foreach(ItemModelsContainer modelsContainer in _modelContainers)
            {
                if(modelsContainer.ItemsType == itemType)
                {
                    return modelsContainer;
                }
            }

            return null;
        }
    }
}