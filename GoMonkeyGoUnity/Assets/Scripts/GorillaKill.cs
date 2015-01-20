using UnityEngine;
using System.Collections;

public class GorillaKill : MonoBehaviour {


	bool collided;
	
	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "feet") {
			collided = true; 
			if (collided) {
				rigidbody2D.isKinematic = false;
				yield return new WaitForSeconds (3); 
				Destroy(gameObject);
			}
		}
	}
	
	
	void OnCollisionExit () {
		collided = false;
	}
	
	
}