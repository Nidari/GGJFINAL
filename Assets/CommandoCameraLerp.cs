using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandoCameraLerp : MonoBehaviour
{
    bool cameraToMove;
    public Transform nextRoomTr;
    private Vector3 startPos;
    float timer = 0;
    Transform cameraTr;
    // Use this for initialization
    void OnTriggerEnter (Collider coll)
    {
    
        cameraTr = GameObject.FindGameObjectWithTag("CommanderCam").transform;
        startPos = cameraTr.position;
        cameraToMove = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (cameraToMove)
        {
            timer += Time.deltaTime;
            cameraTr.position = Vector3.Lerp(startPos, nextRoomTr.position, timer);
        }
	}
}
