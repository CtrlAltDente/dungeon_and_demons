using ClansWars.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Map Container", menuName = "Scriptable Objects/Maps/Map Container", order = 0)]
    public class MapsContainer : ScriptableObject
    {
        [SerializeField]
        public Map[] Maps;
    }
}