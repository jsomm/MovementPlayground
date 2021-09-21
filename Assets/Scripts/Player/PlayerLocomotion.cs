using System;

using Mirror;

using UnityEngine;

namespace MovementPlayground
{
    class PlayerLocomotion : NetworkBehaviour
    {
        [SerializeField] float _movementSpeed = 5f;

        CharacterController _characterController = null;
        Animator _animator = null;

        // hashes for animator values
        int _isRunningHash;

        Vector3 _previousInput;
        bool _isMovementPressed = false;

        PlayerInput _inputActions;
        PlayerInput InputActions
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
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();

            _isRunningHash = Animator.StringToHash("isRunning");
        }

        [ClientCallback]
        private void OnEnable() => InputActions.Enable();

        [ClientCallback]
        private void OnDisable() => InputActions.Disable();

        [ClientCallback]
        private void Update()
        {
            if (!hasAuthority)
                return;

            Move();
        }

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
            {
                HandleRotation();
            }

            HandleAnimation();
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

        private void HandleAnimation()
        {
            // more complicated move animations could go here, but this is all we need for now
            _animator.SetBool(_isRunningHash, _isMovementPressed);
        }
    }
}
