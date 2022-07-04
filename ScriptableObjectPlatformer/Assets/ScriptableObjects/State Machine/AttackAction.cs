using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    public float attackRange;
    public float jumpForce;
    public LayerMask groundLayer;
    public override void Act(StateController controller)
    {
        Attack(controller);
    }
    void Attack(StateController controller)
    {
        bool isGrounded = Physics2D.Raycast(controller.transform.position, -controller.transform.up, 1f, groundLayer);

        if (isGrounded)
        {
            if (Vector2.Distance(controller.transform.position, controller.chaseTarget.position) < attackRange && controller.rb.velocity.y == 0)
            {
                controller.rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
}
