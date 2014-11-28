using UnityEngine;
using System.Collections;

public class MeterScore : MonoBehaviour
{
	public int heightscore = 0;					// The player's score.
	
	
	private PlayerControl playerControl;	// Reference to the player control script.
	private int previousScore = 0;			// The score in the previous frame.
	
	
	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}
	
	
	void Update ()
	{
		// Set the score text.
		guiText.text = "Height: " + heightscore;
		
		
		// Set the previous score to this frame's score.
		previousScore = heightscore;
	}
	
}
