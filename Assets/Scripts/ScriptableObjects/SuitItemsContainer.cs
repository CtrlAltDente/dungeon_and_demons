using DungeonAndDemons.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Suit Items Container", fileName = "Suit Items Container", order = 2)]
    public class SuitItemsContainer : ScriptableObject
    {
        public SuitItem[] Items;
    }
}