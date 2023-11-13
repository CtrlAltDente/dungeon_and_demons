using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Characters List", menuName = "Scriptable Objects/Characters List", order = 0)]
    public class CharactersContainer : ScriptableObject
    {
        public List<PlayerModel> PlayerModels;
    }
}
