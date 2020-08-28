// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/ViewerScene_Scripts/Gerneral Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""MouseControl"",
            ""id"": ""5d94f191-6a9d-4489-aec6-89f49b5439d2"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""92058f88-0e1e-41b3-a725-66d271e2d0cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Shift Camera"",
                    ""type"": ""Button"",
                    ""id"": ""5dbf21b3-69b8-4e1c-a349-d81bb09edc40"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=5)""
                },
                {
                    ""name"": ""Button"",
                    ""type"": ""Button"",
                    ""id"": ""ba2f4c0a-a268-4c1f-94b2-85371353400f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=5)""
                },
                {
                    ""name"": ""ZoomCon"",
                    ""type"": ""Value"",
                    ""id"": ""8ab96576-7d89-41e8-86d8-fb3c78734639"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9a674d28-ee6c-43a3-9936-53a410614ed3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f60e012b-2f95-4dd6-a4bc-550ce97ce7cb"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08d78c23-347b-4e74-8fde-b9e914e04c98"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""MultiTap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea02d9ef-aebe-4640-a521-0ce2223966b0"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomCon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MouseControl
        m_MouseControl = asset.FindActionMap("MouseControl", throwIfNotFound: true);
        m_MouseControl_Move = m_MouseControl.FindAction("Move", throwIfNotFound: true);
        m_MouseControl_ShiftCamera = m_MouseControl.FindAction("Shift Camera", throwIfNotFound: true);
        m_MouseControl_Button = m_MouseControl.FindAction("Button", throwIfNotFound: true);
        m_MouseControl_ZoomCon = m_MouseControl.FindAction("ZoomCon", throwIfNotFound: true);
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

    // MouseControl
    private readonly InputActionMap m_MouseControl;
    private IMouseControlActions m_MouseControlActionsCallbackInterface;
    private readonly InputAction m_MouseControl_Move;
    private readonly InputAction m_MouseControl_ShiftCamera;
    private readonly InputAction m_MouseControl_Button;
    private readonly InputAction m_MouseControl_ZoomCon;
    public struct MouseControlActions
    {
        private @PlayerControls m_Wrapper;
        public MouseControlActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MouseControl_Move;
        public InputAction @ShiftCamera => m_Wrapper.m_MouseControl_ShiftCamera;
        public InputAction @Button => m_Wrapper.m_MouseControl_Button;
        public InputAction @ZoomCon => m_Wrapper.m_MouseControl_ZoomCon;
        public InputActionMap Get() { return m_Wrapper.m_MouseControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseControlActions set) { return set.Get(); }
        public void SetCallbacks(IMouseControlActions instance)
        {
            if (m_Wrapper.m_MouseControlActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnMove;
                @ShiftCamera.started -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnShiftCamera;
                @ShiftCamera.performed -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnShiftCamera;
                @ShiftCamera.canceled -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnShiftCamera;
                @Button.started -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnButton;
                @Button.performed -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnButton;
                @Button.canceled -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnButton;
                @ZoomCon.started -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnZoomCon;
                @ZoomCon.performed -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnZoomCon;
                @ZoomCon.canceled -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnZoomCon;
            }
            m_Wrapper.m_MouseControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @ShiftCamera.started += instance.OnShiftCamera;
                @ShiftCamera.performed += instance.OnShiftCamera;
                @ShiftCamera.canceled += instance.OnShiftCamera;
                @Button.started += instance.OnButton;
                @Button.performed += instance.OnButton;
                @Button.canceled += instance.OnButton;
                @ZoomCon.started += instance.OnZoomCon;
                @ZoomCon.performed += instance.OnZoomCon;
                @ZoomCon.canceled += instance.OnZoomCon;
            }
        }
    }
    public MouseControlActions @MouseControl => new MouseControlActions(this);
    public interface IMouseControlActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShiftCamera(InputAction.CallbackContext context);
        void OnButton(InputAction.CallbackContext context);
        void OnZoomCon(InputAction.CallbackContext context);
    }
}
