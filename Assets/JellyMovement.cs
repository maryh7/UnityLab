using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JellyMovement : MonoBehaviour
{
	private Vector2 dir = Vector2.right;
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] int speed;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] private AudioClip fail;
	
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

	public void Pop()
	{
		SoundManager.instance.PlaySound(fail);
		Destroy(gameObject);
	}

} 