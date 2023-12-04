using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Interfaces
{
    public interface IItemObject<out T> where T : IItemBase
    {
        public ItemInfo Info { get; }
        public T Item { get; }
        public ItemType Type { get; }
    }
}