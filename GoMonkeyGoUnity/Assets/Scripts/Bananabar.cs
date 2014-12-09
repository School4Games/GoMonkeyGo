using UnityEngine;
using System.Collections;

public class Bananabar : MonoBehaviour {
	
	private int maxPoints;
	public int startingPoints;
	public int pointsPerBanana;
	
	private int currentPoints;
	
	public GUITexture bananaGUI;
	public Texture[] images;
	
	private ArrayList bananas = new ArrayList();
	
	public int maxBananasPerRow;
	private float spacingX;
	private float spacingY;

	
	void Start () {
		maxPoints = startingPoints;
		spacingX = bananaGUI.pixelInset.width;
		spacingY = -bananaGUI.pixelInset.height;
	
		
		AddBananas(startingPoints / pointsPerBanana);
	}
	
	public void AddBananas(int n) {
		for (int i =0; i < n; i ++) {
			Transform newBanana = ((GameObject)Instantiate(bananaGUI.gameObject)).transform;
			newBanana.parent = this.transform;
			
			int y = Mathf.FloorToInt(bananas.Count / maxBananasPerRow);
			int x = bananas.Count - y * maxBananasPerRow;
			
			newBanana.GetComponent<GUITexture>().pixelInset = new Rect(x * spacingX, y * spacingY, 60,108);
			bananas.Add (newBanana);
		}
		
		maxPoints += n * pointsPerBanana;

		UpdateBananas ();
		
	}
	
	public void ModifyPoints (int amount) {
		currentPoints += amount;
		currentPoints = Mathf.Clamp (currentPoints, 0, maxPoints);
		UpdateBananas ();
	}
	
	private void UpdateBananas() {
		
		bool restAreEmpty = false;
		int i = 0;
		
		foreach (Transform banana in bananas) {
			if (restAreEmpty) {
				banana.guiTexture.texture = images[0];
			}
			else {
				i +=1;
				if (currentPoints >= i * pointsPerBanana) {
					banana.guiTexture.texture = images[images.Length-1];
				}
				else {
					int currentBananaPoints = (int)(pointsPerBanana - (pointsPerBanana * i - currentPoints));
					int pointsPerImage = pointsPerBanana / images.Length;
					int imageIndex = currentBananaPoints / pointsPerImage;
					
					if (imageIndex == 0 && currentBananaPoints > 0) {
						imageIndex = 1;
					}
					
					banana.guiTexture.texture = images[imageIndex];
					restAreEmpty = true;



				}
		
			}	}
	}
}

