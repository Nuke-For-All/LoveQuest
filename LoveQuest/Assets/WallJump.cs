using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : CustomBehavior {

    private float force = 20f;
    private Vector2 direction;
    public bool canJump = false;

	public WallJump(Transform t, Rigidbody2D r)
	{
		parent = t;
		rb = r;

        Character.onFloor += Lock;
        Character.onAir += Lock;
        Character.onWallGrab += Unlock;
        Character.onJump += Lock;
	}

	override public void Execute()
	{
        if(canJump)
        {
            DoWallJump();
        }
	}

    private void DoWallJump()
    {
        rb.AddForce(-direction * force, ForceMode2D.Impulse);
    }

    private void Unlock()
    {
        canJump = true;
    }

    private void Lock()
    {
        canJump = false;
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }
}
