using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMovement : MonoBehaviour
{
	private Vector2 dir = Vector2.right;
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] int speed;
	[SerializeField] bool isFacingRight = true;
	
	void Start()
    {
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();
		speed = 5;
    }
	void Update()
	{
      	transform.Translate(dir*speed*Time.deltaTime);
		
      	if(transform.position.x <= -5) {
           	dir = Vector2.right;
		}
      	if (transform.position.x >= 5) {
           	dir = Vector2.left;
		}

 	}

	// void FixedUpdate() 
	// {
	// 	if (transform.position.x <= 5 && isFacingRight || transform.position.x >= -5 && !isFacingRight)
	// 		Flip();
	// }

	void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight; 
	}

} 