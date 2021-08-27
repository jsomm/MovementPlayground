// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""bf8922c4-833b-4902-8daa-eb04f45f8fa0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ee0c14ce-4eae-4cd9-b5d1-d9142fc03c64"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""2274c214-7328-4b38-a2e0-03af5ccf6664"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityOne"",
                    ""type"": ""Button"",
                    ""id"": ""ced6931f-ff6b-491e-aa7c-abaf7e238c56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityTwo"",
                    ""type"": ""Button"",
                    ""id"": ""c5df6908-4b81-4fda-9bfc-32fd91504955"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityThree"",
                    ""type"": ""Button"",
                    ""id"": ""f2a30cca-5809-4b20-b43c-ab5733a1705a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2882720f-8116-4e77-ad01-b191dbc8c266"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""d22ed72a-d1ad-4b68-9973-30ed84da8292"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""49d473e9-9c34-40cd-a74c-305bebf5f961"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0eb382e0-f246-4895-b019-f1da06d1df79"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9b9af5cf-0342-44b3-a38b-9b4eacf19353"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8b6e588e-f3dc-4a3b-89e3-8389611327ef"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ae48c815-a352-4248-b53a-6eb5b1491a69"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0546a711-a6af-4662-90bd-386cf9d6156d"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9397344-a3fa-4301-a32e-4d5cbafa192b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6efd719b-3851-42b0-9500-aacfaf6d0692"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8b2758d-780b-4635-9fdf-215af4210319"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityThree"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MouseCameraControls"",
            ""id"": ""a54731ff-5f93-42f0-bee7-caea7fa99c59"",
            ""actions"": [
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""e8f21b6c-8548-4514-a24a-de9ec129407f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0d834394-5ec3-499b-8def-265fcbea19e8"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-1,max=1),Invert"",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_Move = m_CharacterControls.FindAction("Move", throwIfNotFound: true);
        m_CharacterControls_Run = m_CharacterControls.FindAction("Run", throwIfNotFound: true);
        m_CharacterControls_AbilityOne = m_CharacterControls.FindAction("AbilityOne", throwIfNotFound: true);
        m_CharacterControls_AbilityTwo = m_CharacterControls.FindAction("AbilityTwo", throwIfNotFound: true);
        m_CharacterControls_AbilityThree = m_CharacterControls.FindAction("AbilityThree", throwIfNotFound: true);
        // MouseCameraControls
        m_MouseCameraControls = asset.FindActionMap("MouseCameraControls", throwIfNotFound: true);
        m_MouseCameraControls_Zoom = m_MouseCameraControls.FindAction("Zoom", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_Move;
    private readonly InputAction m_CharacterControls_Run;
    private readonly InputAction m_CharacterControls_AbilityOne;
    private readonly InputAction m_CharacterControls_AbilityTwo;
    private readonly InputAction m_CharacterControls_AbilityThree;
    public struct CharacterControlsActions
    {
        private @PlayerInput m_Wrapper;
        public CharacterControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CharacterControls_Move;
        public InputAction @Run => m_Wrapper.m_CharacterControls_Run;
        public InputAction @AbilityOne => m_Wrapper.m_CharacterControls_AbilityOne;
        public InputAction @AbilityTwo => m_Wrapper.m_CharacterControls_AbilityTwo;
        public InputAction @AbilityThree => m_Wrapper.m_CharacterControls_AbilityThree;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                @AbilityOne.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbilityOne;
                @AbilityOne.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbilityOne;
                @AbilityOne.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbilityOne;
                @AbilityTwo.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbilityTwo;
                @AbilityTwo.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbilityTwo;
                @AbilityTwo.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbilityTwo;
                @AbilityThree.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbilityThree;
                @AbilityThree.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbilityThree;
                @AbilityThree.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbilityThree;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @AbilityOne.started += instance.OnAbilityOne;
                @AbilityOne.performed += instance.OnAbilityOne;
                @AbilityOne.canceled += instance.OnAbilityOne;
                @AbilityTwo.started += instance.OnAbilityTwo;
                @AbilityTwo.performed += instance.OnAbilityTwo;
                @AbilityTwo.canceled += instance.OnAbilityTwo;
                @AbilityThree.started += instance.OnAbilityThree;
                @AbilityThree.performed += instance.OnAbilityThree;
                @AbilityThree.canceled += instance.OnAbilityThree;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);

    // MouseCameraControls
    private readonly InputActionMap m_MouseCameraControls;
    private IMouseCameraControlsActions m_MouseCameraControlsActionsCallbackInterface;
    private readonly InputAction m_MouseCameraControls_Zoom;
    public struct MouseCameraControlsActions
    {
        private @PlayerInput m_Wrapper;
        public MouseCameraControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Zoom => m_Wrapper.m_MouseCameraControls_Zoom;
        public InputActionMap Get() { return m_Wrapper.m_MouseCameraControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseCameraControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMouseCameraControlsActions instance)
        {
            if (m_Wrapper.m_MouseCameraControlsActionsCallbackInterface != null)
            {
                @Zoom.started -= m_Wrapper.m_MouseCameraControlsActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_MouseCameraControlsActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_MouseCameraControlsActionsCallbackInterface.OnZoom;
            }
            m_Wrapper.m_MouseCameraControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
            }
        }
    }
    public MouseCameraControlsActions @MouseCameraControls => new MouseCameraControlsActions(this);
    public interface ICharacterControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnAbilityOne(InputAction.CallbackContext context);
        void OnAbilityTwo(InputAction.CallbackContext context);
        void OnAbilityThree(InputAction.CallbackContext context);
    }
    public interface IMouseCameraControlsActions
    {
        void OnZoom(InputAction.CallbackContext context);
    }
}
