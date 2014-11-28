using UnityEngine;
using System.Collections;

public class HeartPickup : MonoBehaviour {
	
	public Health health;
	
	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.tag == "Player")
			
			health.AddHearts(1);
		
		Destroy(gameObject);
	}
}
