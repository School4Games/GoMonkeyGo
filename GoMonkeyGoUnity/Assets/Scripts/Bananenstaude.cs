using UnityEngine;
using System.Collections;

public class Bananenstaude : MonoBehaviour
{
	public AudioClip pickupClip;		// Sound for when the bomb crate is picked up.
	
	public GameObject hundredPointsUI;	// A prefab of 100 that appears when the enemy dies.
	private Animator anim;				// Reference to the animator component.
	private bool landed = false;		// Whether or not the crate has landed yet.
	private Score score;				// Reference to the Score script.
	public Bananabar points;


	void Awake()
	{
		// Setting up the reference.
		anim = transform.root.GetComponent<Animator>();
		score = GameObject.Find("Score").GetComponent<Score>();

	}
	
	
	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{
			
			// Increase the number of bombs the player has.
			score.score += 300;



			points.ModifyPoints(30);
			
			// Destroy the crate.
			Destroy(gameObject);


			// Create a vector that is just above the enemy.
			Vector3 scorePos;
			scorePos = transform.position;
			scorePos.y += 1.5f;
			
			// Instantiate the 100 points prefab at this point.
			Instantiate(hundredPointsUI, scorePos, Quaternion.identity);

			// Create a vector that is just above the enemy.

			scorePos = transform.position;
			scorePos.y += 1.8f;
			
			// Instantiate the 100 points prefab at this point.
			Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
			// Create a vector that is just above the enemy.

			scorePos = transform.position;
			scorePos.y += 2.1f;
			
			// Instantiate the 100 points prefab at this point.
			Instantiate(hundredPointsUI, scorePos, Quaternion.identity);




		}
		
	}
}
