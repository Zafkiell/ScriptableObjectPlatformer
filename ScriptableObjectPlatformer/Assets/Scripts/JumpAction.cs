using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jump",menuName = "Actions/Jump")]
public class JumpAction : ScriptableObject
{
    public float jumpForce;
    int extraJump = 1;
    public LayerMask groundLayer;

    public void Jump(Rigidbody2D rb, Transform t,bool canDoubleJump)
    {
        bool isGrounded = Physics2D.Raycast(t.position, -t.up, 1f, groundLayer);

        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            if (canDoubleJump) extraJump = 1; else extraJump = 0;

        }
        else if (extraJump > 0)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            extraJump--;
        }
    }
}
