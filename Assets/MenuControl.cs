using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public Image LifeBar;
    private RectTransform lifeBarRect;
    public Text LifePoints;

    public RectTransform cubeSpawner;

    public bool isDamaging = false;
    public GameObject cubePrefab;
    private float energyImageWidth;
    private float timer;
    public Text timeText;

    void Start()
    {
        lifeBarRect = LifeBar.GetComponent<RectTransform>();
        StartCoroutine(CubeSpawn());
    }

    void Update()
    {
        energyImageWidth = lifeBarRect.rect.width * LifeBar.fillAmount ;
        cubeSpawner.anchoredPosition = new Vector3(energyImageWidth, 0,0);
        timer += Time.deltaTime;
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = Mathf.Floor(timer % 60).ToString("00");
        timeText.text = minutes + ":" + seconds;
    }

    public IEnumerator CubeSpawn()
    {
        while (true)
        {
            GameObject go = Instantiate(cubePrefab);
            go.transform.SetParent(cubeSpawner);
            RectTransform rt = go.GetComponent<RectTransform>();
            float rand = Random.Range(2f, 10f);
            rt.sizeDelta = new Vector2(rand, rand);
            rt.localPosition = new Vector3(0,Random.Range(-5f,5f),0);
            yield return new WaitForSeconds(Random.Range(0.02f, 0.2f));
        }

    }
}
