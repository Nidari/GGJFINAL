using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
	private Coroutine sonicDamEff, sonicDistEff, magneticDamEff, magneticDirEff, repulsiveDamEff, repulsiveDirEff, lifeBarEffect;

	public static bool IsDisturbed, IsInfluencedByForce;
	public static Vector3 influInpu = Vector3.zero;
	public static Quaternion distInput = Quaternion.identity;
	public GameObject menu;
	public static float TotalEnergy;

	private void OnTriggerEnter(Collider wave)
    {
      
		switch (wave.gameObject.transform.parent.tag){

			case "SonicWave":
				Debug.Log("Sonic Wave Triggered");
				sonicDamEff = StartCoroutine (ConstantDot (wave.GetComponent<SonicWave> ().DamagePerSecond));
				sonicDistEff = StartCoroutine (DisturbingEffect (wave.GetComponent <SonicWave> ().DisturbingPower));
				lifeBarEffect = StartCoroutine (menu.GetComponent<MenuControl> ().CubeSpawn ());
			    
			    break;
			case "MagneticWave":
				Debug.Log("Magnetic Wave Triggered");
				MagneticWave mwTempLink = wave.GetComponent<MagneticWave> ();
				magneticDamEff = StartCoroutine (VariableProgressiveDot (mwTempLink.MinDamPerSecond, mwTempLink.gameObject.transform));
				magneticDirEff = StartCoroutine (MagneticDirEffect (mwTempLink.MagneticPower, this.gameObject.transform, mwTempLink.gameObject.transform));
				lifeBarEffect = StartCoroutine (menu.GetComponent<MenuControl> ().CubeSpawn ());
				break;
			case "ShockWave":
				Debug.Log("Repulsive Wave Triggered");
				ShockWave shwTempLink = wave.GetComponent <ShockWave> ();
				repulsiveDamEff = StartCoroutine (VariableProgressiveDot (shwTempLink.MinDamPerSecond, shwTempLink.gameObject.transform));
				repulsiveDirEff = StartCoroutine (RepulsiveDirEffect (shwTempLink.RepulsivePower, this.gameObject.transform, shwTempLink.gameObject.transform));
				lifeBarEffect = StartCoroutine (menu.GetComponent<MenuControl> ().CubeSpawn ());
				break;
		}
        
    }

	private void OnTriggerExit(Collider wave)
    {
      
		switch (wave.gameObject.transform.parent.tag){

			case "SonicWave":
				Debug.Log("Sonic Wave Triggered Out");
				StopCoroutine (sonicDamEff);
				StopCoroutine (sonicDistEff);
				IsDisturbed = false;
				distInput = Quaternion.identity;
				StopCoroutine (lifeBarEffect);
				break;
			case "MagneticWave":
				Debug.Log("Magnetic Wave Triggered Out");
				StopCoroutine (magneticDamEff);
				StopCoroutine (magneticDirEff);
				IsInfluencedByForce = false;
				influInpu = Vector3.zero;
				StopCoroutine (lifeBarEffect);
				break;
			case "ShockWave":
				Debug.Log("Repulsive Wave Triggered Out");
				StopCoroutine (repulsiveDamEff);
				StopCoroutine (repulsiveDirEff);
				IsInfluencedByForce = false;
				influInpu = Vector3.zero;
				StopCoroutine (lifeBarEffect);
				break;
		}
        
    }

	private IEnumerator ConstantDot(float dot)
	{

		while(true)
		{
			TotalEnergy -= Time.deltaTime * dot;
		}
	}

	private IEnumerator VariableProgressiveDot(float minDot, Transform emissionSource)
	{

		while(true)
		{
			TotalEnergy -= Time.deltaTime * minDot * 1 / ((emissionSource.position - this.gameObject.transform.position).sqrMagnitude);
		}
	}

	private IEnumerator DisturbingEffect(float distPower)
	{
		IsDisturbed = true;



		while (true)
		{
			var rotationAmount = Random.insideUnitSphere * distPower;
			rotationAmount.z = 0;

			distInput = Quaternion.Slerp(Camera.main.transform.rotation, Camera.main.transform.rotation * Quaternion.Euler(rotationAmount), Time.deltaTime * 3);



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

		while(true)
		{
			influInpu = Vector3.ProjectOnPlane(((emissionSource.position - player.position).normalized * pushPower), Vector3.up);

		}
	}

	private IEnumerator RepulsiveDirEffect(float pushPower, Transform player, Transform emissionSource)
	{
		IsInfluencedByForce = true;

		while(true)
		{
			influInpu  = Vector3.ProjectOnPlane(((emissionSource.position - player.position).normalized * pushPower), Vector3.up);
		}
	}
}
