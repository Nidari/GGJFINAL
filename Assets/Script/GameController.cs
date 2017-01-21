using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float totalEnergy;

    public IEnumerator Damage(int dot)
    {
        while (true)
        {
            totalEnergy -= dot * Time.deltaTime;
            yield return null;
        }
    }
}
