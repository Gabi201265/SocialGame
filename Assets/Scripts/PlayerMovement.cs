using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inworld.Runtime;
using Inworld.Sample.UI;
using Inworld.Util;
public class PlayerMovement : MonoBehaviour
{
	public float runSpeed = 10f;

	Vector2 direction;
	Rigidbody2D rb;
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
	{
		// Move our character
		if (!Inworld.Sample.InworldPlayer.m_chatIsOpened)
        {
			direction.x = Input.GetAxisRaw("Horizontal") * runSpeed;
			direction.y = Input.GetAxisRaw("Vertical") * runSpeed;
			rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);
		}
	}
}