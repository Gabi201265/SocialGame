using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inworld.Runtime;
using Inworld.Sample.UI;
using Inworld.Util;


public class PlayerMovement : MonoBehaviour
{

	bool IsMoving
    {
        set
        {
			isMoving = value;
			animator.SetBool("isWalking", isMoving);
        }
    }

	public float runSpeed = 5f;
	Vector2 direction;
	Rigidbody2D rb;

	Animator animator;
	bool isMoving = false;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

    private void Update()
    {
		direction.x = Input.GetAxisRaw("Horizontal");
		direction.y = Input.GetAxisRaw("Vertical");

		if (direction != Vector2.zero)
		{

			animator.SetFloat("Horizontal", direction.x);
			animator.SetFloat("Vertical", direction.y);


		}
		//animator.SetFloat("Speed", Mathf.Abs(direction.magnitude * runSpeed));

		//bool flipped = direction.x < 0;
		//this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));
	}

    void FixedUpdate()
	{
		// Move our character
		if (!Inworld.Sample.InworldPlayer.m_chatIsOpened)
		{
			if (direction != Vector2.zero)
				rb.MovePosition(rb.position + direction.normalized * runSpeed * Time.fixedDeltaTime);

			IsMoving = direction != Vector2.zero ? true : false;
			//if(direction != Vector2.zero)
			//         {
			//	rb.MovePosition(rb.position + direction.normalized * runSpeed * Time.fixedDeltaTime);
			//	spriteRenderer.flipX = direction.x > 0 ? false : (direction.x < 0 ? true : spriteRenderer.flipX);
			//	IsMoving = true;
			//         }
			//         else
			//         {
			//	IsMoving = false;
			//         }
		}
	}
}