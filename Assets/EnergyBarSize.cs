using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarSize : MonoBehaviour
{
    float speed;

	void Start ()
    {
        StartCoroutine(DeltaSize());
        speed = Random.Range(2.0f, 4.0f);
    }

    IEnumerator DeltaSize()
    {
        float elapsedTime = 0.0f;
        float finishTime = Random.Range(0.5f, 2.5f);
        RectTransform rect = GetComponent<RectTransform>();
        float perlinNoise = (Mathf.PerlinNoise(Time.time * speed, 0));

        float deltaX = 0;
        float deltaY = 0;

        if (perlinNoise < 0.25f)
        {
            deltaX = Random.Range(0.0f, 0.05f);
            deltaY = Random.Range(0.0f, 0.05f);
        }
        else if (perlinNoise > 0.25f && perlinNoise <= 0.50f)
        {
            deltaX = Random.Range(-0.05f, 0f);
            deltaY = Random.Range(0.0f, 0.05f);
        }
        else if (perlinNoise > 0.5f && perlinNoise <= 0.75f)
        {
            deltaX = Random.Range(0.0f, 0.05f);
            deltaY = Random.Range(-0.05f, 0f);
        }
        else if (perlinNoise > 0.75f)
        {
            deltaX = Random.Range(-0.05f, 0f);
            deltaY = Random.Range(-0.05f, 0f);
        }
        Vector3 newSize = new Vector3(rect.transform.localScale.x + deltaX, rect.transform.localScale.y + deltaY, 1);
        while (elapsedTime < finishTime)
        {
            rect.transform.localScale = Vector3.Lerp(rect.transform.localScale, newSize, (elapsedTime / finishTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(DeltaSize());
    }
}
