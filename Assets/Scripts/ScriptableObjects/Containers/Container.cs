using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects.Containers
{
    public class Container<T> : ScriptableObject
    {
        public T[] Items;
    }
}