using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Weapon Items Container", fileName = "WeaItems Container", order = 1)]
    public class WeaponItemsContainer : ScriptableObject
    {
        public WeaponItem[] Items;
    }
}