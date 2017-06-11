using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : CustomBehavior {

    private float force = 20f;

	public WallJump(Transform p, Rigidbody2D r, TouchingData t)
	{
		parent = p;
		rb = r;
        touching = t;

        Character.onFloor += Lock;
        Character.onAir += Lock;
        Character.onJump += Lock;
        Character.onCeiling += Lock;

        Character.onWallGrabbed += Unlock;
	}

	override public void Execute()
	{
        if(active)
        {
            DoWallJump();
        }
	}

    private void DoWallJump()
    {
        rb.AddForce(-touching.Get() * force, ForceMode2D.Impulse);
    }
}
