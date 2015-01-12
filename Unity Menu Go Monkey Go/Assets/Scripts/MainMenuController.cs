using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
	

	// Load the Game Scene
	public void StartGame () 
	{
		Application.LoadLevel ("Game");
		}
	// end the Game
	public void EndGame()
		{
		Application.Quit ();
		}

}
	

