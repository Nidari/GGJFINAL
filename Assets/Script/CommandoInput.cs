using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandoInput : MonoBehaviour
{

    public Camera commandoCamera;
    public bool canUsePower = true;
    public float countdown = 2;
    private Coroutine cooldownCoroutine;
    public GameObject zoomCameraPosition;
    Vector3 positionCommandoCam;
    Vector3 positionTempPlayer;
    public bool isZoomed = false;
    public bool isZooming = false;
    public bool lockedFinished = true;
    public bool isMoving = false;
    public bool lockCamera = false;
    public float phase = 2;


    // Use this for initialization
    void Start()
    {
        positionCommandoCam = commandoCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canUsePower)
        {
            if ((Input.GetButton("Fire1Commando") && !SwitchLogic.isPlayer1Commander) || (Input.GetButton("Fire1Player") && SwitchLogic.isPlayer1Commander))
            {
                Debug.Log("cazzo");
                commandoCamera.cullingMask |= (1 << LayerMask.NameToLayer("CommanderOnly"));
            }
            else
            {
                commandoCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("CommanderOnly"));
            }
        }

        if ((Input.GetButtonDown("Fire2Commando") && !isZooming && !SwitchLogic.isPlayer1Commander)|| (Input.GetButtonDown("Fire2Player") && !isZooming && SwitchLogic.isPlayer1Commander))
        {
            if (!isZoomed)
            {
                StartCoroutine(ZoomCameraCO(positionCommandoCam));
            }
            else
            {
                StartCoroutine(DeZoomCameraCO(positionCommandoCam));
            }

        }
        if ((Input.GetButtonDown("Fire3Commando") && !SwitchLogic.isPlayer1Commander)|| (Input.GetButtonDown("Fire3Player") && SwitchLogic.isPlayer1Commander))
        {
            lockCamera = !lockCamera;

            if (isZoomed && !isZooming && lockCamera)
            {
                StartCoroutine(LockCameraCO());
            }
        }
        if (lockCamera && lockedFinished && !isMoving)
        {
            if (isZoomed && !isZooming)
            {
                commandoCamera.transform.position = zoomCameraPosition.transform.position;
                positionTempPlayer = commandoCamera.transform.position;
            }
        }
    }

    IEnumerator CooldownPowerCommanderCO()
    {
        float timer = countdown;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        canUsePower = true;
        StopAllCoroutines();
    }

    IEnumerator ZoomCameraCO(Vector3 tempPosition)
    {
        float timer = 0;
        isZooming = true;
        while (timer < phase)
        {
            commandoCamera.transform.position = Vector3.Lerp(tempPosition, zoomCameraPosition.transform.position, timer / phase);
            timer += Time.deltaTime;
            yield return null;
        }
        positionTempPlayer = zoomCameraPosition.transform.position;
        isZoomed = true;
        isZooming = false;
    }
    IEnumerator DeZoomCameraCO(Vector3 tempPosition)
    {
        float timer = 0;

        isZooming = true;
        while (timer < phase)
        {
            commandoCamera.transform.position = Vector3.Lerp(positionTempPlayer, tempPosition, timer / phase);
            timer += Time.deltaTime;
            yield return null;
        }
        isZoomed = false;
        isZooming = false;

    }
    IEnumerator LockCameraCO()
    {
        float timer = 0;
        float seconds = 1;

        Vector3 actualCameraPosition = commandoCamera.transform.position;
        lockedFinished = false;
        isMoving = true;
        while (timer < seconds)
        {
               float startingDistance = Vector3.Distance(actualCameraPosition, zoomCameraPosition.transform.position);
            commandoCamera.transform.position = Vector3.Lerp(actualCameraPosition, zoomCameraPosition.transform.position, timer);
            timer += Time.deltaTime;
            yield return null;
        }
        positionTempPlayer = commandoCamera.transform.position;
        isMoving = false;
        lockedFinished = true;

    }
}
//~