using DungeonAndDemons.Interfaces;
using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class ItemObject<T> : MonoBehaviour, IItemObject<T> where T : IItemBase
    {
        public virtual ItemType Type => ItemType.None;

        public bool IsInitializeAtStart = true;

        [SerializeField]
        private ItemInfo _info;
        [SerializeField]
        private T _item;

        [SerializeField]
        private MeshFilter _meshFilter;
        [SerializeField]
        private MeshRenderer _meshRenderer;

        [SerializeField]
        private MeshCollider _meshCollider;

        public ItemInfo Info
        {
            get
            {
                return _info;
            }
            set
            {
                _info = value;
            }
        }

        public T Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
            }
        }

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

        private void Start()
        {
            if (IsInitializeAtStart)
            {
                InitializeAtStart();
            }
        }

        public void Initialize()
        {
            if (_item != null)
            {
                SetItemData(
                    _item.Model.Mesh,
                    _item.Model.Model.GetComponent<MeshRenderer>().sharedMaterials,
                    _item.Model.PositionOffset,
                    _item.Model.RotationOffset
                    );
            }
            else
            {
                SetItemData(null, null, Vector3.zero, Vector3.zero);
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

        private void InitializeAtStart()
        {
            SetItemData(
                    _item.Model.Mesh,
                    _item.Model.Model.GetComponent<MeshRenderer>().sharedMaterials,
                    transform.position + _item.Model.PositionOffset,
                    transform.rotation.eulerAngles + _item.Model.RotationOffset
                    );
        }
    }
}