using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [CreateAssetMenu(fileName = "Weapon_", menuName = "Scriptable Objects/Items/Weapon Item", order = 6)]
    public class WeaponItem : ScriptableObject
    {
        public string Name;
        public int DamageValue;
        public ItemModel Model;
    }
}