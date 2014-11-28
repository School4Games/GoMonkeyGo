using UnityEngine;
using System.Collections;

public class Countdowntimer : MonoBehaviour {

	private GamerinoStarterino countdown;				// Reference to the Score script.

	void Awake()
	{
				// Setting up the reference.

				countdown = GameObject.Find ("Countdown").GetComponent<GamerinoStarterino> ();

		}

	void OnTriggerEnter2D (Collider2D other)
		{
			// If the player enters the trigger zone...
			if(other.tag == "Player")
			{
				
				// Increase the number of bombs the player has.
				countdown.countdown -= 1;

				
				// Destroy the crate.
				Destroy(gameObject);
		
	}
	}}