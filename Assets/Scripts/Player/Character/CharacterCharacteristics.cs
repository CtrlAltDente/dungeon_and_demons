using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Characters
{
    [Serializable]
    public struct CharacterCharacteristics
    {
        public int Strength;        //hp and attack power
        public int Dexterity;       //critical strike chance and enemy attack miss chance
        public int Intelligence;    //mana
    }
}