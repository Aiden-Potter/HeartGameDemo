using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {


    public string inputX;
    
    public float keyX;

    public bool isJump = false;
    public bool inputEnabled = true;
    private ActorController ac;
	void Awake () {
        ac = GetComponent<ActorController>();
	}
	
	void FixedUpdate () {
        if (inputEnabled)
        {
            keyX = Input.GetAxis(inputX);
            if (Input.GetKeyDown(KeyCode.Joystick1Button1)&& ac.onGround)
            {
                isJump = true;
            }
            else
            {
                isJump = false;
            }
        }
        
    }
    
}
