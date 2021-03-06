//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Input System Assets/Light Saber/Light Saber Controls.inputactions
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

namespace Controllers
{
    public partial class @LightSaberControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @LightSaberControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Light Saber Controls"",
    ""maps"": [
        {
            ""name"": ""Light Saber"",
            ""id"": ""b170d5a3-c320-4593-a02e-7ea669bcacbb"",
            ""actions"": [
                {
                    ""name"": ""ToggleOn"",
                    ""type"": ""Button"",
                    ""id"": ""6ef72915-8041-4173-a1cf-617e7dafdf88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleOff"",
                    ""type"": ""Button"",
                    ""id"": ""089ff290-fff8-4d0e-b02f-047131f73fec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a487d667-e92c-469f-9054-fee213c960dc"",
                    ""path"": ""<OculusTouchController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8efe0fb-2f40-4a53-9b03-8019bb1b9791"",
                    ""path"": ""<OculusTouchController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Light Saber
            m_LightSaber = asset.FindActionMap("Light Saber", throwIfNotFound: true);
            m_LightSaber_ToggleOn = m_LightSaber.FindAction("ToggleOn", throwIfNotFound: true);
            m_LightSaber_ToggleOff = m_LightSaber.FindAction("ToggleOff", throwIfNotFound: true);
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

        // Light Saber
        private readonly InputActionMap m_LightSaber;
        private ILightSaberActions m_LightSaberActionsCallbackInterface;
        private readonly InputAction m_LightSaber_ToggleOn;
        private readonly InputAction m_LightSaber_ToggleOff;
        public struct LightSaberActions
        {
            private @LightSaberControls m_Wrapper;
            public LightSaberActions(@LightSaberControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @ToggleOn => m_Wrapper.m_LightSaber_ToggleOn;
            public InputAction @ToggleOff => m_Wrapper.m_LightSaber_ToggleOff;
            public InputActionMap Get() { return m_Wrapper.m_LightSaber; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LightSaberActions set) { return set.Get(); }
            public void SetCallbacks(ILightSaberActions instance)
            {
                if (m_Wrapper.m_LightSaberActionsCallbackInterface != null)
                {
                    @ToggleOn.started -= m_Wrapper.m_LightSaberActionsCallbackInterface.OnToggleOn;
                    @ToggleOn.performed -= m_Wrapper.m_LightSaberActionsCallbackInterface.OnToggleOn;
                    @ToggleOn.canceled -= m_Wrapper.m_LightSaberActionsCallbackInterface.OnToggleOn;
                    @ToggleOff.started -= m_Wrapper.m_LightSaberActionsCallbackInterface.OnToggleOff;
                    @ToggleOff.performed -= m_Wrapper.m_LightSaberActionsCallbackInterface.OnToggleOff;
                    @ToggleOff.canceled -= m_Wrapper.m_LightSaberActionsCallbackInterface.OnToggleOff;
                }
                m_Wrapper.m_LightSaberActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ToggleOn.started += instance.OnToggleOn;
                    @ToggleOn.performed += instance.OnToggleOn;
                    @ToggleOn.canceled += instance.OnToggleOn;
                    @ToggleOff.started += instance.OnToggleOff;
                    @ToggleOff.performed += instance.OnToggleOff;
                    @ToggleOff.canceled += instance.OnToggleOff;
                }
            }
        }
        public LightSaberActions @LightSaber => new LightSaberActions(this);
        public interface ILightSaberActions
        {
            void OnToggleOn(InputAction.CallbackContext context);
            void OnToggleOff(InputAction.CallbackContext context);
        }
    }
}
