using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float totalEnergy;
    private bool isDeath = false;

    public IEnumerator Damage(int dot)
    {
        while (true && !isDeath)
        {
            totalEnergy -= dot * Time.deltaTime;
            if (totalEnergy <= 0)
            {
                isDeath = true;
            }
            else
                UpdateLife(GameObject.FindGameObjectWithTag("UiPlayer").GetComponent<MenuControl>());
            yield return null;
        }
    }

    private void UpdateLife(MenuControl menuRef)
    {
        menuRef.LifePoints.text = ((int)totalEnergy).ToString();
        menuRef.LifeBar.fillAmount = totalEnergy / 100;
    }
}
