﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivator : MonoBehaviour {

    Material material;
<<<<<<< HEAD
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
=======
    Color startColor;
    Animator anim;
    // Use this for initialization
    void Start ()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
        startColor = material.GetColor("_EmissionColor");
        StartCoroutine(ChangeColor(new Color(0, 1, 0)));

         
    }
    float timer = 0;
    
    bool increasing = true;
    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerController.TotalEnergy -= 1;
        }

    }


    IEnumerator ChangeColor(Color baseColor)
    {
        Debug.Log(SwitchLogic.pulseFrequency);
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;
        float elapsedTime = 0.0f;
        while (elapsedTime < 2)
        {
            float emission = Mathf.PingPong(Time.time, 1.2f);
            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
            mat.SetColor("_EmissionColor", finalColor);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if (PlayerController.TotalEnergy >= 90)
        {
            StartCoroutine(ChangeColor(new Color(0, 1, 0)));
        }
        else if (PlayerController.TotalEnergy >= 80 && PlayerController.TotalEnergy < 90)
        {
            StartCoroutine(ChangeColor(Color.red));
        }
        else if (PlayerController.TotalEnergy >= 70 && PlayerController.TotalEnergy < 80)
        {
            StartCoroutine(ChangeColor(Color.red));
        }
        else if (PlayerController.TotalEnergy >= 60 && PlayerController.TotalEnergy < 70)
        {
            StartCoroutine(ChangeColor(Color.red));
        }
        else if (PlayerController.TotalEnergy >= 50 && PlayerController.TotalEnergy < 60)
        {
            StartCoroutine(ChangeColor(Color.red));
        }
        else if (PlayerController.TotalEnergy >= 40 && PlayerController.TotalEnergy < 50)
        {
            StartCoroutine(ChangeColor(Color.red));
        }
        else if (PlayerController.TotalEnergy >= 30 && PlayerController.TotalEnergy < 40)
        {
            StartCoroutine(ChangeColor(Color.red));
        }
        else if (PlayerController.TotalEnergy >= 20 && PlayerController.TotalEnergy < 30)
        {
            StartCoroutine(ChangeColor(Color.red));
        }
        else if (PlayerController.TotalEnergy >= 10 && PlayerController.TotalEnergy < 20)
>>>>>>> 3e49ba0dc8fd098afb44e45382efa527b98ac93b
        {
            StartCoroutine(ChangeColor(Color.red));
        }
        else if (PlayerController.TotalEnergy >= 00 && PlayerController.TotalEnergy < 10)
        {
            StartCoroutine(ChangeColor(Color.red));
        }
<<<<<<< HEAD
	}
=======
    }
>>>>>>> 3e49ba0dc8fd098afb44e45382efa527b98ac93b
}
