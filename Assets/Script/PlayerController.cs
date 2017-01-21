using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameController gc;
    private Coroutine coroutineDamage;

    void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter(Collider col)
    {
        WaveController wc = col.GetComponent<WaveController>();
        coroutineDamage = StartCoroutine(gc.Damage(wc.dot));
    }

    void OnTriggerExit(Collider col)
    {
        StopCoroutine(coroutineDamage);
    }


}
