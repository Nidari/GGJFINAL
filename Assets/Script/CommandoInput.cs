using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CommandoInput : MonoBehaviour
{

    public Camera commandoCamera;
    public bool canUsePower = true;
    public float countdown = 2;
    private Coroutine cooldownCoroutine;
    public GameObject zoomCameraPosition;
    public GameObject deZoomCamPosGO;
    Vector3 positionCommandoCam;
    Vector3 positionTempPlayer;
    Vector3 dezoomCamPosition;
    public bool isZoomed = false;
    public bool isZooming = false;
    public bool lockedFinished = true;
    public bool isMoving = false;
    public bool lockCamera = false;
    public float phase = 2;
    public Transform playerTr;

    // Use this for initialization
    void Start()
    {
        playerTr = FindObjectOfType<FirstPersonController>().transform;
        positionCommandoCam = commandoCamera.transform.position;
    }

    public bool commandoMovingCam;

    void Update()
    {
        float horizontalCam, verticalCam;
        if (!SwitchLogic.isPlayer1Commander)
        {
            horizontalCam = Input.GetAxis("HorizontalP2");
            verticalCam = Input.GetAxis("VerticalP2");
        }
        else
        {
            horizontalCam = Input.GetAxis("Horizontal");
            verticalCam = Input.GetAxis("Vertical");
        }

        //commandoCamera.transform.LookAt(playerTr);
        commandoCamera.transform.position += new Vector3(horizontalCam, 0, verticalCam) * 5 * Time.deltaTime; 
        

        if (canUsePower)
        {
            if ((Input.GetButtonDown("Fire1Commando") && !SwitchLogic.isPlayer1Commander) || (Input.GetButtonDown("Fire1Player") && SwitchLogic.isPlayer1Commander))
            {
                commandoCamera.cullingMask |= (1 << LayerMask.NameToLayer("CommanderOnly"));
                PlayerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

                if (pc.currentTakeDamage == 0)
                {
                    pc.costantAbilityDotReff = StartCoroutine(pc.AbilityConstantDot());
                }
                pc.currentTakeDamage += pc.damageCoefficient;
            }
            else
            {
                commandoCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("CommanderOnly"));
                PlayerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

                pc.currentTakeDamage -= pc.damageCoefficient;
                if (pc.currentTakeDamage == 0)
                {
                    StopCoroutine(pc.costantAbilityDotReff);
                    StopCoroutine(pc.lifeBarEffect);
                }
            }


        }

        if ((Input.GetButtonDown("Fire2Commando") && !isZooming && !SwitchLogic.isPlayer1Commander)|| (Input.GetButtonDown("Fire2Player") && !isZooming && SwitchLogic.isPlayer1Commander))
        {
            if (!isMoving)
            { 
                if (!isZoomed)
                {
                    dezoomCamPosition = commandoCamera.transform.position;
                    StartCoroutine(ZoomCameraCO(commandoCamera.transform.position));
                }
                else
                {
                    StartCoroutine(DeZoomCameraCO(dezoomCamPosition));
                }
            }
        }
        if ((Input.GetButtonDown("Fire3Commando") && !SwitchLogic.isPlayer1Commander)|| (Input.GetButtonDown("Fire3Player") && SwitchLogic.isPlayer1Commander))
        {

            lockCamera = !lockCamera;
            if (!isZooming && lockCamera)
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
            if (!isZoomed && !isZooming)
            {
                commandoCamera.transform.position = deZoomCamPosGO.transform.position;
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
        Vector3 camActualPosition = commandoCamera.transform.position;
        isZooming = true;
        while (timer < phase)
        {
            if (lockCamera)
            {
                commandoCamera.transform.position = Vector3.Lerp(camActualPosition, deZoomCamPosGO.transform.position, timer / phase);
            }
            else
            {
                commandoCamera.transform.position = Vector3.Lerp(camActualPosition, tempPosition, timer / phase);
            }
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
            if (isZoomed)
            {
                commandoCamera.transform.position = Vector3.Lerp(actualCameraPosition, zoomCameraPosition.transform.position, timer);
                
            }
            else
            {
                commandoCamera.transform.position = Vector3.Lerp(actualCameraPosition, deZoomCamPosGO.transform.position, timer);
                
            }

            timer += Time.deltaTime;
            yield return null;
        }
        positionTempPlayer = commandoCamera.transform.position;
        isMoving = false;
        lockedFinished = true;

    }
}
//~