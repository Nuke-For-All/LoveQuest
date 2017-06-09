using System.Collections;
using UnityEngine;

public class CheckControls {

    protected Vector2 movement;
    protected Rigidbody2D rb;
    protected float force = 1;
    protected float jumpForce =3f;
    protected bool jump = false;
    protected bool inJump = false;
    protected bool canJump = false;
    protected bool wallJumpLeft = false;
    protected bool wallJumpRight = false;
    protected int layer = 1 << 8;
 
	public void CheckInputs () {
        movement.x = Input.GetAxisRaw("Horizontal")*force;
        if (canJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                movement.y = rb.position.y;
                inJump = true;
            }
        }
        if (inJump)
        {
            jump = Input.GetButton("Jump");
        }
    }

    public void CheckFloor()
    {

            canJump = Physics2D.Raycast(rb.position, rb.transform.TransformDirection(Vector2.down), .6f, layer);
            Debug.DrawRay(rb.position, rb.transform.TransformDirection(Vector2.down) * .6f, Color.gray);
        if (!canJump)
        {
            wallJumpRight = Physics2D.Raycast(rb.position, rb.transform.TransformDirection(Vector2.right), .6f, layer);
            wallJumpLeft = Physics2D.Raycast(rb.position, rb.transform.TransformDirection(Vector2.left), .6f, layer);
            Debug.DrawRay(rb.position, rb.transform.TransformDirection(Vector2.left) * .6f, Color.gray);
            Debug.DrawRay(rb.position, rb.transform.TransformDirection(Vector2.right) * .6f, Color.gray);
        }
    }
}
