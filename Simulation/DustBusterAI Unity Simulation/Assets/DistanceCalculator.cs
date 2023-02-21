using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

public class DistanceCalculator : MonoBehaviour
{
    public Transform dummyTarget;
    public Transform dummyRobot;

    public Vector3 one = new Vector3();
    public Vector3 two = new Vector3();

    public float dist = -1;
    public bool Scan = false;
    public AIPath ai;

    private void Start()
    {
        dummyRobot.position = new Vector3 (0, 2.08f, 0);
        //ai = dummyRobot.GetComponent<AIPath>();
        //print(ai.remainingDistance);
        dummyRobot = GameObject.Find("dummyRobot").transform;
        ai = dummyRobot.GetComponent<AIPath>();
        //print(ai.remainingDistance.ToString());
        //print(ai.remainingDistance);
    }
    private void Update()
    {
        if (Scan)
        {
            dummyRobot.position = one;
            dummyTarget.position = two;
            //print(ai.remainingDistance.ToString());

            dist = ai.remainingDistance;
            //print(dist);
            Scan = false;
        }
    }
}
