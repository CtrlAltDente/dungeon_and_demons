using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Player
{
    public class PlayerState : MonoBehaviour
    {
        [SerializeField]
        private int _playerId;

        [SerializeField]
        private bool _isAlive = true;
    }
}