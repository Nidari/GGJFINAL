    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{
    public GameObject[] camArray = new GameObject[4];
    private GameObject currentCamGo;
	void Start ()
    {
        currentCamGo = camArray[0];
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {            
            currentCamGo.gameObject.SetActive(false);
            currentCamGo = camArray[0];
            camArray[0].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentCamGo.gameObject.SetActive(false);
            currentCamGo = camArray[1];
            camArray[1].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentCamGo.gameObject.SetActive(false);
            currentCamGo = camArray[2];
            camArray[2].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentCamGo.gameObject.SetActive(false);
            currentCamGo = camArray[3];
            camArray[3].SetActive(true);
        }
    }
}
