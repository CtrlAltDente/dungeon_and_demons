using DungeonAndDemons.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        public CharacterClass CharacterClass;

        public Transform RightHandItemParent;
        public Transform LeftHandItemParent;

        public Animator Animator;
    }
}