using UnityEngine;
using System.Collections;

public class BananajumpScore : MonoBehaviour
{
	public int jumpscore = 0;					// The player's score.
	private int previousScore = 0;			// The score in the previous frame.

	
	void Awake ()
	{

	}
	
	
	void Update ()
	{
		// Set the score text.
		guiText.text = "" + jumpscore;
		
		
		// Set the previous score to this frame's score.
		previousScore = jumpscore;
		
		
		
		
	}



	
}
