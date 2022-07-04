using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public float patrolSpeed;
    public override void Act(StateController controller)
    {
        Patrol(controller);
    }
    private void Patrol(StateController controller)
    {
        if (Vector2.Distance(controller.transform.position, controller.Waypoints[controller.currentWaypoint].position) <= 1f)
        {
            if (controller.currentWaypoint < controller.Waypoints.Length - 1) controller.currentWaypoint++;
            else controller.currentWaypoint = 0;
        }

        controller.transform.position = Vector2.MoveTowards(controller.transform.position, controller.Waypoints[controller.currentWaypoint].position, patrolSpeed * Time.deltaTime);
        if (controller.transform.position.x > controller.Waypoints[controller.currentWaypoint].position.x) controller.transform.localScale = new Vector2(-1, 1);
        else controller.transform.localScale = new Vector2(1, 1);

    }
}
