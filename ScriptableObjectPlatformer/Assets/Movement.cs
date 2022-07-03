using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Movement : ScriptableObject
{
    public float moveSpeed;
    public float jumpForce;
    public bool doubleJump;
    int extraJump = 1;
    public LayerMask groundLayer;

    public void Run(Rigidbody2D rb, float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }
    public void Jump(Rigidbody2D rb, Transform t)
    {
        bool isGrounded = Physics2D.Raycast(t.position, -t.up, 1f, groundLayer);

        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce),ForceMode2D.Impulse);
            if (doubleJump) extraJump = 1; else extraJump = 0;
            
        }else if (extraJump > 0)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            extraJump--;
        }
    }
    public void DestroyEnemy(Transform t)
    {
        Destroy(t.gameObject);
    }
}
