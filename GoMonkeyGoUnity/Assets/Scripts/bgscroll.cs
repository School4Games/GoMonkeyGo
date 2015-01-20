using UnityEngine;
using System.Collections;

public class bgscroll : MonoBehaviour {
	
	private MeterScore heightscore;				// Reference to the Score script.
	
	[SerializeField]
	Transform platform;
	
	[SerializeField]
	Transform startTransform;
	
	[SerializeField]
	Transform endTransform;
	
	[SerializeField]
	float platformSpeed;
	
	Vector3 direction;
	Transform destination;
	
	void Awake()
	{
		// Setting up the reference.
		heightscore = GameObject.Find("MeterScore").GetComponent<MeterScore>();
		
	}
	
	void start (){
		
	}
	
	void FixedUpdate(){
		platform.rigidbody2D.MovePosition(platform.position + Vector3.up * platformSpeed * Time.fixedDeltaTime);
		
		

	}
	
	
	
	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(startTransform.position, platform.localScale);
		
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(endTransform.position, platform.localScale);
	}
	
	
	
}