using System;

using MovementPlayground.ResourceBars;

using UnityEngine;
using UnityEngine.InputSystem;

namespace MovementPlayground.Card.CardPlayer
{
    public class CardPlayer : CardPlayerStateMachine
    {
        PlayerInput _playerInput;

        public PlayerHandManager PlayerHandManager;
        public ResourceBarManager ResourceBarManager;
        public PlayerAbilityTargetingManager TargetingManager;
        public CardPlayArea CardPlayArea;
        public Transform ProjectileOrigin;

        private CardUISlot _lastSlotPressed;

        public CardUISlot LastSlotPressed { get => _lastSlotPressed; set => _lastSlotPressed = value; }

        private void Awake()
        {
            _playerInput = new PlayerInput();
            ResourceBarManager = GameObject.Find("Resource Bars").GetComponent<ResourceBarManager>();
            SetState(new Gameplay(this));
        }

        private void OnEnable()
        {
            _playerInput.CharacterControls.Enable(); 
            _playerInput.CharacterControls.AbilityOne.performed += HandleAbilityButtonPressed;
            _playerInput.CharacterControls.AbilityTwo.performed += HandleAbilityButtonPressed;
            _playerInput.CharacterControls.AbilityThree.performed += HandleAbilityButtonPressed;
            _playerInput.CharacterControls.AbilityFour.performed += HandleAbilityButtonPressed;
            _playerInput.CharacterControls.LeftClick.performed += HandleMouseClicked;
        }

        private void OnDisable()
        {
            _playerInput.CharacterControls.Disable();
            _playerInput.CharacterControls.AbilityOne.performed -= HandleAbilityButtonPressed;
            _playerInput.CharacterControls.AbilityTwo.performed -= HandleAbilityButtonPressed;
            _playerInput.CharacterControls.AbilityThree.performed -= HandleAbilityButtonPressed;
            _playerInput.CharacterControls.AbilityFour.performed -= HandleAbilityButtonPressed;
            _playerInput.CharacterControls.LeftClick.performed -= HandleMouseClicked;
        }

        private void HandleAbilityButtonPressed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => State.AbilityButtonPressed(obj);

        private void HandleMouseClicked(UnityEngine.InputSystem.InputAction.CallbackContext obj) => State.MouseClicked(obj);

        public CardUISlot DetermineSlotFromKeybindName(string actionName)
        {
            switch (actionName)
            {
                case "AbilityOne":
                    return PlayerHandManager.CardSlots[0];
                case "AbilityTwo":
                    return PlayerHandManager.CardSlots[1];
                case "AbilityThree":
                    return PlayerHandManager.CardSlots[2];
                case "AbilityFour":
                    return PlayerHandManager.CardSlots[3];
                default:
                    break;
            }

            return null;
        }
    }
}
