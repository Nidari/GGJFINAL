using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandoInput : MonoBehaviour {

    public Camera commandoCamera;

    // Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1Commando"))
        {
            commandoCamera.cullingMask |= (1 << LayerMask.NameToLayer("CommanderOnly"));
        }
        else
        {
            commandoCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("CommanderOnly"));
        }
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("sono il player coglione");
        }
	}
}
//~