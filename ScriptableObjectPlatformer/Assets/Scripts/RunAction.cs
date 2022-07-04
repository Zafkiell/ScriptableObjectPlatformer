using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Run",menuName = "Actions/Run")]
public class RunAction : ScriptableObject
{
    public float runSpeed;

    public void Run(Rigidbody2D rb, float direction)
    {
        rb.velocity = new Vector2(direction * runSpeed, rb.velocity.y);
    }

    public void Patrol(Rigidbody2D rb,Transform t, Transform target)
    {
        t.position = Vector2.MoveTowards(t.position,target.position,runSpeed * Time.deltaTime);
    }
}
