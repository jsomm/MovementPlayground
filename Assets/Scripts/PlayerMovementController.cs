
using System;

using Mirror;

using UnityEngine;

namespace MovementPlayground
{
    class PlayerMovementController : NetworkBehaviour
    {
        [SerializeField] private float _movementSpeed = 5f;

        private CharacterController _characterController;
        private Vector3 _previousInput;
        bool _isMovementPressed = false;

        private PlayerInput _inputActions;
        private PlayerInput InputActions
        {
            get
            {
                if (_inputActions != null) { return _inputActions; }
                return _inputActions = new PlayerInput();
            }
        }

        public override void OnStartAuthority()
        {
            enabled = true;

            InputActions.CharacterControls.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
            InputActions.CharacterControls.Move.canceled += ctx => ResetMovement();
        }

        [ClientCallback]
        private void Awake() => _characterController = GetComponent<CharacterController>();

        [ClientCallback]
        private void OnEnable() => InputActions.Enable();

        [ClientCallback]
        private void OnDisable() => InputActions.Disable();

        [ClientCallback]
        private void Update() => Move();

        [Client]
        private void SetMovement(Vector2 movement)
        {
            _previousInput = new Vector3(movement.x, 0f, movement.y);
            _isMovementPressed = true;
        }

        [Client]
        private void ResetMovement()
        {
            _previousInput = Vector2.zero;
            _isMovementPressed = false;
        }

        private void Move()
        {
            _characterController.Move(_previousInput * _movementSpeed * Time.deltaTime);
            if (_isMovementPressed)
                HandleRotation();
        }

        private void HandleRotation()
        {
            Vector3 positionToLookAt;

            positionToLookAt.x = _previousInput.x;
            positionToLookAt.y = 0.0f;
            positionToLookAt.z = _previousInput.z;

            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);

            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, 15f * Time.deltaTime); // change '15f' to adjust how quickly the player rotates
        }
    }
}
