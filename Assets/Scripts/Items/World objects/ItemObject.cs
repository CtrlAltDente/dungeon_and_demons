using DungeonAndDemons.Interfaces;
using DungeonAndDemons.Player;
using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    public class ItemObject : MonoBehaviour
    {
        public virtual ItemType Type => Item.Type;

        public bool IsInitializeAtStart = true;

        public Item Item;

        [SerializeField]
        private MeshFilter _meshFilter;
        [SerializeField]
        private MeshRenderer _meshRenderer;

        [SerializeField]
        private MeshCollider _meshCollider;

        [SerializeField]
        private GameObject _itemUI;

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
            if (Item.Model != null)
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

        private void InitializeAtStart()
        {
            if (Item.Model != null)
            {
                SetItemData(
                        Item.Model.Mesh,
                        Item.Model.Model.GetComponent<MeshRenderer>().sharedMaterials,
                        transform.position + Item.Model.PositionOffset,
                        transform.rotation.eulerAngles + Item.Model.RotationOffset
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
    }
}