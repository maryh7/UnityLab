using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{   
    [SerializeField] int speed; 
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        JellyMovement jelly = collision.GetComponent<JellyMovement>();
        if (collision.CompareTag("Jelly")) {
            if (jelly != null) 
            {
                jelly.Pop();
                //Score.AddScore(jelly.transform.localScale.x);
            }
            Destroy(gameObject);
        }
        
    }

}
