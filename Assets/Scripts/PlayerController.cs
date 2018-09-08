using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


	public float speed;
	public float jumpForce;
	public float secondJumpForce;
	private float moveInput;
	public float dashJump;

	private Rigidbody2D rb;

	private bool facingRight = true;

	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask groundLayer;

	private int extraJump;
	public int extraJumpValue;

	//Dash tentative
	public float startDashTime;
	float dashTime;
	public float dashSpeed;
	bool isDashing = false;
	public SortingLayer groundSortingLayer;


	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		extraJump = extraJumpValue;
		dashTime = startDashTime;
	}




	private void FixedUpdate()
	{

		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

		moveInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


		if (Input.GetButton("Dash"))
		{

			Dash();

		}
		if (Input.GetButtonUp("Dash"))
		{
			isDashing = false;
			dashTime = startDashTime;
		}
			
		if (facingRight == false && moveInput > 0)
		{
			Flip();
		}
		else if (facingRight == true && moveInput < 0)
		{
			Flip();
		}
			
	}

	// Update is called once per frame
	void Update()
	{

		if (isGrounded == true)
		{
			extraJump = extraJumpValue;
		}

		Jump();

		if (Input.GetButtonUp("Dash"))
		{
			isDashing = false;
			dashTime = startDashTime;
		}
	
	}

	private void Jump()
	{
		if (Input.GetButtonDown("Jump") && extraJump > 0)
		{
			rb.velocity = Vector2.up * secondJumpForce;
			extraJump--;
		}
		if (Input.GetButtonDown("Jump") && extraJump == 0 && isGrounded == true)
		{
			rb.velocity = Vector2.up * jumpForce;
		}


	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}

	void Dash()
	{

		if (transform.localScale.x > 0 && dashTime > 0 && isGrounded == true)
		{
			isDashing = true;
			dashTime -= Time.deltaTime;
			rb.velocity = transform.right * dashSpeed;

		}
		else if (transform.localScale.x < 0 && dashTime > 0 && isGrounded == true)
		{
			isDashing = true;
			dashTime -= Time.deltaTime;
			rb.velocity = -transform.right * dashSpeed;

		}


	}

}