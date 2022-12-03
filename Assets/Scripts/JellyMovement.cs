using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JellyMovement : MonoBehaviour
{
	private Vector2 dir = Vector2.right;
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float speed;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] private AudioClip failS;

	[SerializeField] bool diff = false;
	
	public static Vector2 xy;
	
	void Start()
    {
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();

		InvokeRepeating("Scale", 1f, 1f);
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

	void FixedUpdate() 
	{
		// if (transform.position.x <= 5 && isFacingRight || transform.position.x >= -5 && !isFacingRight) {
		// 	Flip();

	}

	void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight; 
	}

	public void Pop()
	{
		SoundManager.instance.PlaySound(failS);
		Destroy(gameObject);
	}

	public void Scale()
	{
		if (diff)
		{
			xy = transform.localScale;
			xy.x += 0.2f;
			xy.y += 0.2f;
		}
		else
		{
			xy = transform.localScale;
			xy.x += 0.1f;
			xy.y += 0.1f;
		}
	
		transform.localScale = xy;

		if (xy.x > 2f)
		{
			Pop();
			Restart();
		}
	}

	public static void Restart() 
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Score.ResetScore();
	}

} 