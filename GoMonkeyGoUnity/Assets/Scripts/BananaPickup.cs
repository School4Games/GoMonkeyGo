using UnityEngine;
using System.Collections;

public class BananaPickup : MonoBehaviour
{
	public AudioClip pickupClip;		// Sound for when the bomb crate is picked up.
	
	public GameObject hundredPointsUI;	// A prefab of 100 that appears when the enemy dies.
	private Animator anim;				// Reference to the animator component.

	private Score score;				// Reference to the Score script.
	private Bananabar points;
	private BananajumpScore jumpscore;

	void Awake()
	{
		// Setting up the reference.
		anim = transform.root.GetComponent<Animator>();
		score = GameObject.Find("Score").GetComponent<Score>();
		points = GameObject.Find ("bananabar").GetComponent<Bananabar> ();
		jumpscore = GameObject.Find("jumpScore").GetComponent<BananajumpScore>();
	}
	
	
	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{
			
			// Increase the number of bombs the player has.
			score.score += 100;

			jumpscore.jumpscore += 1;

			points.ModifyPoints(10);

			// Destroy the crate.
			Destroy(gameObject);
			
			// Create a vector that is just above the enemy.
			Vector3 scorePos;
			scorePos = transform.position;
			scorePos.y += 1.5f;
			
			// Instantiate the 100 points prefab at this point.
			Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
			
		}
		
	}
}
