using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Coroutine Effect;

  
	private void OnTriggerEnter(Collider wave)
    {
      
		switch (wave.gameObject.tag){

			case "SonicWave":
				Effect = StartCoroutine (ShockingDamage (wave.GetComponent<SonicWave> ().DamagePerSecond));
			    break;
			case "MagneticWave":
				break;
			case "ShockWave":
				break;
		}
        
    }

	private void OnTriggerExit(Collider wave)
    {
      
		switch (wave.gameObject.tag){

			case "SonicWave":
				break;
			case "MagneticWave":
				break;
			case "ShockWave":
				break;
		}
        
    }

	private IEnumerator ShockingDamage(float dot)
	{
		while(true){
			
		}
	}
}
