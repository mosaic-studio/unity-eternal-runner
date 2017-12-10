using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{

	public float maxSpeed = 5.0f;
	public float jumpTakeOffSpeed = 7;

	private Animator animator;
	private SpriteRenderer spriteRenderer;
	
	void Awake ()
	{
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	/*
	// Update is called once per frame
	void Update () {
		Move();
		Jump();
	}*/
	
	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump") && grounded) {
			velocity.y = jumpTakeOffSpeed;
		} else if (Input.GetButtonUp ("Jump")) 
		{
			if (velocity.y > 0) {
				velocity.y = velocity.y * 0.5f;
			}
		}

		bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
		if (flipSprite) 
		{
			spriteRenderer.flipX = !spriteRenderer.flipX;
		}

		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

		targetVelocity = move * maxSpeed;
	}

	void Move()
	{
		float movement = Input.GetAxis("Horizontal");
		Vector3 velocity = new Vector3(movement * maxSpeed * Time.deltaTime, 0, 0);
		transform.position += velocity;
		if (Mathf.Abs(movement) <= 0.1f)
		{
			animator.Play("Idle");
			Debug.Log(movement);
		}
		else
		{
			animator.Play("Running");
		}
	}

	void Jump()
	{
		float jump = Input.GetAxis("Jump");
		if (jump >= 0.1f)
		{
			animator.Play("Jump");
		}
		
	}
}
