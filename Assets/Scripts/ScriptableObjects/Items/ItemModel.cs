using DungeonAndDemons.Enums;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemModel_", menuName = "Scriptable Objects/Items/Model", order = 0)]
    public class ItemModel : ScriptableObject
    {
        public Mesh Mesh => Model.GetComponent<MeshFilter>().sharedMesh;

        public GameObject Model;

        public ItemType ItemType;

        public Vector3 PositionOffset;
        public Vector3 RotationOffset;
    }
}