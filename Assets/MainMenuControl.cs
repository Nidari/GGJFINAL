using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public float animationSpeed;
    public Sprite[] spriteFrames;
    public GameObject[] mainMenuButton;

	void Start ()
    {
        StartCoroutine(PlayAnim());
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

	}
	
    IEnumerator PlayAnim()
    {


        Image image = GetComponent<Image>();
        for (int i = 0; i < spriteFrames.Length; i++)
        {
            image.sprite = spriteFrames[i];
            Debug.Log(spriteFrames);
            Debug.Log(spriteFrames.Length);
            yield return new WaitForSeconds(animationSpeed);
        }

        foreach (var button in mainMenuButton)
        {
            button.SetActive(true);
        }

        mainMenuButton[0].GetComponent<Button>().Select();
    }

    public void StartGame()
    {
        Image image = GetComponent<Image>();
        image.sprite = spriteFrames[0];
        SceneManager.LoadScene("TestMove");
    }

    //public void Credit()
    //{
    //    SceneManager.LoadScene("Credit");
    //}

    public void Exit()
    {
        Application.Quit();
    }
}
