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
    IAstarAI ai;

    private void Start()
    {
        ai = dummyRobot.GetComponent<AIDestinationSetter>().ai;
    }
    private void Update()
    {
        if (!Scan)
        {
            dummyRobot.position = one;
            dummyTarget.position = two;


            dist = ai.remainingDistance;
            //print(dist);
            Scan = false;
        }
    }
}
