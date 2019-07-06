using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public int id;
    public string inputX;
    public string inputJump;
    public string inputFire;
    public float keyX;
    public float keyJump;
    public float keyFire;
    public bool isJump = false;
    public bool inputEnabled = true;
    private ActorController ac;
	void Awake () {
        ac = GetComponent<ActorController>();
        inputX = "PSLeftJoyStick-X" + id.ToString();
        inputFire = "PsFire" + id.ToString();
        inputJump = "PsJump" + id.ToString();
    }


	void FixedUpdate () {
        if (inputEnabled)
        {
            keyX = Input.GetAxis(inputX);
            keyFire = Input.GetAxis(inputFire);
            keyJump = Input.GetAxis(inputJump);
        }
        
    }
    
}
