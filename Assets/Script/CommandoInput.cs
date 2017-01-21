using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandoInput : MonoBehaviour {

    public Camera commandoCamera;
    public bool canUsePower = true;
    public float countdown = 2;
    private Coroutine cooldownCoroutine;
    // Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1Commando") && canUsePower)
        {
            commandoCamera.cullingMask |= (1 << LayerMask.NameToLayer("CommanderOnly"));
        }
        else
        {
            commandoCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("CommanderOnly"));
        }
        if (Input.GetButtonUp("Fire1Commando")) 
        {
           cooldownCoroutine = StartCoroutine(CooldownPowerCommanderCO());
            canUsePower = false;
        }
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("sono il player coglione");
        }
	}

    IEnumerator CooldownPowerCommanderCO()
    {
        float timer = countdown;
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        canUsePower = true;
        StopAllCoroutines();
    }
}
//~