using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float runSpeed = 10f;

	Vector2 direction;
	bool chatOpen;
	Rigidbody2D rb;
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		chatOpen = false;
    }
    // Update is called once per frame
    void Update()
	{
		if (Input.GetKeyUp(KeyCode.BackQuote) && !chatOpen)
		{
			chatOpen = true;
		}
		else if (Input.GetKeyUp(KeyCode.BackQuote) && chatOpen)
        {
			chatOpen = false;
        }

	}

	void FixedUpdate()
	{
		// Move our character
		if (!chatOpen)
        {
			direction.x = Input.GetAxisRaw("Horizontal") * runSpeed;
			direction.y = Input.GetAxisRaw("Vertical") * runSpeed;
			rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);
		}
	}
}