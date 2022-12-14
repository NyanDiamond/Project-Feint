//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Control Schemes/Player Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""84e90344-ffad-4823-9cf3-a38cb8bbbac3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a5c45257-f186-4d8a-afa7-7e60132c704a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a21e4ca9-c07a-40d2-9323-984d49f86466"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TeleportMK"",
                    ""type"": ""Button"",
                    ""id"": ""c2544d34-8812-4a06-83cc-a450b53bed2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TeleportCT"",
                    ""type"": ""Button"",
                    ""id"": ""6962babb-274d-4fe8-9d10-fb98a8b6a633"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""66e7efdf-cca5-4cef-a601-9227caae8c03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ReturnTeleporter"",
                    ""type"": ""Button"",
                    ""id"": ""a6d677f2-ef9c-4064-ac8b-fb36af30cdd1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TeleportAiming"",
                    ""type"": ""Value"",
                    ""id"": ""8ddb5eda-1056-41be-8d9e-1d9c94ab54e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FastFall"",
                    ""type"": ""Button"",
                    ""id"": ""f3cebf4c-08e6-430b-84df-1aa47e435be4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""f5142bef-ad0a-49a7-be66-7e675f1e6667"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f2d6b241-2bb8-4908-ae7a-4437eb7afbe4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e2756137-4047-4c8a-a8e1-9bd68c101141"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""281fd322-c1e9-4a7e-9358-6753856815e5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0cf918ef-c873-468d-85aa-82341e6d31e6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f48104ca-d91c-4ef8-85d4-27cbba4bd901"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left Stick"",
                    ""id"": ""da258b9a-bcf0-4564-9236-c439951b38ed"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""91ea915d-302c-44b1-83d7-0b9f776a8613"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c4514222-62ab-4530-b40f-873a2328cdc5"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c3f9bacc-4b95-4cb6-9dc7-3f80d36a3800"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1a4b7c4-04b2-4a30-a97a-6a79943b32b6"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d973055c-e27b-4d95-835c-1bc781a25357"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92e2c9c3-4d0d-4dd6-bee9-d1ef66b73636"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b124246-d79a-45bd-b0ef-29bfad1a82d9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TeleportMK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d0e76bc-2054-4518-a531-923b3be491db"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e42486e-580e-4fe5-b032-d3cbd0b2ac10"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf23e7e2-63d6-431f-9a64-8f5657a4b77a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReturnTeleporter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""843799b7-d279-417d-a39d-d7f197c63b73"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReturnTeleporter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54a1e08c-c137-4734-8d96-6eeeed9e887c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReturnTeleporter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea5fcbd5-b5f1-4c3e-afdb-9a19a617ee12"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TeleportAiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de94ffdf-d1c0-4689-964a-4d9be49482c5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FastFall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56e5c0e4-ebb4-40e7-b6e5-46bd5acb0ef7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FastFall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc5dd5ef-aa30-43a5-9557-fa1d387a79b9"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TeleportCT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01b80e73-7ef1-4ec2-89fb-bac40886b57d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TeleportCT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_Move = m_Default.FindAction("Move", throwIfNotFound: true);
        m_Default_Jump = m_Default.FindAction("Jump", throwIfNotFound: true);
        m_Default_TeleportMK = m_Default.FindAction("TeleportMK", throwIfNotFound: true);
        m_Default_TeleportCT = m_Default.FindAction("TeleportCT", throwIfNotFound: true);
        m_Default_Attack = m_Default.FindAction("Attack", throwIfNotFound: true);
        m_Default_ReturnTeleporter = m_Default.FindAction("ReturnTeleporter", throwIfNotFound: true);
        m_Default_TeleportAiming = m_Default.FindAction("TeleportAiming", throwIfNotFound: true);
        m_Default_FastFall = m_Default.FindAction("FastFall", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_Move;
    private readonly InputAction m_Default_Jump;
    private readonly InputAction m_Default_TeleportMK;
    private readonly InputAction m_Default_TeleportCT;
    private readonly InputAction m_Default_Attack;
    private readonly InputAction m_Default_ReturnTeleporter;
    private readonly InputAction m_Default_TeleportAiming;
    private readonly InputAction m_Default_FastFall;
    public struct DefaultActions
    {
        private @PlayerControls m_Wrapper;
        public DefaultActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Default_Move;
        public InputAction @Jump => m_Wrapper.m_Default_Jump;
        public InputAction @TeleportMK => m_Wrapper.m_Default_TeleportMK;
        public InputAction @TeleportCT => m_Wrapper.m_Default_TeleportCT;
        public InputAction @Attack => m_Wrapper.m_Default_Attack;
        public InputAction @ReturnTeleporter => m_Wrapper.m_Default_ReturnTeleporter;
        public InputAction @TeleportAiming => m_Wrapper.m_Default_TeleportAiming;
        public InputAction @FastFall => m_Wrapper.m_Default_FastFall;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnJump;
                @TeleportMK.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTeleportMK;
                @TeleportMK.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTeleportMK;
                @TeleportMK.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTeleportMK;
                @TeleportCT.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTeleportCT;
                @TeleportCT.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTeleportCT;
                @TeleportCT.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTeleportCT;
                @Attack.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnAttack;
                @ReturnTeleporter.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnReturnTeleporter;
                @ReturnTeleporter.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnReturnTeleporter;
                @ReturnTeleporter.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnReturnTeleporter;
                @TeleportAiming.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTeleportAiming;
                @TeleportAiming.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTeleportAiming;
                @TeleportAiming.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnTeleportAiming;
                @FastFall.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFastFall;
                @FastFall.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFastFall;
                @FastFall.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFastFall;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @TeleportMK.started += instance.OnTeleportMK;
                @TeleportMK.performed += instance.OnTeleportMK;
                @TeleportMK.canceled += instance.OnTeleportMK;
                @TeleportCT.started += instance.OnTeleportCT;
                @TeleportCT.performed += instance.OnTeleportCT;
                @TeleportCT.canceled += instance.OnTeleportCT;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @ReturnTeleporter.started += instance.OnReturnTeleporter;
                @ReturnTeleporter.performed += instance.OnReturnTeleporter;
                @ReturnTeleporter.canceled += instance.OnReturnTeleporter;
                @TeleportAiming.started += instance.OnTeleportAiming;
                @TeleportAiming.performed += instance.OnTeleportAiming;
                @TeleportAiming.canceled += instance.OnTeleportAiming;
                @FastFall.started += instance.OnFastFall;
                @FastFall.performed += instance.OnFastFall;
                @FastFall.canceled += instance.OnFastFall;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnTeleportMK(InputAction.CallbackContext context);
        void OnTeleportCT(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnReturnTeleporter(InputAction.CallbackContext context);
        void OnTeleportAiming(InputAction.CallbackContext context);
        void OnFastFall(InputAction.CallbackContext context);
    }
}
