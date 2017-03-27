using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLogic : MonoBehaviour
{
    //Player 1 = fps false  Player 2 =fps true
    public static bool isPlayer1Commander = false;
    public Camera playerCam, commanderCam;


    bool firstSwap = false;
    bool secondSwap = false;
    bool thirdSwap = false;
    bool fourthSwap = false;


    public void Switch()
    {
        isPlayer1Commander = !isPlayer1Commander;
        if (playerCam.targetDisplay == 0)
        {
            playerCam.targetDisplay = 1;
            commanderCam.targetDisplay = 0;
        }
        else
        {
            playerCam.targetDisplay = 0;
            commanderCam.targetDisplay = 1;
        }
    }
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.S)) { }

        //CheckGameStatus();
    }

    public static float pulseFrequency=1;

    public void CheckGameStatus()
    {
        pulseFrequency = (PlayerController.TotalEnergy % 20 / 20);


        if (PlayerController.TotalEnergy >= 60 && PlayerController.TotalEnergy < 80)
        {
            
            if (!firstSwap)
            {
                Debug.Log("Una volta uno");
                firstSwap = true;
                Switch();
            }
            
        }

        else if (PlayerController.TotalEnergy >= 40 && PlayerController.TotalEnergy < 60)
        {
            if (!secondSwap)
            {
                Debug.Log("Una volta due");
                secondSwap = true;
                Switch();
            }
            
        }

        else if (PlayerController.TotalEnergy >= 20 && PlayerController.TotalEnergy < 40)
        {
            if (!thirdSwap)
            {
                Debug.Log("Una volta tre");
                thirdSwap = true;
                Switch();
            }
        }

        else if (PlayerController.TotalEnergy > 00 && PlayerController.TotalEnergy < 20)
        {
            if (!fourthSwap)
            {
                Debug.Log("Una volta quattro");
                fourthSwap = true;
                Switch();
            }
        }
        else if (PlayerController.TotalEnergy < 0)
        {
            //GameOver();
            Debug.Log("GameOver da Implementare");
        }
    }
}
