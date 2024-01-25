//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Settings/InputActions.inputactions
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

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Setup"",
            ""id"": ""03742d69-f2de-4b77-8de9-980e682b0df4"",
            ""actions"": [
                {
                    ""name"": ""Pointer Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""e6863514-a82e-4917-9763-dba384d5be85"",
                    ""expectedControlType"": ""Delta"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate CCW"",
                    ""type"": ""Button"",
                    ""id"": ""d3f928c8-2e8f-4bf5-a15c-4158dc1dcd4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate CW"",
                    ""type"": ""Button"",
                    ""id"": ""494a28ef-9d4b-427a-a678-a7e6c9eaf9e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cb5d5bff-36c7-42b1-b05a-52fb3e69da48"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65cbe96c-e7e5-4a9a-bc11-48fa2867e832"",
                    ""path"": ""<Touchscreen>/touch1/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75998c61-43c2-4d87-b77a-1c18944877eb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CCW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""517fc2b2-288a-47e8-b745-794704183634"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CCW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""740a6e76-646b-4ef9-85d6-7a7ce99b875e"",
                    ""path"": ""<Mouse>/backButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CCW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""554dcbff-fd44-47cc-bdbb-8e52963b8b06"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CCW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93b74154-0ca4-417d-9725-bc6d3dce3bc8"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CCW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a1e6e56-3056-4bd6-b46d-f4a053a9258d"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CCW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f17937b3-4eec-48e6-a357-b5c1cb672abc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""689b94c9-ebbc-4858-b1c7-ffec4c6b44d8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdab88ca-08c5-47b7-995b-4efeee2b01d9"",
                    ""path"": ""<Mouse>/forwardButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9531a0cb-77a0-43ee-906e-e2bb51c1a780"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58fe7193-c17d-4f5a-8df4-42440f8f39b5"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6671525d-b94a-4cc0-9538-15b79d079bcf"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9320320e-fdd7-4569-ac78-d4ca23b5a5e3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""801e213e-f3d0-41ce-942a-bdb677e2fad2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate CW"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Setup
        m_Setup = asset.FindActionMap("Setup", throwIfNotFound: true);
        m_Setup_PointerRotate = m_Setup.FindAction("Pointer Rotate", throwIfNotFound: true);
        m_Setup_RotateCCW = m_Setup.FindAction("Rotate CCW", throwIfNotFound: true);
        m_Setup_RotateCW = m_Setup.FindAction("Rotate CW", throwIfNotFound: true);
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

    // Setup
    private readonly InputActionMap m_Setup;
    private List<ISetupActions> m_SetupActionsCallbackInterfaces = new List<ISetupActions>();
    private readonly InputAction m_Setup_PointerRotate;
    private readonly InputAction m_Setup_RotateCCW;
    private readonly InputAction m_Setup_RotateCW;
    public struct SetupActions
    {
        private @InputActions m_Wrapper;
        public SetupActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PointerRotate => m_Wrapper.m_Setup_PointerRotate;
        public InputAction @RotateCCW => m_Wrapper.m_Setup_RotateCCW;
        public InputAction @RotateCW => m_Wrapper.m_Setup_RotateCW;
        public InputActionMap Get() { return m_Wrapper.m_Setup; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SetupActions set) { return set.Get(); }
        public void AddCallbacks(ISetupActions instance)
        {
            if (instance == null || m_Wrapper.m_SetupActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SetupActionsCallbackInterfaces.Add(instance);
            @PointerRotate.started += instance.OnPointerRotate;
            @PointerRotate.performed += instance.OnPointerRotate;
            @PointerRotate.canceled += instance.OnPointerRotate;
            @RotateCCW.started += instance.OnRotateCCW;
            @RotateCCW.performed += instance.OnRotateCCW;
            @RotateCCW.canceled += instance.OnRotateCCW;
            @RotateCW.started += instance.OnRotateCW;
            @RotateCW.performed += instance.OnRotateCW;
            @RotateCW.canceled += instance.OnRotateCW;
        }

        private void UnregisterCallbacks(ISetupActions instance)
        {
            @PointerRotate.started -= instance.OnPointerRotate;
            @PointerRotate.performed -= instance.OnPointerRotate;
            @PointerRotate.canceled -= instance.OnPointerRotate;
            @RotateCCW.started -= instance.OnRotateCCW;
            @RotateCCW.performed -= instance.OnRotateCCW;
            @RotateCCW.canceled -= instance.OnRotateCCW;
            @RotateCW.started -= instance.OnRotateCW;
            @RotateCW.performed -= instance.OnRotateCW;
            @RotateCW.canceled -= instance.OnRotateCW;
        }

        public void RemoveCallbacks(ISetupActions instance)
        {
            if (m_Wrapper.m_SetupActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISetupActions instance)
        {
            foreach (var item in m_Wrapper.m_SetupActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SetupActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SetupActions @Setup => new SetupActions(this);
    public interface ISetupActions
    {
        void OnPointerRotate(InputAction.CallbackContext context);
        void OnRotateCCW(InputAction.CallbackContext context);
        void OnRotateCW(InputAction.CallbackContext context);
    }
}
