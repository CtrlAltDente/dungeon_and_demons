using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Player
{
    public struct PlayerInputData
    {
        public Vector2 MovementVector;
        public bool IsFire;

        public PlayerInputData(Vector2 movementVector, bool isFire)
        {
            MovementVector = movementVector;
            IsFire = isFire;
        }
    }
}