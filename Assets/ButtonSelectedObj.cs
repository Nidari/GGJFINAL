using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectedObj : MonoBehaviour
{
    private RectTransform rt;

    void Start ()
    {
        rt = GetComponent<RectTransform>();

        if (rt.localPosition.x < 0)
        {
            StartCoroutine(GoLeft());
        }
        else
        {
            StartCoroutine(GoRight());
        }
	}
	
    IEnumerator GoLeft()
    {
        float elapsedTime = 0.0f;
        Image image = GetComponent<Image>();
        Color startColor = image.color;

        while (elapsedTime < 3f)
        {
            image.color = Color.Lerp(startColor, new Color(startColor.r, startColor.g, startColor.b, 0), (elapsedTime / 3f));
            rt.transform.localPosition += new Vector3(-40, 0, 0) * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
        yield return null;
        yield return null;
    }

    IEnumerator GoRight()
    {
        float elapsedTime = 0.0f;
        Image image = GetComponent<Image>();
        Color startColor = image.color;

        while (elapsedTime < 3f)
        {
            image.color = Color.Lerp(startColor, new Color(startColor.r, startColor.g, startColor.b, 0), (elapsedTime / 3f));
            rt.transform.localPosition += new Vector3(40, 0, 0) * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
        yield return null;
    }
}
