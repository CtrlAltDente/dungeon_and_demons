using DungeonAndDemons.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonAndDemons.Interfaces
{
    public interface IInputType
    {
        public PlayerInputData GetPlayerInputData();
    }
}