using UnityEngine;
using System.Collections;

public class GorillaKnockback : MonoBehaviour {
	public bool jump = false;	
	public float jumpForce = 1100f;	
	
	void OnTriggerEnter2D (Collider2D other){
		if(other.tag == "Gorilla"){
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
		}
	}
}