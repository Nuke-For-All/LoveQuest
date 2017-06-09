using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGrab : CustomBehavior {

    private bool onGrabbed = false;
    public Vector2 direction;

	public WallGrab(Transform t, Rigidbody2D r)
    {
        parent = t;
        rb = r;

        Character.onFloor += Lock;
        Character.onJump += Lock;
        Character.onAir += Lock;
    }

    override public void Execute() 
    {
        if(direction == Vector2.left || direction == Vector2.right)
        {
            onGrabbed = true;
        }
    }

    public bool IsGrabbed()
    {
        return onGrabbed;
    }

    public Vector2 GetSide()
    {
        return direction;
    }

    private void Lock()
    {
        onGrabbed = false;
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }
}
