using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public State currentState;
    public Transform[] Waypoints;
    public State remainState;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public int currentWaypoint = 0;
    [HideInInspector] public Transform chaseTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void TransitionToState(State nextState)
    {
        if(nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
