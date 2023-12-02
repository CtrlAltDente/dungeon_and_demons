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

        private void Initialize()
        {
            _meshFilter.mesh = Item.Model.Mesh;
            _meshRenderer.materials = Item.Model.Model.GetComponent<MeshRenderer>().sharedMaterials;

            _meshCollider.sharedMesh = Item.Model.Mesh;

            transform.position += Item.Model.PositionOffset;
            transform.rotation *= Quaternion.Euler(Item.Model.RotationOffset);
        }
    }
}