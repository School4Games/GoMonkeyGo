using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	bool collided;
	
	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
				if (other.tag == "feet") {
						collided = true;
						yield return new WaitForSeconds (1f);  
						if (collided) {
								rigidbody2D.isKinematic = false;
						}
				}
		}
	
	
	void OnCollisionExit () {
		collided = false;
	}

		
	}


