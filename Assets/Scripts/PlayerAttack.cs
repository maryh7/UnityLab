using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] public Transform shootingPos;
    [SerializeField] public GameObject bananas;
    private Animator animator;
    private Movement movement;
    private float cdTimer = 999;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && cdTimer > cooldown && movement.canAttack()) {
            Attack();
        }
        cdTimer += Time.deltaTime;
    }

    private void Attack()
    {
        Instantiate(bananas, shootingPos.position, transform.rotation);
        animator.SetTrigger("attack");
        cdTimer = 0;

    }
}
