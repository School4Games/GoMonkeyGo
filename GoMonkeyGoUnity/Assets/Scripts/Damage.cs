using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	
	private Health health;

	void awake (){
		health = GameObject.Find("Health").GetComponent<Health> ();
		}

	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.tag == "Player")
			
			health.ModifyHealth(-10);

	}
}
