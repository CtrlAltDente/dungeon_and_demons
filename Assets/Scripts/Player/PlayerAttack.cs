using ClansWars.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Player
{
    public class PlayerAttack : MonoBehaviour, IPlayerLogicPart
    {
        private PlayerInputData _currentPlayerInputData;

        private void Update()
        {
            Attack();
        }

        public void SetPlayerInputData(PlayerInputData playerInputData)
        {
            _currentPlayerInputData = playerInputData;
        }

        private void Attack()
        {
            if(_currentPlayerInputData.IsAttack)
            {

            }
        }
    }
}