using System;

using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityHolder : MonoBehaviour
{
    PlayerInput playerInput;

    enum AbilityState
    {
        Ready,
        Active,
        Cooldown
    }

    public Ability ability;
    float cooldownTime, activeTime;
    AbilityState state = AbilityState.Ready;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.CharacterControls.AbilityOne.performed += PerformAbility;
    }
    private void Update()
    {
        switch (state)
        {
            case AbilityState.Ready:
                activeTime = ability.ActiveTime;
                break;
            case AbilityState.Active:                
                if (activeTime > 0)
                    activeTime -= Time.deltaTime;                
                else
                {
                    state = AbilityState.Cooldown;
                    cooldownTime = ability.CooldownTime;
                }
                break;
            case AbilityState.Cooldown:
                if (cooldownTime > 0)
                    cooldownTime -= Time.deltaTime;
                else
                    state = AbilityState.Ready;
                break;
        }
    }

    private void PerformAbility(InputAction.CallbackContext obj)
    {
        if(state == AbilityState.Ready)
        {
            ability.Activate(gameObject);
            state = AbilityState.Active;
        }
    }

    private void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        playerInput.CharacterControls.Disable();
    }
}
