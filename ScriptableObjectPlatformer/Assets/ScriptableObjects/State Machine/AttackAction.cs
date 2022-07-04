using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {
        Attack(controller);
    }
    void Attack(StateController controller)
    {
        bool isGrounded = Physics2D.Raycast(controller.transform.position, -controller.transform.up, 1f, controller.stats.isGround);

        if (isGrounded)
        {
            if (Vector2.Distance(controller.transform.position, controller.chaseTarget.position) < controller.stats.attackRange && controller.rb.velocity.y == 0)
            {
                controller.rb.AddForce(new Vector2(0, controller.stats.jumpForce), ForceMode2D.Impulse);
            }
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(controller.transform.position, -controller.transform.up, 1f);

            if(hit != false && hit.collider.CompareTag("Player"))
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
