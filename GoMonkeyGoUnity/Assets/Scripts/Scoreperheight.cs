using UnityEngine;
using System.Collections;

public class Scoreperheight : MonoBehaviour {

	private Score score;				// Reference to the Score script.
	private MeterScore height;

	// Use this for initialization
	void Awake () {
		score = GameObject.Find("Score").GetComponent<Score>();
		height = GameObject.Find ("MeterScore").GetComponent<MeterScore>();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{
			

			score.score += 1;

			height.heightscore += 1;
			
		

			
		}
		
	}
	void OnTriggerExit2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{
			
			
			score.score += 1;
			

			
			
			Destroy(gameObject);
			
		}
		
	}
}