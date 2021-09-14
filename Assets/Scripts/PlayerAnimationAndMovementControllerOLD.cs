using System;

using Mirror;

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerAnimationAndMovementController : NetworkBehaviour
{
    // references
    CharacterController _characterController;
    Animator _animator;

    // hashes for animator values
    int _isWalkingHash, _isRunningHash;

    // variables to store player input values
    Vector2 _currentMovementInput;
    Vector3 _currentMovement, _currentRunMovement;
    private PlayerInput _inputActions;
    private PlayerInput InputActions
    {
        get
        {
            if (_inputActions != null) { return _inputActions; }
            return _inputActions = new PlayerInput();
        }
    }

    // visible in inspector
    public float MoveSpeed = 1.5f;
    public float RunSpeed = 3f;

    // private
    bool _isMovementPressed;
    bool _isRunPressed;
    readonly float _rotationFactorPerFrame = 15f;

    public override void OnStartAuthority()
    {
        enabled = true;

        InputActions.CharacterControls.Move.performed += OnMovementInput;
        InputActions.CharacterControls.Move.canceled += OnMovementInput;

        InputActions.CharacterControls.Run.performed += OnRun;
        InputActions.CharacterControls.Run.canceled += OnRun;
    }

    [ClientCallback]
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        _isWalkingHash = Animator.StringToHash("isWalking");
        _isRunningHash = Animator.StringToHash("isRunning");
    }

    [ClientCallback]
    private void Update()
    {
        HandleGravity();
        HandleRotation();
        HandleAnimation();
        if (_isRunPressed)
            _characterController.Move(_currentRunMovement * Time.deltaTime);
        else
            _characterController.Move(_currentMovement * Time.deltaTime);
    }

    [ClientCallback]
    private void OnEnable()
    {
        InputActions.CharacterControls.Enable();
    }

    [ClientCallback]
    private void OnDisable()
    {
        InputActions.CharacterControls.Disable();
    }


    [Client]
    private void OnRun(InputAction.CallbackContext context)
    {
        _isRunPressed = context.ReadValueAsButton();
    }

    [Client]
    private void OnMovementInput(InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        _currentMovement.x = _currentMovementInput.x * MoveSpeed;
        _currentMovement.z = _currentMovementInput.y * MoveSpeed;
        _currentRunMovement.x = _currentMovementInput.x * RunSpeed;
        _currentRunMovement.z = _currentMovementInput.y * RunSpeed;
        _isMovementPressed = _currentMovementInput.x != 0 || _currentMovementInput.y != 0;
    }

    [Client]
    private void HandleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = _currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = _currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (_isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);
        }
    }

    [Client]
    private void HandleAnimation()
    {
        bool isWalking = _animator.GetBool(_isWalkingHash);
        bool isRunning = _animator.GetBool(_isRunningHash);

        if(_isMovementPressed && !isWalking)        
            _animator.SetBool(_isWalkingHash, true);
        else if(!_isMovementPressed && isWalking)
            _animator.SetBool(_isWalkingHash, false);

        if (_isMovementPressed && _isRunPressed && !isRunning)
            _animator.SetBool(_isRunningHash, true);
        else if ((!_isMovementPressed || !_isRunPressed) && isRunning)
            _animator.SetBool(_isRunningHash, false);
    }

    [Client]
    private void HandleGravity()
    {
        if (_characterController.isGrounded)
        {
            float groundedGravity = -0.05f;
            _currentMovement.y = groundedGravity;
            _currentRunMovement.y = groundedGravity;
        }
        else
        {
            float gravity = -9.8f;
            _currentMovement.y += gravity;
            _currentRunMovement.y += gravity;
        }
    }
}
