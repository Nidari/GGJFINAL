using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject winPanel1;

    void OnTriggerEnter(Collider col)
    {
        StartCoroutine(VictoryCO());
    }

    private IEnumerator VictoryCO()
    {
        var timer = 0.0f;

        winPanel.SetActive(true);
        winPanel1.SetActive(true);

        while (timer < 5)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(0);
    }
}
