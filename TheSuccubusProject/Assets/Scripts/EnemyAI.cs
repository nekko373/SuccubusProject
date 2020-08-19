using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    public Transform bb_bear;
    Path path;
    int currentWayPoint = 0;
    bool reachedEndofPath = false;

    public Rigidbody2D rb;
    public Seeker seeker;

    void Start() {

        seeker.GetComponent<Seeker>();
        rb.GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        

    }

    void UpdatePath() {

        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);

    } 
    
    void OnPathComplete(Path p) {

            if (!p.error) {
                path = p;
                currentWayPoint = 0;
            }
        }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) {
            return;
            }


        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndofPath = true;
            return;
        }
        else {
            reachedEndofPath = false;


        }


        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance) {
            currentWayPoint++;
        }



        if (force.x >= 0.01f)
        {

            bb_bear.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            bb_bear.localScale = new Vector3(1f, 1f, 1f);

        }









    }
}
