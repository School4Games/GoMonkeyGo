using UnityEngine;
using System.Collections;

public class Bananastartup : MonoBehaviour
{
			
	public Bananabar points;

	
	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{

			
			points.ModifyPoints(-100);
			
			// Destroy the crate.
			Destroy(gameObject);

		}}}