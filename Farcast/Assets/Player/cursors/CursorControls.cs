// GENERATED AUTOMATICALLY FROM 'Assets/Player/cursors/CursorControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CursorControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CursorControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CursorControls"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""9886101b-48be-42a4-af5b-165334d367ef"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""bf11bbf1-11f9-4767-aa9b-64b24e5e1c4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""5bd27d8f-9a62-46f3-835e-0e7e53b53581"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""176ac725-de76-40bc-9d7f-1f674137f58e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dd14c850-e3d9-4f41-aa52-2db9e82c11ae"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""152e9265-ecd6-455b-96b8-1d0e97d368d6"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33688857-0676-4893-872b-1e8f00a66f3e"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Movement"",
            ""id"": ""a712af37-0de9-4fe1-8e82-965fe1cfbc67"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Button"",
                    ""id"": ""1a613111-9db0-4a4e-9f8f-a24af9d662c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""04f741f6-98f9-4a7d-878e-c14399559fd4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2bf8c41b-d93e-48b6-bbe4-b9017bc66c25"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ad0bcd04-7498-467a-acf4-6890b89dad71"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""13366f1e-e54f-48f1-b678-d6e19a99eb67"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5ebb5236-a3ad-43e1-94b8-29ced0bf57f2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_Interact = m_Mouse.FindAction("Interact", throwIfNotFound: true);
        m_Mouse_Attack = m_Mouse.FindAction("Attack", throwIfNotFound: true);
        m_Mouse_Inventory = m_Mouse.FindAction("Inventory", throwIfNotFound: true);
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_move = m_Movement.FindAction("move", throwIfNotFound: true);
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

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_Interact;
    private readonly InputAction m_Mouse_Attack;
    private readonly InputAction m_Mouse_Inventory;
    public struct MouseActions
    {
        private @CursorControls m_Wrapper;
        public MouseActions(@CursorControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Mouse_Interact;
        public InputAction @Attack => m_Wrapper.m_Mouse_Attack;
        public InputAction @Inventory => m_Wrapper.m_Mouse_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnInteract;
                @Attack.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnAttack;
                @Inventory.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_move;
    public struct MovementActions
    {
        private @CursorControls m_Wrapper;
        public MovementActions(@CursorControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_Movement_move;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMouseActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
    }
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
