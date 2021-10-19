using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Life
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public float searchRange;
    public float stopRadius;
    public float timeToShoot;
    Transform player;

    Vector3 movement;
    Vector3 playerPos;

    enum States { patrol, pursuit }
    States state = States.patrol;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, searchRange);
    }

    void SendPunch()
    {
        if (state != States.pursuit)
            return;
        
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //InvokeRepeating("SetTarget", 0, 2.5f);
        InvokeRepeating("Shoot", 0, timeToShoot);
    }
    private void Update()
    {
        if (state == States.pursuit)
        {
            playerPos = player.position;
            if (Vector3.Distance(playerPos, transform.position) > searchRange * 1.2f)
            {
                playerPos = transform.position;
                state = States.patrol;
                return;
            }
        }
    }
}
