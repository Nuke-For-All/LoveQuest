﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGrab : CustomBehavior {

	public WallGrab(Transform p, Rigidbody2D r, TouchingData t, float pGravity)
    {
        parent = p;
        rb = r;
        touching = t;

        Character.onFloor += Lock;
        Character.onAir += Lock;
        Character.onCeiling += Lock;

        Character.onLeft += Unlock;
        Character.onRight += Unlock;
    }

    override public void Execute() {}

    public bool IsGrabbed()
    {
        return active;
    }

    public Vector2 GetSide()
    {
        return touching.Get();
    }
}
