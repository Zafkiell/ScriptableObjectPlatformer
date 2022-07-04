using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyStats : ScriptableObject
{
    public float attackRange;
    public float jumpForce;
    public LayerMask isGround;

    public float patrolSpeed;
    public float chaseSpeed;
}
