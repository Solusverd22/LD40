using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float MoveSpeed, FallSpeed, LowJumpSpeed, JumpHeight;
	[SerializeField]
	private Transform Linecast1, Linecast2;

	private Rigidbody2D RB;
	RaycastHit2D LineBoi;

	void Start ()
	{
		RB = GetComponent<Rigidbody2D>();
	}
	

	void Update ()
	{
		LineBoi = Physics2D.Linecast (Linecast1.position, Linecast2.position);
		move ();
		jump ();
		print (RB.velocity);
		//drag
		RB.AddForce (Vector2.right * (RB.velocity.x - 4) ,ForceMode2D.Impulse);
		print (RB.velocity.x);
	}

	void move()
	{
		if (LineBoi.collider != null)
		{
			RB.AddForce (Vector2.right* Input.GetAxisRaw ("Horizontal") * Time.deltaTime * MoveSpeed);
		}else
		{
			RB.AddForce (Vector2.right* Input.GetAxisRaw ("Horizontal") * Time.deltaTime * MoveSpeed/2f);
		}
	}

	void jump()
	{
		if (Input.GetButtonDown ("Jump") && LineBoi.collider != null) 
		{
			RB.AddForce (Vector2.up * JumpHeight,ForceMode2D.Impulse);
		}

		if (RB.velocity.y < 0)
		{
			RB.velocity += Vector2.up * Physics2D.gravity.y * (FallSpeed - 1) * Time.deltaTime;
		}
		else if ( RB.velocity.y > 0 && !Input.GetButton ("Jump"))
		{
			RB.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpSpeed - 1) * Time.deltaTime;
		}
	}
}
