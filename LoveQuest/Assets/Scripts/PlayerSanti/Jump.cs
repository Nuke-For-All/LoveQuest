using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : CustomBehavior{

    //variable para saltar fuertemente
    private const float breakForce = 20;
    //variable para regular el salto
    private const float constForce = 4;

    private float force;
    private bool onJump = false;
    private float direction = 1;

    private const float startOverTimer = 0.2f;
    private float overTimer = startOverTimer;

	public Jump(Transform p, Rigidbody2D r, TouchingData t)
	{
		parent = p;
		rb = r;
        touching = t;

        Character.onAir += Lock;
        Character.onCeiling += Lock;
        Character.onJump += Lock;
        Character.onCeiling += Reset;

        Character.onFloor += Unlock;
        Character.onWallGrabbed += Unlock;
        
        Character.onJump += Update;
	}

	override public void Execute()
	{
        if(active)
        {
            if (!onJump)
            {
                onJump = true;
                force = breakForce;
            }
        }
	}

    private void Update()
    {
        if (onJump)
        {
            if (Input.GetButton("Jump"))
            {
                DoJump();
                UpdateOverTimer();
            }
            else
            {
                Reset();
            }
        }
    }

    private void DoJump()
    {
        rb.AddForce(new Vector2(0, direction) * force, ForceMode2D.Impulse);

        force = constForce;
    }

    private void UpdateOverTimer()
    {
        overTimer -= Time.deltaTime;

        if(overTimer <= 0)
        {
            Reset();
        }
    }

    private void Reset()
    {
        onJump = false;
        overTimer = startOverTimer;
    }

    public bool IsOnJump()
    {
        return onJump;
    }
}
