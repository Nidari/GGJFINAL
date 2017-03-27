using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    private Coroutine sonicDamEff, sonicDistEff, magneticDamEff, magneticDirEff, repulsiveDamEff, repulsiveDirEff, waveLifeEffect;

    public float currentTakeDamage;
    public float damageCoefficient;
    public Coroutine costantAbilityDotReff;
    public Coroutine lifeBarEffect;

    public static bool IsDisturbed, IsInfluencedByForce;
    public static Vector3 influInpu = Vector3.zero;
    public static Quaternion distInput = Quaternion.identity;
    public GameObject menu;
    public static float TotalEnergy = 100;

    public GameObject gameOverPanel;
    public GameObject gameOverPanel1;

    private bool dyingFlag = false;

    private bool damageCd;

    public Coroutine Fantasia(Coroutine co)
    {
        StopCoroutine(co);
        return null;
    }

    private void Update()
    {
        if (TotalEnergy <= 0 && !dyingFlag)
        {
            dyingFlag = true;
            StartCoroutine(dying());
        }
    }

    private IEnumerator dying()
    {
        var timer = 0.0f;

        gameOverPanel.SetActive(true);
        gameOverPanel1.SetActive(true);

        while (timer < 5)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        TotalEnergy = 100;
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider wave)
    {
        switch (wave.gameObject.transform.parent.tag)
        {

            case "SonicWave":
                
                sonicDamEff = StartCoroutine(ConstantDot(wave.GetComponentInParent<SonicWave>().DamagePerSecond));
                sonicDistEff = StartCoroutine(DisturbingEffect(wave.GetComponentInParent<SonicWave>().DisturbingPower));
                waveLifeEffect = StartCoroutine(menu.GetComponent<MenuControl>().CubeSpawn());

                break;
            case "MagneticWave":
                MagneticWave mwTempLink = wave.GetComponentInParent<MagneticWave>();
                magneticDamEff = StartCoroutine(VariableProgressiveDot(mwTempLink.MinDamPerSecond, mwTempLink.gameObject.transform));
                magneticDirEff = StartCoroutine(MagneticDirEffect(mwTempLink.MagneticPower, this.gameObject.transform, mwTempLink.gameObject.transform));
                waveLifeEffect = StartCoroutine(menu.GetComponent<MenuControl>().CubeSpawn());

                break;
            case "ShockWave":
                ShockWave shwTempLink = wave.GetComponentInParent<ShockWave>();
                repulsiveDamEff = StartCoroutine(VariableProgressiveDot(shwTempLink.MinDamPerSecond, shwTempLink.gameObject.transform));
                repulsiveDirEff = StartCoroutine(RepulsiveDirEffect(shwTempLink.RepulsivePower, this.gameObject.transform, shwTempLink.gameObject.GetComponentInChildren<Collider>().transform));
                waveLifeEffect = StartCoroutine(menu.GetComponent<MenuControl>().CubeSpawn());

                break;
        }

    }

    private void OnTriggerExit(Collider wave)
    {

        switch (wave.gameObject.transform.parent.tag)
        {
            case "SonicWave":
                StopCoroutine(sonicDamEff);
                StopCoroutine(sonicDistEff);
                IsDisturbed = false;
                distInput = Quaternion.identity;
                waveLifeEffect = Fantasia(waveLifeEffect);
                break;
            case "MagneticWave":
                StopCoroutine(magneticDamEff);
                StopCoroutine(magneticDirEff);
                IsInfluencedByForce = false;
                influInpu = Vector3.zero;
                waveLifeEffect = Fantasia(waveLifeEffect);
                break;
            case "ShockWave":
                StopCoroutine(repulsiveDamEff);
                StopCoroutine(repulsiveDirEff);
                IsInfluencedByForce = false;
                influInpu = Vector3.zero;
                waveLifeEffect = Fantasia(waveLifeEffect);
                break;
        }

    }

    private IEnumerator DamageCooldown()
    {
        damageCd = true;
        var timer = 0.0f;


        while(timer < 2)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        damageCd = false;
    }

    public IEnumerator AbilityConstantDot()
    {
        if (lifeBarEffect == null)
        {
            lifeBarEffect = StartCoroutine(menu.GetComponent<MenuControl>().CubeSpawn());
        }

        while (true)
        {
            TotalEnergy -= Time.deltaTime * currentTakeDamage;
            yield return null;
        }
    }

    private IEnumerator ConstantDot(float dot)
    {

        while (true)
        {
            TotalEnergy -= Time.deltaTime * dot;
            yield return null;
        }
    }

    private IEnumerator VariableProgressiveDot(float minDot, Transform emissionSource)
    {

        while (true)
        {
            TotalEnergy -= Time.deltaTime * minDot * 1 / ((emissionSource.position - this.gameObject.transform.position).sqrMagnitude);
            yield return null;
        }
    }

    private IEnumerator DisturbingEffect(float distPower)
    {
        IsDisturbed = true;

        Camera fpsCamera = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_Camera;

        while (true)
        {

            var rotationAmount = Random.insideUnitSphere * distPower;
            rotationAmount.z = 0;

            fpsCamera.transform.rotation = Quaternion.Slerp(fpsCamera.transform.rotation, fpsCamera.transform.rotation * Quaternion.Euler(rotationAmount), Time.deltaTime * 3);



            yield return null;
        }

        /*
		while (Quaternion.Angle(Camera.main.transform.rotation, originalCameraRot) > 0.1f)
		{
			Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, originalCameraRot, Time.deltaTime * 3);

			yield return null;
		}
		*/
    }

    private IEnumerator MagneticDirEffect(float pushPower, Transform player, Transform emissionSource)
    {
        IsInfluencedByForce = true;

        while (true)
        {

            influInpu = Vector3.ProjectOnPlane(((emissionSource.position - player.position).normalized * pushPower), Vector3.up);

            yield return null;
        }
    }

    private IEnumerator RepulsiveDirEffect(float pushPower, Transform player, Transform emissionSource)
    {
        IsInfluencedByForce = true;

        while (true)
        {
            influInpu = Vector3.ProjectOnPlane(((player.position - emissionSource.position).normalized * pushPower), Vector3.up);
            yield return null;
        }
    }
}
