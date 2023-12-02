using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Items
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Items/Item Type/Weapon", fileName = "Weapon_", order = 2)]
    public class WeaponItem : ScriptableObject
    {
        public string Name;
        public int DamageValue;
        public ItemModel Model;
    }
}