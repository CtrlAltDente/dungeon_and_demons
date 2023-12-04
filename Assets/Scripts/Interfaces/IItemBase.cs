using DungeonAndDemons.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Interfaces
{
    public interface IItemBase
    {
        public string Name { get; }
        public ItemModel Model { get; }
    }
}