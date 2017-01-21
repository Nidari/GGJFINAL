using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject selectedButton;

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

        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            transform.Find("PauseMenu").gameObject.SetActive(true);
            transform.Find("PauseMenu").transform.GetChild(0).GetComponent<Button>().Select();
            Time.timeScale = 0;
        }
    }

    public IEnumerator CubeSpawn()
    {
        while (true)
        {
            GameObject go = Instantiate(cubePrefab);
            go.transform.SetParent(cubeSpawner);
            RectTransform rt = go.GetComponent<RectTransform>();
            float rand = Random.Range(4f, 25f);
            rt.sizeDelta = new Vector2(rand, rand);
            rt.localPosition = new Vector3(0,Random.Range(-25f,25f),0);
            float min = 0.62f - (0.6f - (0.6f * LifeBar.fillAmount));
            float max = 0.84f - (0.8f - (0.8f * LifeBar.fillAmount));

            yield return new WaitForSeconds(Random.Range(min, max));
        }

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        transform.Find("PauseMenu").gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }




}
