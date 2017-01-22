using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLogic : MonoBehaviour
{
    //Player 1 = fps false  Player 2 =fps true
    public static bool isPlayer1Commander = false;
    public Camera playerCam, commanderCam;

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
        CheckGameStatus();
    }

    public static float pulseFrequency=1;

    public void CheckGameStatus()
    {
        bool firstSwap = false;
        bool secondSwap = false;
        bool thirdSwap = false;
        bool fourthSwap = false;

        pulseFrequency = 1-(PlayerController.TotalEnergy % 20 / 20);


        if (PlayerController.TotalEnergy >= 60 && PlayerController.TotalEnergy < 80)
        {
            
            if (!firstSwap)
            {
                Switch();
            }
            firstSwap = true;
        }

        else if (PlayerController.TotalEnergy >= 0 && PlayerController.TotalEnergy < 60)
        {
            if (!secondSwap)
            {
                Switch();
            }
            secondSwap = true;
        }

        else if (PlayerController.TotalEnergy >= 20 && PlayerController.TotalEnergy < 40)
        {
            if (!thirdSwap)
            {
                Switch();
            }
            thirdSwap = true;
        }

        else if (PlayerController.TotalEnergy > 00 && PlayerController.TotalEnergy < 20)
        {
            if (!fourthSwap)
            {
                Switch();
            }
            fourthSwap = true;
        }
        else if (PlayerController.TotalEnergy < 0)
        {
            //GameOver();
            Debug.Log("GameOver da Implementare");
        }
    }
}
