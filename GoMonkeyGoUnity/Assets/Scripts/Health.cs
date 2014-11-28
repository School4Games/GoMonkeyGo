using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	private int maxHealth;
	public int startingHealth;
	public int healthPerHeart;

	private int currentHealth;

	public GUITexture heartGUI;
	public Texture[] images;

	private ArrayList hearts = new ArrayList();

	public int maxHeartsPerRow;
	private float spacingX;
	private float spacingY;
	public Texture gameOverTexture;
	
	void Start () {
		currentHealth = startingHealth;
		spacingX = heartGUI.pixelInset.width;
		spacingY = -heartGUI.pixelInset.height;

		AddHearts(startingHealth / healthPerHeart);
	}
	
	public void AddHearts(int n) {
		for (int i =0; i < n; i ++) {
			Transform newHeart = ((GameObject)Instantiate(heartGUI.gameObject)).transform;
			newHeart.parent = this.transform;

			int y = Mathf.FloorToInt(hearts.Count / maxHeartsPerRow);
			int x = hearts.Count - y * maxHeartsPerRow;

			newHeart.GetComponent<GUITexture>().pixelInset = new Rect(x * spacingX, y * spacingY, 64,58);
			hearts.Add (newHeart);
		}

		maxHealth += n * healthPerHeart;
		currentHealth = maxHealth;
		UpdateHearts ();

	}

	public void ModifyHealth (int amount) {
		currentHealth += amount;
		currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
		UpdateHearts ();
		}
		
		private void UpdateHearts() {

				bool restAreEmpty = false;
				int i = 0;

			foreach (Transform heart in hearts) {
				if (restAreEmpty) {
					heart.guiTexture.texture = images[0];
				}
				else {
					i +=1;
					if (currentHealth >= i * healthPerHeart) {
						heart.guiTexture.texture = images[images.Length-1];
					}
					else {
						int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
						int healthPerImage = healthPerHeart / images.Length;
						int imageIndex = currentHeartHealth / healthPerImage;

						if (imageIndex == 0 && currentHeartHealth > 0) {
							imageIndex = 1;
					}

						heart.guiTexture.texture = images[imageIndex];
						restAreEmpty = true;
				}
				if(currentHealth == 0)

					Destroy(GameObject.FindGameObjectWithTag("Player"));
				if(currentHealth == 0)
					Time.timeScale = 0;
				if(currentHealth == 0)
					Destroy(GameObject.FindGameObjectWithTag("Scrollerino"));
					



					}	}
			}
	void OnGUI()
	{
		if(currentHealth == 0)
			GUI.DrawTexture(new Rect(325, 325, 1024, 137),gameOverTexture);
		}
}

