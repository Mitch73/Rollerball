using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //speed of the enemy
    public float speed = 0;
    //waypoint the nenmy is going between
    public List<Transform> waypoints;

    //this variable keeps track of which waypoint the enemy is in
    private int waypointIndex;
    //this variable determines the distance between the waypoint and the enemy
    private float range;

    // Start is called before the first frame update
    void Start()
    {
        /*the object heads to the waypoint inside list*/
        waypointIndex = 0;
        /*alerts the object to move from one waypoint to another 1 = unit*/
        range = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        /*takes the target transform and have the object face the waypoint at all times*/
        transform.LookAt(waypoints[waypointIndex]);
        /*the direction the object is going to move*/
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
/*check to see how close the object is to the waypoint and if we need to move to the next*/
        if(Vector3.Distance(transform.position, waypoints[waypointIndex].position) < range)
        {
/*this allows the object to loop through the waypoints over and over*/
            waypointIndex++;
            if(waypointIndex >= waypoints.Count)
            {
                waypointIndex = 0;
            }
        }
    }
}
