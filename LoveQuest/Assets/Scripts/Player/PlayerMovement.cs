using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement:CheckControls  {
    private const float maxSpeed = 15;
    private const float minSpeed = -15;
    private const float maxJump = 1.5f;
    private const float minJump = -47;

    public PlayerMovement(Rigidbody2D rb)
    {
        this.rb = rb;
    }
    public void Movement()
    {
        rb.AddForce(Vector2.right*movement.x,ForceMode2D.Impulse);
    }
    public void Jump()
    {
        if (jump)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        else
        {
            inJump = false;
        }
    }

    public void LimitSpeed()
    {
        if (rb.velocity.x > maxSpeed)
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        else if (rb.velocity.x < minSpeed)
            rb.velocity = new Vector2(minSpeed, rb.velocity.y);
        if (rb.velocity.y < minJump)
            rb.velocity = new Vector2(rb.velocity.x, minJump);
        if (rb.position.y > movement.y + maxJump)
        {
            jump = false;
            inJump = false;
        }
    }
	
}
