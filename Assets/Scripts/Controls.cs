// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Aim"",
            ""id"": ""d8739ee8-2be7-4a02-ab6e-a30c3d64e692"",
            ""actions"": [
                {
                    ""name"": ""shoot"",
                    ""type"": ""Button"",
                    ""id"": ""bce41bed-978b-40c8-adff-16c967ca76b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""990814e1-2c0b-4b62-908c-8682e09633b4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PowerUps"",
            ""id"": ""78dfc313-9e0b-41e7-92c0-e3ab9278ee6b"",
            ""actions"": [
                {
                    ""name"": ""AImDash"",
                    ""type"": ""Button"",
                    ""id"": ""dce16884-5cc6-472e-bc40-45afc7cd6186"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GhostFire"",
                    ""type"": ""Button"",
                    ""id"": ""cec77895-3003-4967-9cc7-f7c235357079"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5944fc53-84a0-4167-bd05-13cefe458d87"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AImDash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e0cd8bd-19ba-4a65-a1a4-f1fc680ccbb8"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AImDash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41b814c6-8902-4a65-89d7-096c5ae5f15e"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GhostFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""4bb40eef-913d-4996-922e-feff4a053f8c"",
            ""actions"": [
                {
                    ""name"": ""Left Click"",
                    ""type"": ""Button"",
                    ""id"": ""e9a1b64c-9637-4c36-9c16-4bc65c66e7c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseResume"",
                    ""type"": ""Button"",
                    ""id"": ""1698b82e-09ed-4c33-b0b2-c833c3d5b4af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a873dd40-e46a-4d83-a583-fcbad23efb68"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3c56b11-163a-42ab-80a4-07682ef89a4b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseResume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Aim
        m_Aim = asset.FindActionMap("Aim", throwIfNotFound: true);
        m_Aim_shoot = m_Aim.FindAction("shoot", throwIfNotFound: true);
        // PowerUps
        m_PowerUps = asset.FindActionMap("PowerUps", throwIfNotFound: true);
        m_PowerUps_AImDash = m_PowerUps.FindAction("AImDash", throwIfNotFound: true);
        m_PowerUps_GhostFire = m_PowerUps.FindAction("GhostFire", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_LeftClick = m_UI.FindAction("Left Click", throwIfNotFound: true);
        m_UI_PauseResume = m_UI.FindAction("PauseResume", throwIfNotFound: true);
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

    // Aim
    private readonly InputActionMap m_Aim;
    private IAimActions m_AimActionsCallbackInterface;
    private readonly InputAction m_Aim_shoot;
    public struct AimActions
    {
        private @Controls m_Wrapper;
        public AimActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @shoot => m_Wrapper.m_Aim_shoot;
        public InputActionMap Get() { return m_Wrapper.m_Aim; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AimActions set) { return set.Get(); }
        public void SetCallbacks(IAimActions instance)
        {
            if (m_Wrapper.m_AimActionsCallbackInterface != null)
            {
                @shoot.started -= m_Wrapper.m_AimActionsCallbackInterface.OnShoot;
                @shoot.performed -= m_Wrapper.m_AimActionsCallbackInterface.OnShoot;
                @shoot.canceled -= m_Wrapper.m_AimActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_AimActionsCallbackInterface = instance;
            if (instance != null)
            {
                @shoot.started += instance.OnShoot;
                @shoot.performed += instance.OnShoot;
                @shoot.canceled += instance.OnShoot;
            }
        }
    }
    public AimActions @Aim => new AimActions(this);

    // PowerUps
    private readonly InputActionMap m_PowerUps;
    private IPowerUpsActions m_PowerUpsActionsCallbackInterface;
    private readonly InputAction m_PowerUps_AImDash;
    private readonly InputAction m_PowerUps_GhostFire;
    public struct PowerUpsActions
    {
        private @Controls m_Wrapper;
        public PowerUpsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @AImDash => m_Wrapper.m_PowerUps_AImDash;
        public InputAction @GhostFire => m_Wrapper.m_PowerUps_GhostFire;
        public InputActionMap Get() { return m_Wrapper.m_PowerUps; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PowerUpsActions set) { return set.Get(); }
        public void SetCallbacks(IPowerUpsActions instance)
        {
            if (m_Wrapper.m_PowerUpsActionsCallbackInterface != null)
            {
                @AImDash.started -= m_Wrapper.m_PowerUpsActionsCallbackInterface.OnAImDash;
                @AImDash.performed -= m_Wrapper.m_PowerUpsActionsCallbackInterface.OnAImDash;
                @AImDash.canceled -= m_Wrapper.m_PowerUpsActionsCallbackInterface.OnAImDash;
                @GhostFire.started -= m_Wrapper.m_PowerUpsActionsCallbackInterface.OnGhostFire;
                @GhostFire.performed -= m_Wrapper.m_PowerUpsActionsCallbackInterface.OnGhostFire;
                @GhostFire.canceled -= m_Wrapper.m_PowerUpsActionsCallbackInterface.OnGhostFire;
            }
            m_Wrapper.m_PowerUpsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AImDash.started += instance.OnAImDash;
                @AImDash.performed += instance.OnAImDash;
                @AImDash.canceled += instance.OnAImDash;
                @GhostFire.started += instance.OnGhostFire;
                @GhostFire.performed += instance.OnGhostFire;
                @GhostFire.canceled += instance.OnGhostFire;
            }
        }
    }
    public PowerUpsActions @PowerUps => new PowerUpsActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_LeftClick;
    private readonly InputAction m_UI_PauseResume;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftClick => m_Wrapper.m_UI_LeftClick;
        public InputAction @PauseResume => m_Wrapper.m_UI_PauseResume;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @LeftClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnLeftClick;
                @PauseResume.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseResume;
                @PauseResume.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseResume;
                @PauseResume.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseResume;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @PauseResume.started += instance.OnPauseResume;
                @PauseResume.performed += instance.OnPauseResume;
                @PauseResume.canceled += instance.OnPauseResume;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IAimActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IPowerUpsActions
    {
        void OnAImDash(InputAction.CallbackContext context);
        void OnGhostFire(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnLeftClick(InputAction.CallbackContext context);
        void OnPauseResume(InputAction.CallbackContext context);
    }
}
