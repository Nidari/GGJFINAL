using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubePrefabMovement : MonoBehaviour
{
    private RectTransform rect;

	void Start ()
    {
        rect = GetComponent<RectTransform>();
        StartCoroutine(CubeMovement());
	}

    IEnumerator CubeMovement()
    {
        float elapsedTime = 0.0f;
        Image image = GetComponent<Image>();
        Color startColor = image.color;
        float randomSpeed = Random.Range(40.0f, 200.0f); 
        float randomSpeedy = Random.Range(-20, 20);
        float randonLife = Random.Range(1.0f, 2.5f);
        while (elapsedTime < 2f)
        {
            image.color = Color.Lerp(startColor,new Color (startColor.r,startColor.g,startColor.b,0),(elapsedTime/1f));
            rect.transform.localPosition += new Vector3(randomSpeed, randomSpeedy, 0) * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
