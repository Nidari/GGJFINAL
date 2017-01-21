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
        if (Input.GetKeyDown(KeyCode.S))
        {
            Switch();
        }
    }
}
