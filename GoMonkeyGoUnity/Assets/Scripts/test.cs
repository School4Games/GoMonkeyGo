using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public Health health;

	void OnTriggerEnter2D (Collider2D other)
	{
	
		if (other.tag == "Player")
		
				health.ModifyHealth(-10);


	}

}
