using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Items/Items Container", fileName = "ItemsContainer_", order = 1)]
    public class ItemsContainer : ScriptableObject
    {
        public ItemType ContainerItemsType;
        public Item[] Items;
    }
}