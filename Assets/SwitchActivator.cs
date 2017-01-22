using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivator : MonoBehaviour {

    Material material;

    float timer = 0;
    // Update is called once per frame

    Color startColor;
    Animator anim;
    // Use this for initialization
    void Start ()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
        startColor = material.GetColor("_EmissionColor");
       // StartCoroutine(ChangeColor(Color.red));


    }

    bool increasing = true;
    // Update is called once per frame



    IEnumerator ChangeColor(Color baseColor)
    {
     
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;
        float elapsedTime = 0.0f;
        while (elapsedTime < 2)
        {
            float emission = Mathf.PingPong(Time.time, 1);
            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
            mat.SetColor("_EmissionColor", finalColor);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if (PlayerController.TotalEnergy >= 90)
        {
            StartCoroutine(ChangeColor(new Color(0 / 4733f, 0.208f, 0.78f)));    
        }
        else if (PlayerController.TotalEnergy >= 80 && PlayerController.TotalEnergy < 90)
        {
            StartCoroutine(ChangeColor(new Color(0.977f, 0.077f, 0.266f)));
        }
        else if (PlayerController.TotalEnergy >= 70 && PlayerController.TotalEnergy < 80)
        {
            StartCoroutine(ChangeColor(new Color(0, 0, 0.8f)));
        }
        else if (PlayerController.TotalEnergy >= 60 && PlayerController.TotalEnergy < 70)
        {
            StartCoroutine(ChangeColor(new Color(0, 0, 0.8f)));
        }
        else if (PlayerController.TotalEnergy >= 50 && PlayerController.TotalEnergy < 60)
        {
            StartCoroutine(ChangeColor(new Color(0, 0, 0.8f)));
        }
        else if (PlayerController.TotalEnergy >= 40 && PlayerController.TotalEnergy < 50)
        {
            StartCoroutine(ChangeColor(new Color(0, 0, 0.8f)));
        }
        else if (PlayerController.TotalEnergy >= 30 && PlayerController.TotalEnergy < 40)
        {
            StartCoroutine(ChangeColor(new Color(0, 0, 0.8f)));
        }
        else if (PlayerController.TotalEnergy >= 20 && PlayerController.TotalEnergy < 30)
        {
            StartCoroutine(ChangeColor(new Color(0, 0, 0.8f)));
        }
        else if (PlayerController.TotalEnergy >= 10 && PlayerController.TotalEnergy < 20)
        {
            StartCoroutine(ChangeColor(new Color(0, 0, 0.8f)));
        }
        else if (PlayerController.TotalEnergy >= 00 && PlayerController.TotalEnergy < 10)
        {
            StartCoroutine(ChangeColor(new Color(0, 0, 0.8f)));
        }
    }
	}

