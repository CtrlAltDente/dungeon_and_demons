using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Handheld Items Container", fileName = "Handheld Items Container", order = 1)]
    public class HandheldItemsContainer : ScriptableObject
    {
        public HandheldItem[] Items;
    }
}