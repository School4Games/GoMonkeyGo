using UnityEngine;
using System.Collections;

public class move : MonoBehaviour
{
	public float speed;
	
	void Start ()
	{
		rigidbody.velocity = transform.forward * speed;
	}
}
