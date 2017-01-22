using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicWave : MonoBehaviour {

	public float DamagePerSecond;
	public float DisturbingPower;

	public GameObject[] particleObjects;

	private void OnValidate(){

		float x = this.gameObject.transform.localScale.x;
		float y = this.gameObject.transform.localScale.y;
		float z = this.gameObject.transform.localScale.z;

		var objScale = new Vector3 (x, y, z);

		if (particleObjects != null)
		{
			for (int i = 0; i < particleObjects.Length; i++)
			{
				particleObjects [i].transform.localScale = objScale;
			}
		}

		if (!this.gameObject.CompareTag ("SonicWave"))
			this.gameObject.tag = "SonicWave";
	}

	[ExecuteInEditMode]
	private void Update(){

		float x = this.gameObject.transform.localScale.x;
		float y = this.gameObject.transform.localScale.y;
		float z = this.gameObject.transform.localScale.z;

		var objScale = new Vector3 (x, y, z);

		if (particleObjects != null)
		{
			for (int i = 0; i < particleObjects.Length; i++)
			{
				particleObjects [i].transform.localScale = objScale;
			}
		}

		if (!this.gameObject.CompareTag ("SonicWave"))
			this.gameObject.tag = "SonicWave";
	}
}
