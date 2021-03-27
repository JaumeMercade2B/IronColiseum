// GENERATED AUTOMATICALLY FROM 'Assets/Projecte/InputActions/PlayerControls.inputactions'

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
            ""name"": ""Gameplay"",
            ""id"": ""cbef15cd-f05d-4557-98a0-d28104cb7746"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b5b8f8d5-6200-47cb-a7b5-d6803b7932f6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4ab32371-39b2-48cf-a848-dd7e6a22e06a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9f86aa27-ae1d-48d2-9736-5285be712ada"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""b6feef25-4aa4-4ba0-ac8d-254776227fc6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""10485650-d9c2-4d9a-8f2a-d927a3877ff3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Mele"",
                    ""type"": ""Button"",
                    ""id"": ""19b7b8d5-9d82-43b1-a338-c227b892b9d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""236d2257-c647-44b0-b3bd-9a2249d1e8a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""4eea97ea-019b-4e2b-942e-b3906d925e52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""ChangeWeaponRight"",
                    ""type"": ""Button"",
                    ""id"": ""611aa966-2e9a-40b1-8e21-f9b2956b3a1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Misil"",
                    ""type"": ""Button"",
                    ""id"": ""4ac07b9a-4182-4d5b-9136-cf238617451e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Automatic Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""827418d9-564d-4b70-a94b-be285d3025a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""StopShoot"",
                    ""type"": ""Button"",
                    ""id"": ""17b21378-72e1-4a90-9b34-00610a9a351c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""OpenInventory"",
                    ""type"": ""Button"",
                    ""id"": ""a965f879-cc2a-43d0-b7e8-cd86fd0b46bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GodMode"",
                    ""type"": ""Button"",
                    ""id"": ""74406d61-a644-4480-a226-442bfc208459"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GodUp"",
                    ""type"": ""Button"",
                    ""id"": ""eb7f0ac1-ad42-4e41-90ee-2c9009e4d8b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GodDown"",
                    ""type"": ""Button"",
                    ""id"": ""a96a486b-44eb-49ba-a711-4c5971260530"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WeaponPlasma"",
                    ""type"": ""Button"",
                    ""id"": ""cdc78076-188a-49e8-ac6f-1d6152f20773"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Metralleta"",
                    ""type"": ""Button"",
                    ""id"": ""e0511ef9-af38-418f-a87a-43c227c404d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Lanza"",
                    ""type"": ""Button"",
                    ""id"": ""641fe674-c5a6-4395-8b1f-a236b02059ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2680f73b-1b6b-4eb7-8e4c-cdb6dbe166e3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81a6fb9f-ce8d-471c-8ee0-71ab19c5b0ea"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""GamePad;Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be26a861-4b78-46b0-931c-fe5c9b64e176"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2469ea4f-fab9-446c-b985-e2097159b5f3"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=10,y=10)"",
                    ""groups"": ""GamePad;Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""ca4a9dd6-5208-4889-98d6-d2539759df7f"",
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
                    ""id"": ""15f9f459-5cf9-4cd6-89ef-c019defffbe0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2789b6b0-ea23-4383-b7a4-bb5d0c3a737e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c4da9d61-2b2d-4369-831b-74f9cfe7448f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""118f9953-d6bf-49c9-92cb-c019d9bd5c8e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""c65b1eb8-5cbb-4ee8-94f4-d252ac469e21"",
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
                    ""id"": ""d872463e-cfbb-4f64-a037-4d09a2464aac"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2441ad31-f3f5-4140-8f56-6985ef21b76a"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""24fc434d-9754-421a-a825-bb8852688ebf"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""380c318c-20cb-48f2-8558-9442c14b08c5"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9148775b-1015-435b-9087-49fe17feb12c"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e2f9ab7-548e-4f49-bca2-2808bad6c624"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad;Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""551657e9-4826-40e7-bbef-65702c944deb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a16ad425-a060-4604-a5e1-67658e8acf20"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad;Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d41dae44-f54f-449b-8a57-d66e1e7a408d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89ef61a6-4774-4b6d-addd-57ad05ed7f96"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad;Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""838451b1-79eb-4d92-ac13-4093a7ef9968"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Mele"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65dca4ce-8f54-4738-863e-d008922259f3"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad;Gamepad"",
                    ""action"": ""Mele"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""626e8a9b-b000-4baa-baf2-498d1ecf0eb1"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2ea6345-7e92-43fa-996a-3543157e4622"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad;Gamepad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77136e18-5b1c-4e10-8474-48b6cf0085a0"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""ChangeWeaponRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15212d4d-7ada-435c-bf7d-874fde038b98"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad;Gamepad"",
                    ""action"": ""ChangeWeaponRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc1806b6-8e78-4ec9-937d-4b91db7bef0a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Misil"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f93b8e93-d404-48db-8e51-16f784572f2e"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad;Gamepad"",
                    ""action"": ""Misil"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbcf3988-ccbe-4934-8449-62b8859e90e2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""Automatic Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0dd14913-22bb-449c-9b0f-874b3f0c64e0"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""GamePad;Gamepad"",
                    ""action"": ""Automatic Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f8eff1c-9c97-4faf-af8a-f7ad2f2bfe74"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""OpenInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e41d5cc4-7a94-4dd7-9da4-f47610f529d1"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""GodMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90637692-4bc8-4b2a-84f1-b318d755984b"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""GodUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""417d7289-de09-4eac-a248-1160fc5641f1"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard + Mouse;MOuse + Keyboard"",
                    ""action"": ""GodDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d15748c9-2140-4eb3-81ee-1ac20596ef62"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""MOuse + Keyboard"",
                    ""action"": ""WeaponPlasma"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00a41793-2867-4fae-a9e5-dbc31db64d2d"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MOuse + Keyboard"",
                    ""action"": ""Metralleta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3f254b2-c615-4427-be94-9e0982d72131"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MOuse + Keyboard"",
                    ""action"": ""Lanza"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""ab125594-1f63-4856-bc78-9410c9b80845"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""f5c410dd-36bd-497f-a80c-43c21ebb3302"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""25b7869a-2475-4f68-bf51-bdc8e619dccc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MOuse + Keyboard"",
            ""bindingGroup"": ""MOuse + Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Look = m_Gameplay.FindAction("Look", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_Mele = m_Gameplay.FindAction("Mele", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_Reload = m_Gameplay.FindAction("Reload", throwIfNotFound: true);
        m_Gameplay_ChangeWeaponRight = m_Gameplay.FindAction("ChangeWeaponRight", throwIfNotFound: true);
        m_Gameplay_Misil = m_Gameplay.FindAction("Misil", throwIfNotFound: true);
        m_Gameplay_AutomaticShoot = m_Gameplay.FindAction("Automatic Shoot", throwIfNotFound: true);
        m_Gameplay_StopShoot = m_Gameplay.FindAction("StopShoot", throwIfNotFound: true);
        m_Gameplay_OpenInventory = m_Gameplay.FindAction("OpenInventory", throwIfNotFound: true);
        m_Gameplay_GodMode = m_Gameplay.FindAction("GodMode", throwIfNotFound: true);
        m_Gameplay_GodUp = m_Gameplay.FindAction("GodUp", throwIfNotFound: true);
        m_Gameplay_GodDown = m_Gameplay.FindAction("GodDown", throwIfNotFound: true);
        m_Gameplay_WeaponPlasma = m_Gameplay.FindAction("WeaponPlasma", throwIfNotFound: true);
        m_Gameplay_Metralleta = m_Gameplay.FindAction("Metralleta", throwIfNotFound: true);
        m_Gameplay_Lanza = m_Gameplay.FindAction("Lanza", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Look;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Dash;
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_Mele;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_Reload;
    private readonly InputAction m_Gameplay_ChangeWeaponRight;
    private readonly InputAction m_Gameplay_Misil;
    private readonly InputAction m_Gameplay_AutomaticShoot;
    private readonly InputAction m_Gameplay_StopShoot;
    private readonly InputAction m_Gameplay_OpenInventory;
    private readonly InputAction m_Gameplay_GodMode;
    private readonly InputAction m_Gameplay_GodUp;
    private readonly InputAction m_Gameplay_GodDown;
    private readonly InputAction m_Gameplay_WeaponPlasma;
    private readonly InputAction m_Gameplay_Metralleta;
    private readonly InputAction m_Gameplay_Lanza;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_Gameplay_Look;
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @Mele => m_Wrapper.m_Gameplay_Mele;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @Reload => m_Wrapper.m_Gameplay_Reload;
        public InputAction @ChangeWeaponRight => m_Wrapper.m_Gameplay_ChangeWeaponRight;
        public InputAction @Misil => m_Wrapper.m_Gameplay_Misil;
        public InputAction @AutomaticShoot => m_Wrapper.m_Gameplay_AutomaticShoot;
        public InputAction @StopShoot => m_Wrapper.m_Gameplay_StopShoot;
        public InputAction @OpenInventory => m_Wrapper.m_Gameplay_OpenInventory;
        public InputAction @GodMode => m_Wrapper.m_Gameplay_GodMode;
        public InputAction @GodUp => m_Wrapper.m_Gameplay_GodUp;
        public InputAction @GodDown => m_Wrapper.m_Gameplay_GodDown;
        public InputAction @WeaponPlasma => m_Wrapper.m_Gameplay_WeaponPlasma;
        public InputAction @Metralleta => m_Wrapper.m_Gameplay_Metralleta;
        public InputAction @Lanza => m_Wrapper.m_Gameplay_Lanza;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Look.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Mele.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMele;
                @Mele.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMele;
                @Mele.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMele;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Reload.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                @ChangeWeaponRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeWeaponRight;
                @ChangeWeaponRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeWeaponRight;
                @ChangeWeaponRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeWeaponRight;
                @Misil.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMisil;
                @Misil.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMisil;
                @Misil.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMisil;
                @AutomaticShoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAutomaticShoot;
                @AutomaticShoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAutomaticShoot;
                @AutomaticShoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAutomaticShoot;
                @StopShoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStopShoot;
                @StopShoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStopShoot;
                @StopShoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStopShoot;
                @OpenInventory.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenInventory;
                @GodMode.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGodMode;
                @GodMode.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGodMode;
                @GodMode.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGodMode;
                @GodUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGodUp;
                @GodUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGodUp;
                @GodUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGodUp;
                @GodDown.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGodDown;
                @GodDown.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGodDown;
                @GodDown.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGodDown;
                @WeaponPlasma.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeaponPlasma;
                @WeaponPlasma.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeaponPlasma;
                @WeaponPlasma.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeaponPlasma;
                @Metralleta.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMetralleta;
                @Metralleta.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMetralleta;
                @Metralleta.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMetralleta;
                @Lanza.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLanza;
                @Lanza.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLanza;
                @Lanza.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLanza;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Mele.started += instance.OnMele;
                @Mele.performed += instance.OnMele;
                @Mele.canceled += instance.OnMele;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @ChangeWeaponRight.started += instance.OnChangeWeaponRight;
                @ChangeWeaponRight.performed += instance.OnChangeWeaponRight;
                @ChangeWeaponRight.canceled += instance.OnChangeWeaponRight;
                @Misil.started += instance.OnMisil;
                @Misil.performed += instance.OnMisil;
                @Misil.canceled += instance.OnMisil;
                @AutomaticShoot.started += instance.OnAutomaticShoot;
                @AutomaticShoot.performed += instance.OnAutomaticShoot;
                @AutomaticShoot.canceled += instance.OnAutomaticShoot;
                @StopShoot.started += instance.OnStopShoot;
                @StopShoot.performed += instance.OnStopShoot;
                @StopShoot.canceled += instance.OnStopShoot;
                @OpenInventory.started += instance.OnOpenInventory;
                @OpenInventory.performed += instance.OnOpenInventory;
                @OpenInventory.canceled += instance.OnOpenInventory;
                @GodMode.started += instance.OnGodMode;
                @GodMode.performed += instance.OnGodMode;
                @GodMode.canceled += instance.OnGodMode;
                @GodUp.started += instance.OnGodUp;
                @GodUp.performed += instance.OnGodUp;
                @GodUp.canceled += instance.OnGodUp;
                @GodDown.started += instance.OnGodDown;
                @GodDown.performed += instance.OnGodDown;
                @GodDown.canceled += instance.OnGodDown;
                @WeaponPlasma.started += instance.OnWeaponPlasma;
                @WeaponPlasma.performed += instance.OnWeaponPlasma;
                @WeaponPlasma.canceled += instance.OnWeaponPlasma;
                @Metralleta.started += instance.OnMetralleta;
                @Metralleta.performed += instance.OnMetralleta;
                @Metralleta.canceled += instance.OnMetralleta;
                @Lanza.started += instance.OnLanza;
                @Lanza.performed += instance.OnLanza;
                @Lanza.canceled += instance.OnLanza;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Click;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_MOuseKeyboardSchemeIndex = -1;
    public InputControlScheme MOuseKeyboardScheme
    {
        get
        {
            if (m_MOuseKeyboardSchemeIndex == -1) m_MOuseKeyboardSchemeIndex = asset.FindControlSchemeIndex("MOuse + Keyboard");
            return asset.controlSchemes[m_MOuseKeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnLook(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMele(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnChangeWeaponRight(InputAction.CallbackContext context);
        void OnMisil(InputAction.CallbackContext context);
        void OnAutomaticShoot(InputAction.CallbackContext context);
        void OnStopShoot(InputAction.CallbackContext context);
        void OnOpenInventory(InputAction.CallbackContext context);
        void OnGodMode(InputAction.CallbackContext context);
        void OnGodUp(InputAction.CallbackContext context);
        void OnGodDown(InputAction.CallbackContext context);
        void OnWeaponPlasma(InputAction.CallbackContext context);
        void OnMetralleta(InputAction.CallbackContext context);
        void OnLanza(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnClick(InputAction.CallbackContext context);
    }
}
