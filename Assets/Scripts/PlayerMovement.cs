using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float runSpeed = 10f;

	Vector2 direction;

	Rigidbody2D rb;
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
	{

		direction.x = Input.GetAxisRaw("Horizontal") * runSpeed;
		direction.y = Input.GetAxisRaw("Vertical") * runSpeed;

	}

	void FixedUpdate()
	{
		// Move our character
		rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);

	}
}