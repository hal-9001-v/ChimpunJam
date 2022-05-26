//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Input/CharacterMovement.inputactions
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

public partial class @CharacterMovement : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterMovement()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterMovement"",
    ""maps"": [
        {
            ""name"": ""CharacterControllerActionMap"",
            ""id"": ""9346c7e2-2b40-4662-b468-1863d889776f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6e7e92e2-7ec4-4e55-8b65-89820a8881e2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""3e712baf-4dc6-47c8-9ecd-c568d1f2f242"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sword2DVec"",
                    ""type"": ""Value"",
                    ""id"": ""83b5120e-c07d-4129-8480-d5f4fe30300d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DuckAbility"",
                    ""type"": ""Button"",
                    ""id"": ""7acfa77d-c25c-4fe0-80e3-7ce667e2a256"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseSword"",
                    ""type"": ""Button"",
                    ""id"": ""b92d6ed8-6c52-4a05-a9ec-843cb02bb08b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""461aabba-db4b-4ef1-8135-48808e152e63"",
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
                    ""id"": ""b763e2ba-7f67-4b77-843c-34d066175507"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Character"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""73c80dda-0534-48c5-93a5-1f129cc679f3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Character"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c9eebc70-6483-4086-95c0-16ad84110770"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Character"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fa29fb24-a5cd-4f2a-99dd-21440a259e48"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Character"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cd86dfd1-c924-48f8-a43e-b4b27230cce9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Character"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e5fdb1b-cf8e-4db0-8aec-f0a10a461eef"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Character"",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4708daa9-f93f-461e-bc20-40a76e08fb90"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Character"",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""626d204d-c1c6-4298-a0e8-696bf53f74c8"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Character"",
                    ""action"": ""Sword2DVec"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c3344a7-3df9-4e63-8d7e-3245ac47fc51"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Character"",
                    ""action"": ""Sword2DVec"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1abdc61-8c01-423d-9433-2a404141f04c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DuckAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92f6af13-864c-409f-a27a-8b7f17f8e5f5"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DuckAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdef46d6-0db8-41fa-9f8e-6111d2304eea"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseSword"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f0d89a8-6062-4f61-9b1d-0a52e29eeb5a"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseSword"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Character"",
            ""bindingGroup"": ""Character"",
            ""devices"": []
        }
    ]
}");
        // CharacterControllerActionMap
        m_CharacterControllerActionMap = asset.FindActionMap("CharacterControllerActionMap", throwIfNotFound: true);
        m_CharacterControllerActionMap_Move = m_CharacterControllerActionMap.FindAction("Move", throwIfNotFound: true);
        m_CharacterControllerActionMap_Ability = m_CharacterControllerActionMap.FindAction("Ability", throwIfNotFound: true);
        m_CharacterControllerActionMap_Sword2DVec = m_CharacterControllerActionMap.FindAction("Sword2DVec", throwIfNotFound: true);
        m_CharacterControllerActionMap_DuckAbility = m_CharacterControllerActionMap.FindAction("DuckAbility", throwIfNotFound: true);
        m_CharacterControllerActionMap_UseSword = m_CharacterControllerActionMap.FindAction("UseSword", throwIfNotFound: true);
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

    // CharacterControllerActionMap
    private readonly InputActionMap m_CharacterControllerActionMap;
    private ICharacterControllerActionMapActions m_CharacterControllerActionMapActionsCallbackInterface;
    private readonly InputAction m_CharacterControllerActionMap_Move;
    private readonly InputAction m_CharacterControllerActionMap_Ability;
    private readonly InputAction m_CharacterControllerActionMap_Sword2DVec;
    private readonly InputAction m_CharacterControllerActionMap_DuckAbility;
    private readonly InputAction m_CharacterControllerActionMap_UseSword;
    public struct CharacterControllerActionMapActions
    {
        private @CharacterMovement m_Wrapper;
        public CharacterControllerActionMapActions(@CharacterMovement wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CharacterControllerActionMap_Move;
        public InputAction @Ability => m_Wrapper.m_CharacterControllerActionMap_Ability;
        public InputAction @Sword2DVec => m_Wrapper.m_CharacterControllerActionMap_Sword2DVec;
        public InputAction @DuckAbility => m_Wrapper.m_CharacterControllerActionMap_DuckAbility;
        public InputAction @UseSword => m_Wrapper.m_CharacterControllerActionMap_UseSword;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControllerActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControllerActionMapActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControllerActionMapActions instance)
        {
            if (m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnMove;
                @Ability.started -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnAbility;
                @Ability.performed -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnAbility;
                @Ability.canceled -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnAbility;
                @Sword2DVec.started -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnSword2DVec;
                @Sword2DVec.performed -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnSword2DVec;
                @Sword2DVec.canceled -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnSword2DVec;
                @DuckAbility.started -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnDuckAbility;
                @DuckAbility.performed -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnDuckAbility;
                @DuckAbility.canceled -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnDuckAbility;
                @UseSword.started -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnUseSword;
                @UseSword.performed -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnUseSword;
                @UseSword.canceled -= m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface.OnUseSword;
            }
            m_Wrapper.m_CharacterControllerActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Ability.started += instance.OnAbility;
                @Ability.performed += instance.OnAbility;
                @Ability.canceled += instance.OnAbility;
                @Sword2DVec.started += instance.OnSword2DVec;
                @Sword2DVec.performed += instance.OnSword2DVec;
                @Sword2DVec.canceled += instance.OnSword2DVec;
                @DuckAbility.started += instance.OnDuckAbility;
                @DuckAbility.performed += instance.OnDuckAbility;
                @DuckAbility.canceled += instance.OnDuckAbility;
                @UseSword.started += instance.OnUseSword;
                @UseSword.performed += instance.OnUseSword;
                @UseSword.canceled += instance.OnUseSword;
            }
        }
    }
    public CharacterControllerActionMapActions @CharacterControllerActionMap => new CharacterControllerActionMapActions(this);
    private int m_CharacterSchemeIndex = -1;
    public InputControlScheme CharacterScheme
    {
        get
        {
            if (m_CharacterSchemeIndex == -1) m_CharacterSchemeIndex = asset.FindControlSchemeIndex("Character");
            return asset.controlSchemes[m_CharacterSchemeIndex];
        }
    }
    public interface ICharacterControllerActionMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAbility(InputAction.CallbackContext context);
        void OnSword2DVec(InputAction.CallbackContext context);
        void OnDuckAbility(InputAction.CallbackContext context);
        void OnUseSword(InputAction.CallbackContext context);
    }
}
