using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Action/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        Chase(controller);
    }
    void Chase (StateController controller)
    {
        controller.transform.position = Vector2.MoveTowards(controller.transform.position, controller.chaseTarget.position, controller.stats.chaseSpeed * Time.deltaTime);
    }
}
