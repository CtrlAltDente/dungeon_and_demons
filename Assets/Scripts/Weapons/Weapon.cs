using DungeonAndDemons.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        protected int _damage;
         
        public abstract void Attack();
    }
}