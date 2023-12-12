using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects.Containers
{
    [CreateAssetMenu(fileName = "Container_", menuName = "Scriptable Objects/Containers/ItemModel", order = 1)]
    public class ItemModelsContainer : Container<ItemModel>
    {
        public ItemType ItemsType;
    }
}