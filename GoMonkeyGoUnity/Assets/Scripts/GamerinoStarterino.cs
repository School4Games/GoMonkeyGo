using UnityEngine;
using System.Collections;

public class GamerinoStarterino : MonoBehaviour
{
	public int countdown = 0;					// The player's score.
	
	private int previousScore = 0;			// The score in the previous frame.
	
	
	
	void Update ()
	{
		// Set the score text.
		guiText.text = "" + countdown;
		
		
		// Set the previous score to this frame's score.
		previousScore = countdown;
		
		if (countdown > 0)
			Time.timeScale = 0.02f;
		
			else
				Time.timeScale = 1.1f;
		
		if (countdown == 0) 
			Destroy(gameObject);
		
	}
	
}
