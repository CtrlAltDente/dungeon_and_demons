using DungeonAndDemons.Interfaces;
using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class ItemObject<T> : MonoBehaviour where T : IItemPreferences
    {
        public ItemInfo Info;
        public T Item;

        public virtual ItemType Type => ItemType.None;

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

        [SerializeField]
        private MeshFilter _meshFilter;
        [SerializeField]
        private MeshRenderer _meshRenderer;

        [SerializeField]
        private MeshCollider _meshCollider;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            if (Item != null)
            {
                SetItemData(
                    Item.Model.Mesh,
                    Item.Model.Model.GetComponent<MeshRenderer>().sharedMaterials,
                    Item.Model.PositionOffset,
                    Item.Model.RotationOffset
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
    }
}