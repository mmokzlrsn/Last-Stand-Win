using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 1.0f;
    private Rigidbody enemyRB;
    private GameObject player;
    private float fallRange = -15.0f;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Die();
        
    
    }

    void Move()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRB.AddForce(lookDirection * speed);
    }

    void Die()
    {
        if (transform.position.y < fallRange)
            Destroy(gameObject);
    }
    
}
