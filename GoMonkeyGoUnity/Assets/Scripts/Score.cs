using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public int score = 0;					// The player's score.


	private PlayerControl playerControl;	// Reference to the player control script.
	private int previousScore = 0;			// The score in the previous frame.
	private Camerascroll platformSpeed;

	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		platformSpeed = GameObject.Find("Scrolling").GetComponent<Camerascroll>();
	}


	void Update ()
	{
		// Set the score text.
		guiText.text = "Score: " + score;


		// Set the previous score to this frame's score.
		previousScore = score;




	}

}
