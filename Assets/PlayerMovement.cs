using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float MoveSpeed, FallSpeed, LowJumpSpeed, JumpHeight, GunForce;
	[SerializeField]
	private Transform Linecast1, Linecast2;

	private Rigidbody2D RB;
    private Transform myTrans;
    RaycastHit2D LineBoi;
    Animator anim;

	void Start()
	{
		RB = GetComponent<Rigidbody2D>();
        myTrans = GetComponent<Transform>();
        anim = GetComponentInChildren<Animator>();
    }
	

	void Update()
	{
        LineBoi = Physics2D.Linecast (Linecast1.position, Linecast2.position);
		move ();
		jump ();
		//print (RB.velocity);

		//drag
        RB.AddForce(Vector2.right * Mathf.Tan(RB.velocity.x * 0.01f) * -8f, ForceMode2D.Impulse);
    }

	void move()
	{
        //animation
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            myTrans.localScale = new Vector2(1, 1);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            myTrans.localScale = new Vector2(-1, 1);
        }
        anim.SetBool("moving", Input.GetButton("Horizontal"));

        //physics
        if(myTrans.position.x > 0)
        {
            if (LineBoi.collider != null && !LineBoi.collider.IsTouchingLayers(2))
            {
                RB.AddForce(Vector2.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * MoveSpeed);
            } else
            {
                RB.AddForce(Vector2.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * MoveSpeed);
            }
        }
        else
        {
            //transform.position = new Vector3(0.001f,myTrans.position.y,myTrans.position.z);
            RB.AddForce(Vector2.right * ((RB.velocity.x * -1)+1f),ForceMode2D.Impulse);
        }
	}

	void jump()
	{
		if (Input.GetButtonDown ("Jump") && LineBoi.collider != null && !LineBoi.collider.IsTouchingLayers(2)) 
		{
			RB.AddForce (Vector2.up * JumpHeight,ForceMode2D.Impulse);
		}

        //if (RB.velocity.y < 0)
        //{
        //	RB.velocity += Vector2.up * Physics2D.gravity.y * (FallSpeed - 1) * Time.deltaTime;
        //          print(RB.velocity.y);
        //}
        //else if ( RB.velocity.y > 0 && !Input.GetButton ("Jump"))
        //{
        //	RB.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpSpeed - 1) * Time.deltaTime;
        //}

        if (RB.velocity.y <= -20)
        {
            RB.AddForce(Vector2.up * RB.gravityScale * RB.mass, ForceMode2D.Impulse);
        }
    }

    void FireGun(float angle)
    {
        var vForce = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.left;
        RB.AddForce(vForce.normalized * GunForce,ForceMode2D.Impulse);
    }
}
