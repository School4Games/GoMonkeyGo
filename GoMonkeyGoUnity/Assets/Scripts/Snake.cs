using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour {


	public bool jump = false;	
	public float jumpForce = 2000f;	

	void OnTriggerEnter2D (Collider2D other){
			if(other.tag == "Snake"){
				rigidbody2D.AddForce(new Vector2(0f, jumpForce));

		}
	}
}