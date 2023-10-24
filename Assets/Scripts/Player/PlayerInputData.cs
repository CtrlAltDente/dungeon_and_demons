using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Player
{
    public struct PlayerInputData
    {
        public Vector2 MovementVector;
        public bool IsAttack;

        public PlayerInputData(Vector2 movementVector, bool isAttack)
        {
            MovementVector = movementVector;
            IsAttack = isAttack;
        }
    }
}