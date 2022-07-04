using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }
    private bool Look(StateController controller)
    {
        RaycastHit2D hit;       
        hit = Physics2D.CircleCast(controller.transform.position, 2f, controller.transform.right * controller.transform.localScale.x,2f);
        Debug.DrawRay(controller.transform.position, controller.transform.right * controller.transform.localScale.x, Color.green);
       
        if (hit != false && hit.collider.CompareTag("Player") )
        {
            controller.chaseTarget = hit.transform;
            return true;
        }
        else
        {
            return false;
        }
    }
}
