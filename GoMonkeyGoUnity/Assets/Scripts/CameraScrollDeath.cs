﻿using UnityEngine;
using System.Collections;

public class CameraScrollDeath : MonoBehaviour {
	
	[SerializeField]
	Transform platform;
	
	[SerializeField]
	Transform startTransform;
	
	[SerializeField]
	Transform endTransform;
	
	[SerializeField]
	float platformSpeed;
	
	Vector3 direction;
	Transform destination;
	
	void start (){
		
	}
	
	void FixedUpdate(){
		platform.rigidbody2D.MovePosition(platform.position + Vector3.up * platformSpeed * Time.fixedDeltaTime);
		
		
	}
	
	
	
	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(startTransform.position, platform.localScale);
		
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(endTransform.position, platform.localScale);
	}
	
	
	
}