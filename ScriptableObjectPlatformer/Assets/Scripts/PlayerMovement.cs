using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool doubleJump;
    public RunAction run;
    public JumpAction jump;
    public DestroyAction destroy;
    Rigidbody2D rb;
    RaycastHit2D hit;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //Cals Movement
        run.Run(rb, Input.GetAxis("Horizontal"));
        //Calls Jump
        if (Input.GetKeyDown(KeyCode.W)) jump.Jump(rb, transform, doubleJump);
        //DestroyEnemy
        hit = Physics2D.Raycast(transform.position, -transform.up, 1f);
        if (hit != false && hit.transform.tag == "Enemy") destroy.DestroyEnemy(hit.transform);
    }
}
