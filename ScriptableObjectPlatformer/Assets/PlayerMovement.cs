using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Movement movement;
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
        movement.Run(rb, Input.GetAxis("Horizontal"));
        //Calls Jump
        if (Input.GetKeyDown(KeyCode.W)) movement.Jump(rb, transform);
        //DestroyEnemy
        hit = Physics2D.Raycast(transform.position, -transform.up, 1f);
        if (hit.transform.tag == "Enemy") movement.DestroyEnemy(hit.transform);
    }
}
