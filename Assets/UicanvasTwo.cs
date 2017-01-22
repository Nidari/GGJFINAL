using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UicanvasTwo : MonoBehaviour
{
    public Image lifeBar2;
    public Image lifeBar;

    void Update ()
    {
        lifeBar.fillAmount = lifeBar2.fillAmount;
	}
}
