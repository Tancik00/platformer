using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private GameObject[] myWaypoints;

    private int myWaypointId = 0;

    void Update () {
        EnemyMovement ();
    }

    void EnemyMovement () {
        if (myWaypoints.Length != 0) {
            if (Vector3.Distance (myWaypoints[myWaypointId].transform.position, transform.position) <= 0.1F) {
                myWaypointId++;
            }

            if (myWaypointId >= myWaypoints.Length) {
                myWaypointId = 0;
            }

            transform.position = Vector3.MoveTowards (transform.position, myWaypoints[myWaypointId].transform.position, moveSpeed * Time.deltaTime);
        }
    }
}