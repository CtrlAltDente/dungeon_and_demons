using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Interfaces
{
    public interface IInputType
    {
        public PlayerInputData GetPlayerInputData();
    }
}