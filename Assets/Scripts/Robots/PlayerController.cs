using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float maxSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move()
	{
		Vector3 velocity = new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0, 0);

		transform.position += velocity;
		
	}
}
