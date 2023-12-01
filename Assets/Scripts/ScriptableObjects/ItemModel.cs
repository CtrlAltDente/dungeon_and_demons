using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemModel_", menuName = "Scriptable Objects/Items/Item Model", order = 3)]
    public class ItemModel : ScriptableObject
    {
        public GameObject Model;
        public MeshFilter MeshFilter;
        public Vector3 PositionOffset;
        public Vector3 RotationOffset;
    }
}