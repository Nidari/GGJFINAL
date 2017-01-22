using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour {

    Material material;
	// Use this for initialization
	void Start () {
        material = GetComponent<MeshRenderer>().sharedMaterial;
	}
    float timer = 0;
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime/2;

        if (timer<=1)
        {
            Debug.Log(timer);
            material.SetTextureOffset("_MainTex",new Vector2(0,-Mathf.Pow(timer,2)));
        }
        else
        {
            timer = 0;
        }
	}
}
