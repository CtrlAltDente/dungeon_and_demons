using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Items Container", fileName = "Items Container", order = 1)]
    public class ItemsContainer : ScriptableObject
    {
        public Item[] Items;
    }
}