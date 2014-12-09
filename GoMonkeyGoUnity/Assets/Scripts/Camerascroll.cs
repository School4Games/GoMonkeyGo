using UnityEngine;
using System.Collections;

public class Camerascroll : MonoBehaviour {

	private int currentHealth;
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
		platform.rigidbody.MovePosition(platform.position + Vector3.up * platformSpeed * Time.fixedDeltaTime);

		if(heightscore.heightscore == 25f)
			platformSpeed += 0.0025f;
		
		if (heightscore.heightscore == 50f)
			platformSpeed += 0.0025f;
		
		if (heightscore.heightscore == 75f)
			platformSpeed += 0.0025f;
		
		if (heightscore.heightscore == 100f)
			platformSpeed += 0.0025f;
		
		if (heightscore.heightscore == 125f)
			platformSpeed += 0.0025f;
		
		if (heightscore.heightscore == 150f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 175f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 200f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 225f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 250f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 275f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 300f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 325f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 350f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 375f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 400f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 425f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 450f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 475f)
			platformSpeed += 0.0025f;
		
		if(heightscore.heightscore == 500f)
			platformSpeed += 0.0025f;


	
		}



	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(startTransform.position, platform.localScale);

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(endTransform.position, platform.localScale);
	}



}