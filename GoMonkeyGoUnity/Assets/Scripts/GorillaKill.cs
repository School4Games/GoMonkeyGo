﻿using UnityEngine;
using System.Collections;

public class GorillaKill : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.tag == "Player")
			Destroy(gameObject);
	}
}