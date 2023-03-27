using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inworld.Runtime;
using Inworld.Sample.UI;
using Inworld.Util;


public class PlayerMovement : MonoBehaviour
{
	public float runSpeed = 5f;
	Vector2 direction;
	Rigidbody2D rb;
	Animator anim;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim= GetComponent<Animator>();
	}
	void FixedUpdate()
	{
		// Move our character
		if (!Inworld.Sample.InworldPlayer.m_chatIsOpened)
		{
			direction.x = Input.GetAxisRaw("Horizontal") * runSpeed;
			direction.y = Input.GetAxisRaw("Vertical") * runSpeed;
			rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);

			SetParam();

		}
	}

	void SetParam()
    {
		if (direction.x == 0 && direction.y == 0)
		{
			anim.SetInteger("dir", 0);
		}
        else if (direction.x > 0) //droite
        {
			anim.SetInteger("dir", 4);
		}
		else if (direction.x < 0) //gauche
		{
			anim.SetInteger("dir", 2);
		}
		else if (direction.y > 0) //haut
		{
			anim.SetInteger("dir", 3);
		}
		else if (direction.y < 0) //bas
		{
			anim.SetInteger("dir", 1);
		}
	}
}