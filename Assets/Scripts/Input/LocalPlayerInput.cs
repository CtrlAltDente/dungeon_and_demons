using ClansWars.Interfaces;
using ClansWars.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClansWars.Input
{
    public class LocalPlayerInput : MonoBehaviour
    {
        [SerializeField]
        private InputActionReference _movementPlayerInputActionReference;
        [SerializeField]
        private InputActionReference _attackPlayerInputActionReference;

        [SerializeField]
        private List<GameObject> PlayerLogicGameObjects = new List<GameObject>();
        [SerializeField]
        private List<IPlayerLogicPart> PlayerLogicParts = new List<IPlayerLogicPart>();

        private void Awake()
        {
            SetPlayerLogicParts();
        }

        private void Update()
        {
            ApplyInputToThePlayerLogicParts();
        }

        private void SetPlayerLogicParts()
        {
            foreach (GameObject gameObject in PlayerLogicGameObjects)
            {
                if(gameObject.GetComponent<IPlayerLogicPart>() != null)
                {
                    PlayerLogicParts.Add(gameObject.GetComponent<IPlayerLogicPart>());
                }
                else
                {
                    Debug.Log($"GameObject {gameObject.name} has not IPlayerLogicPart realization");
                }
            }
        }

        private void ApplyInputToThePlayerLogicParts()
        {
            Vector2 movementVector = _movementPlayerInputActionReference.action.ReadValue<Vector2>();
            bool isAttack = _attackPlayerInputActionReference.action.IsPressed();

            PlayerInputData playerInputData = new PlayerInputData(movementVector, isAttack);

            foreach (IPlayerLogicPart playerLogicPart in PlayerLogicParts)
            {
                playerLogicPart.SetPlayerInputData(playerInputData);
            }
        }
    }
}