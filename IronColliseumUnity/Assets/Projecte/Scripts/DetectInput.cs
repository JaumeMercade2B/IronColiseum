using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class DetectInput : MonoBehaviour
{
    public bool changedInput;
    public bool gamepadActive;

    private PlayerControls controls = null;
    public PlayerInput player;
   

    

    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();

    }

    // Update is called once per frame
    void Update()
    {
        if (player.currentControlScheme == "Gamepad")
        {
            gamepadActive = true;
        }
        else if (player.currentControlScheme == "MOuse + Keyboard")
        {
            gamepadActive = false;
        }
        Debug.Log(player.currentControlScheme);
    }

    //public void Input()
    //{
    //    gamepadActive = !gamepadActive;
    //}

    //public void OnControlsChanged(PlayerInput input)
    //{
    //    if (input.currentControlScheme.ToLower() == "Gamepad")
    //    {
    //        gamepadActive = true;
    //    }
    //    else if (input.currentControlScheme.ToLower() == "MOuse + Keyboard")
    //    {
    //        gamepadActive = false;
    //    }
    //}


}
